using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UsersPermits
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Permit Permit { get; set; }
    }
}
