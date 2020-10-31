using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UsersHobbies
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Hobby Hobby { get; set; }
    }
}
