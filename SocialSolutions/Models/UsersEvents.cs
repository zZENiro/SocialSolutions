using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UsersEvents
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Event Event { get; set; }
    }
}
