using System;
using System.Collections.Generic;

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

        public IEnumerable<Community> OwnCommunities { get; set; }

        public IEnumerable<Document> Documents { get; set; }
        
        public IEnumerable<Community> Communities { get; set; }

        public IEnumerable<Permit> Permits { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public IEnumerable<Group> Groups { get; set; }

        public IEnumerable<UserAlbum> Albums { get; set; }

        public IEnumerable<Hobby> Hobbies { get; set; }

        public IEnumerable<Skill> Skills { get; set; }

        public IEnumerable<Event> Events { get; set; }

        //
    }
}
