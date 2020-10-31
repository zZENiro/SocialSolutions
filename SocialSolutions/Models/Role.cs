using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialSolutions.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UsersRoles> UsersRoles { get; set; }
    }
}
