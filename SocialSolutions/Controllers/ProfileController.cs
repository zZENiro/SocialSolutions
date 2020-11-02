using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialSolutions.Models;
using SocialSolutions.Models.ViewModels;
using SocialSolutions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialSolutions.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "userPolicy")]
    
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepo;
        private readonly IAccountRepository _accRepo;

        public ProfileController(
            IProfileRepository profileRepo,
            IAccountRepository accRepo)
        {
            _profileRepo = profileRepo;
            _accRepo = accRepo;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SetValues([FromBody] ProfileInputViewModel viewmodel)
        {
            var user = (User)viewmodel;

            var userProfile = await _profileRepo.GetByIdAsync(user.Id);
            var userAccount = await _accRepo.GetByLoginAsync(viewmodel.Account.Login);

            var first = JsonSerializer.Serialize(userProfile);

            await _profileRepo.Update(userProfile, user);

            userProfile = await _profileRepo.GetByIdAsync(user.Id);

            var second = JsonSerializer.Serialize(userProfile);

            return new ContentResult() { ContentType = "application/json", Content = first + second };
        }

    }
}
