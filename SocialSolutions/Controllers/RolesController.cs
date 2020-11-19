using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialSolutions.Models;
using SocialSolutions.Repositories;
using SocialSolutions.Repositories.Data;
using SocialSolutions.Repositories.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Controllers
{


    [Controller]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRoleStore<Role> _roleStore;

        public RolesController(ApplicationDbContext dbContext)
        {
            _roleStore = new ApplicationRoleStore(dbContext);
        }

        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> GetAll()
        //{
            
        //}
    }
}
