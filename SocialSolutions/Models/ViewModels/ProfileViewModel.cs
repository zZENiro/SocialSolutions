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
        public Account Account { get; set; }
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
                Name = vm.Name,
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

        public static implicit operator ProfileViewModel(Account acc)
        {
            var res = new ProfileViewModel()
            {
                OwnCommunities = acc.User.OwnCommunities,
                Communities = acc.User.Communities.Select(prop => prop.Community),
                Account = new AccountViewModel() { Id = acc.Id, Login = acc.Login, Password = acc.Password },
                ProfileId = acc.User.Id,
                Name = acc.User.Name,
                SecondName = acc.User.SecondName,
                AboutMe = acc.User.AboutMe,
                Birthdate = acc.User.Birthdate,
                Gender = acc.User.Gender,
                Location = acc.User.Location,
                MobilePhone = acc.User.MobilePhone,
                Documents = acc.User.Documents,
                Permits = acc.User.Permits.Select(prop => prop.Permit),
                Roles = acc.User.Roles.Select(prop => prop.Role),
                Groups = acc.User.Groups.Select(prop => prop.Group),
                Albums = acc.User.Albums,
                Hobbies = acc.User.Hobbies.Select(prop => prop.Hobby),
                Skills = acc.User.Skills.Select(prop => prop.Skill),
                Events = acc.User.Events.Select(prop => prop.Event)
            };

            return res;
        }
    }
}
