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

        static public implicit operator User(ProfileViewModel model)
        {
            var user = new User() { Id = model.ProfileId };

            return new User()
            {
                Id = model.ProfileId,
                AboutMe = model.AboutMe,
                Name = model.Name,
                SecondName = model.SecondName,
                Birthdate = model.Birthdate,
                Gender = model.Gender,
                MobilePhone = model.MobilePhone,
                OwnCommunities = model.OwnCommunities,
                Communities = model.Communities.Select(prop => new UsersCommunities() { User = user, Community = new Community() { Id = prop.Id } }),
                Permits = model.Permits.Select(prop => new UsersPermits() { User = user, Permit = new Permit() { Id = prop.Id } }),
                Documents = model.Documents.Select(prop => new Document() { Id = prop.Id }),
                Roles = model.Roles.Select(prop => new UsersRoles() { User = user, Role = new Role() { Id = prop.Id } }),
                Groups = model.Groups.Select(prop => new UsersGroups() { User = user, Group = new Group() { Id = prop.Id } }),
                Hobbies = model.Hobbies.Select(prop => new UsersHobbies() { User = user, Hobby = new Hobby() { Id = prop.Id } }),
                Skills = model.Skills.Select(prop => new UsersSkills() { User = user, Skill = new Skill() { Id = prop.Id } }),
                Events = model.Events.Select(prop => new UsersEvents() { User = user, Event = new Event() { Id = prop.Id } }),
                Location = model.Location
            };
        }
    }
}
