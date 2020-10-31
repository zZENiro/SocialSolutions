using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UsersSkills> UsersSkills { get; set; }
    }
}
