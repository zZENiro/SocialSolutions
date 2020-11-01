using SocialSolutions.Controllers;
using SocialSolutions.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string AboutMe { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string MobilePhone { get; set; }

        public Location Location { get; set; }

        public IEnumerable<Community> OwnCommunities { get; set; }

        public IEnumerable<UsersCommunities> Communities { get; set; }

        public IEnumerable<UsersPermits> Permits { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public IEnumerable<UsersRoles> Roles { get; set; }

        public IEnumerable<UsersGroups> Groups { get; set; }

        public IEnumerable<UserAlbum> Albums { get; set; }

        public IEnumerable<UsersHobbies> Hobbies { get; set; }

        public IEnumerable<UsersSkills> Skills { get; set; }

        public IEnumerable<UsersEvents> Events { get; set; }

    }
}
