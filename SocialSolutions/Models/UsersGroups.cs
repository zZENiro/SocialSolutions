using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UsersGroups
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
        
        public Group Group { get; set; }
    }
}
