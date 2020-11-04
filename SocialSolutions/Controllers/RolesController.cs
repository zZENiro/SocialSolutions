using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialSolutions.Models;
using SocialSolutions.Repositories;
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

        public RolesController(IRoleStore<Role> roleStore)
        {
            this._roleStore = roleStore;
        }

        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> GetAll() => new JsonResult(await _roleStore.get);
    }
}
