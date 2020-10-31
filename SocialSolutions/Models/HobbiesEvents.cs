using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class HobbiesEvents
    {
        [Key]
        public int Id { get; set; }

        public Event Event { get; set; }

        public Hobby Hobby { get; set; }
    }
}
