using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialSolutions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Controllers
{
    [Controller]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "userPolicy")]
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

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> SetValues([FromBody] ProfileViewModel viewmodel)
        //{
            
        //}

        //public async Task<IActionResult> 
    }
}
