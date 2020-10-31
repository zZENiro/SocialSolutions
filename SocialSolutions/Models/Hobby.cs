using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<HobbiesEvents> HobbiesEvents { get; set; }

        public IEnumerable<UsersHobbies> UsersHobbies { get; set; }
    }
}
