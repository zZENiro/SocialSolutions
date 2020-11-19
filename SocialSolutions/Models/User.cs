using Microsoft.AspNetCore.Identity;
using SocialSolutions.Controllers;
using SocialSolutions.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialSolutions.Models
{
    public class User : IdentityUser<int>
    {
        public string Login { get; set; }

        public string SecondName { get; set; }

        public string AboutMe { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string MobilePhone { get; set; }

        public Location Location { get; set; }

        public IEnumerable<Event> CreatedEvents { get; set; }

        public IEnumerable<Event> ModeratedEvents { get; set; }

        public IEnumerable<Community> OwnCommunities { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public IEnumerable<UserAlbum> Albums { get; set; }

        #region many-to-many relations
        public IEnumerable<UsersRoles> UsersRoles { get; set; } 

        public IEnumerable<UsersCommunities> Communities { get; set; }

        public IEnumerable<UsersPermits> Permits { get; set; }

        public IEnumerable<UsersGroups> Groups { get; set; }

        public IEnumerable<UsersHobbies> Hobbies { get; set; }

        public IEnumerable<UsersSkills> Skills { get; set; }

        public IEnumerable<UsersEvents> VisitedEvents { get; set; }
        #endregion
    }
}
