﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UserAlbum
    {
        [Key]
        public int Id { get; set; }

        public User User{ get; set; }

        public IEnumerable<UserImage> Images { get; set; }
    }
}
