using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SocialSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions
{
    public class AppRoleManager : RoleManager<Role>
    {
        public AppRoleManager(
            IRoleStore<Role> store, 
            IEnumerable<IRoleValidator<Role>> roleValidators, 
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, 
            ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
            
        }
    }
}
