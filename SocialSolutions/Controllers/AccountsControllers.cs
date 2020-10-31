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

namespace SocialSolutions.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accRepo;
        private readonly IConfiguration _config;

        public AccountsController(
            IAccountRepository repo,
            IConfiguration config)
        {
            _accRepo = repo;
            _config = config;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] AccountViewModel creds)
        {
            if (await GetIdentity(creds) != null)
                return BadRequest(new { errorText = "This account already exist." });

            await _accRepo.Add(new Account()
            {
                Password = creds.Password,
                Login = creds.Login,
                User = new User()
            });

            var identity = await GetIdentity(creds);
            if (identity != null)
            {
                var account = await _accRepo.GetByLoginAsync(creds.Login);

                return new JsonResult(
                    new
                    {
                        responseType = HttpStatusCode.OK,
                        token = GetJwt(identity),
                        accountCreds = (ProfileViewModel)account,
                        Message = "You're registered in"
                    });
            }

            return BadRequest(new { errorText = "Something goes wrong." });
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] AccountViewModel creds)
        {
            var identity = await GetIdentity(creds);

            if (identity == null) 
                return BadRequest(new { errorText = "Invalid username or password." });

            var account = await _accRepo.GetByLoginAsync(creds.Login);

            return new JsonResult(
                new
                {
                    responseType = HttpStatusCode.OK,
                    token = GetJwt(identity),
                    accountCreds = account,
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

        private async Task<ClaimsIdentity> GetIdentity(AccountViewModel creds)
        {
            var acc = await _accRepo.GetByLoginAsync(creds.Login);

            if (acc != null && acc.Password == creds.Password)
            {
                var claims = new List<Claim>() { new Claim(ClaimsIdentity.DefaultNameClaimType, acc.Login) };

                if (acc.User.Roles.Count() > 0)
                    foreach (var role in acc.User.Roles.Select(prop => prop.Role.Name))
                        claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
                else
                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, "User"));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
                return claimsIdentity;
            }

            return null;
        }
    }
}
