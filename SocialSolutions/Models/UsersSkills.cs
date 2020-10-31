using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UsersSkills
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Skill Skill { get; set; }
    }
}
