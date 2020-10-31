using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialSolutions.Models.ViewModels
{
    public class ProfileViewModel
    {
        public AccountViewModel Account { get; set; }

        public int ProfileId { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string AboutMe { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public Location Location { get; set; }

        public string MobilePhone { get; set; }
    }
}
