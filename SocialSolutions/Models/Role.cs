using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialSolutions.Models
{
    public class Role : IdentityRole<int>
    {
        public IEnumerable<UsersRoles> UsersRoles { get; set; }
    }

}
