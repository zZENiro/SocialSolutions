using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class CommunitiesHobbies
    { 
        [Key]
        public int Id { get; set; }

        public Community Community { get; set; }

        public Hobby Hobby { get; set; }
    }

}
