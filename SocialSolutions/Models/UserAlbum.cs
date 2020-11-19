using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UserAlbum
    {
        [Key]
        public int Id { get; set; }

        public User Owner { get; set; }

        public IEnumerable<UserImage> Images { get; set; }
    }
}
