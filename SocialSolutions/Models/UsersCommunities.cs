﻿using System.ComponentModel.DataAnnotations;

namespace SocialSolutions.Models
{
    public class UsersCommunities
    { 
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Community Community { get; set; }
    }

}
