using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public User User { get; set; }
    }
}
