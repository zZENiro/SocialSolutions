using System.Collections.Generic;

namespace SocialSolutions.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; }

        public IEnumerable<UsersGroups> UsersGroups { get; set; }
    }
}
