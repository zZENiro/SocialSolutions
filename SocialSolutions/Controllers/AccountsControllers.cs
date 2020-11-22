using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialSolutions.Models.ViewModels;
using SocialSolutions.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using SocialSolutions.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using SocialSolutions.Repositories.Stores;

namespace SocialSolutions.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationUserStore _userStore;
        private readonly CancellationTokenSource _cts;
        private readonly PasswordHasher<User> _passwordHasher;

        public AccountsController(
            IConfiguration configuration,
            CancellationTokenSource cts,
            IUserStore<User> userStore,
            PasswordHasher<User> passwordHasher)
        {
            _config = configuration;
            _userStore = userStore as ApplicationUserStore;
            _cts = cts;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] AccountViewModel creds)
        {
            if (await _userStore.FindByLogin(creds.Login, _cts.Token) != null)
                return BadRequest(new { errorText = "This account already exist" });

            var newUser = new Models.User() { Login = creds.Login };
            var hashedUserPassword = _passwordHasher.HashPassword(newUser, creds.Password);
            newUser.PasswordHash = hashedUserPassword;

            var createResult = await _userStore.CreateAsync(newUser, _cts.Token);
            if (await _userStore.CreateAsync(newUser, _cts.Token) == IdentityResult.Success)
            {
                var identity = GetIdentity(newUser);

                return new JsonResult(
                    new
                    {
                        responseType = HttpStatusCode.OK,
                        token = GetJwt(identity),
                        accountCreds = new { Login = creds.Login },
                        Message = "You're logged in"
                    });
            }

            return BadRequest(new { errorText = $"Something goes wrong. \n{createResult.Errors.ToList()}" });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] AccountViewModel creds)
        {
            var queryableUser = await _userStore.FindByLogin(creds.Login, _cts.Token);

            if (queryableUser is null)
                return BadRequest(new { ErrorMessage = "There is no that account." });

            var verifyResult = _passwordHasher.VerifyHashedPassword(queryableUser, queryableUser.PasswordHash, creds.Password);

            if (verifyResult == PasswordVerificationResult.Failed)
                return BadRequest(new { errorText = "Bad password." });
            else if (verifyResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                queryableUser.PasswordHash = _passwordHasher.HashPassword(queryableUser, creds.Password);
                await _userStore.UpdatePasswordHash(queryableUser.PasswordHash, queryableUser.Id, _cts.Token);
            }

            var identity = GetIdentity(queryableUser);

            return new JsonResult(
                new
                {
                    responseType = HttpStatusCode.OK,
                    token = GetJwt(identity),
                    accountCreds = queryableUser,
                    Message = "You're logged in"
                });
        }

        private string GetJwt(ClaimsIdentity claims)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    notBefore: now,
                    claims: claims.Claims,
                    expires: now.Add(TimeSpan.FromDays(int.Parse(_config["Jwt:lifetime"]))),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:key"])),
                        SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ClaimsIdentity GetIdentity(User acc)
        {
            var claims = new List<Claim>() { new Claim(ClaimsIdentity.DefaultNameClaimType, acc.Login) };

            if (acc.UsersRoles != null && acc.UsersRoles.Count() > 0)
                foreach (var role in acc.UsersRoles.Select(prop => prop.Role.Name))
                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            else
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, "User"));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
            return claimsIdentity;
        }
    }
}
