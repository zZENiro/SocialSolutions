using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialSolutions.Models.ViewModels
{
    public class InputAccount
    {
        public int Id { get; set; }
        public string Login { get; set; }
    }

    public class InputLocation
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }


    public class ProfileInputViewModel
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string AboutMe { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public Location Location { get; set; }
        public string MobilePhone { get; set; }

        public static implicit operator User(ProfileInputViewModel vm) =>
            new User()
            {
                Id = vm.ProfileId,
                UserName = vm.Name,
                SecondName = vm.SecondName,
                AboutMe = vm.AboutMe,
                Birthdate = DateTime.Parse(vm.Birthdate),
                Gender = vm.Gender,
                Location = vm.Location,
                MobilePhone = vm.MobilePhone
            };
    }

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

        public static implicit operator ProfileViewModel(User acc)
        {
            var res = new ProfileViewModel()
            {
                OwnCommunities = acc.OwnCommunities,
                Communities = acc.Communities.Select(prop => prop.Community),
                Account = new AccountViewModel() { Id = acc.Id, Login = acc.Login },
                ProfileId = acc.Id,
                Name = acc.UserName,
                SecondName = acc.SecondName,
                AboutMe = acc.AboutMe,
                Birthdate = acc.Birthdate,
                Gender = acc.Gender,
                Location = acc.Location,
                MobilePhone = acc.MobilePhone,
                Documents = acc.Documents,
                Permits = acc.Permits.Select(prop => prop.Permit),
                Roles = acc.UsersRoles.Select(prop => prop.Role),
                Groups = acc.Groups.Select(prop => prop.Group),
                Albums = acc.Albums,
                Hobbies = acc.Hobbies.Select(prop => prop.Hobby),
                Skills = acc.Skills.Select(prop => prop.Skill),
                Events = acc.Events.Select(prop => prop.Event)
            };

            return res;
        }
    }
}
