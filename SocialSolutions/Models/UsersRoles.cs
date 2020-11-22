using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UsersRoles : IdentityUserRole<int>
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}