using SocialSolutions.Models;
using SocialSolutions.Repositories.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SocialSolutions.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Account value)
        {
            var res = await _context.Accounts.AddAsync(value);

            if (!(await _context.SaveChangesAsync() > 0))
                throw new ApplicationException("Didn't added");

            return res.Entity.Id;
        }

        public async Task<Account> GetByLoginAsync(string login)
        {
            var acc = await _context.Accounts.Where(prop =>
                prop.Login == login)
                    .Include(prop => prop.User)
                    .Include(prop => prop.User.Roles)
                        .ThenInclude(prop => prop.Role)
                    .Include(prop => prop.User.OwnCommunities)
                    .Include(prop => prop.User.Location)
                    .Include(prop => prop.User.Communities)
                        .ThenInclude(prop => prop.Community)
                    .Include(prop => prop.User.Hobbies)
                        .ThenInclude(prop => prop.Hobby)
                    .Include(prop => prop.User.Groups)
                        .ThenInclude(prop => prop.Group)
                    .Include(prop => prop.User.Documents)
                    .Include(prop => prop.User.Skills)
                        .ThenInclude(prop => prop.Skill)
                    .Include(prop => prop.User.Albums)
                        .ThenInclude(prop => prop.Images)
                            .ThenInclude(prop => prop.Image)
                    .Include(prop => prop.User.Permits)
                        .ThenInclude(prop => prop.Permit)
                    .Include(prop => prop.User.Events)
                        .ThenInclude(prop => prop.Event).FirstOrDefaultAsync();

            if (acc is null) return null;

            foreach (var el in acc.User?.Roles) { el.User = null; el.Role.UsersRoles = null; }
            foreach (var el in acc.User?.OwnCommunities) { el.Users = null;  el.Owner = null; }
            foreach (var el in acc.User.Communities) { el.User = null; el.Community.Users = null; }
            foreach (var el in acc.User?.Permits) el.User = null;
            foreach (var el in acc.User?.Roles) el.User = null;
            foreach (var el in acc.User?.Groups) { el.User = null; el.Group.UsersGroups = null; }
            foreach (var el in acc.User?.Albums) el.User = null;
            foreach (var el in acc.User?.Hobbies) { el.User = null; el.Hobby.UsersHobbies = null; }
            foreach (var el in acc.User?.Skills) { el.User = null; el.Skill.UsersSkills = null; }
            foreach (var el in acc.User?.Events) el.User = null;

            return acc;
        }


        public async Task Remove(Account value) => await Task.Factory.StartNew(() =>
        {
            _context.Remove<Account>(value);
            _context.SaveChanges();
        });

        public async Task Update(Account oldValue, Account newValue)
        {
            var user = await GetByLoginAsync(oldValue.Login);
            user = newValue;
            if (!(await _context.SaveChangesAsync() > 0))
                throw new ApplicationException("Value didn't changed");
        }
    }
}
