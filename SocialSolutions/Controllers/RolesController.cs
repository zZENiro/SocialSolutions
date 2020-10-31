using Microsoft.AspNetCore.Mvc;
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
        IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll() => new JsonResult(await _roleRepository.GetAllAsync());
    }
}
