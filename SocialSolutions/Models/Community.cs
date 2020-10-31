using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class Community
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Describtion { get; set; }

        public Image Photo { get; set; } 

        public User Owner { get; set; }

        public IEnumerable<CommunitiesHobbies> Hobbies { get; set; }

        public IEnumerable<UsersCommunities> Users{ get; set; }
    }

}
