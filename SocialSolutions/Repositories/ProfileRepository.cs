using SocialSolutions.Models;
using SocialSolutions.Repositories.Data;
using System;
using System.Threading.Tasks;

namespace SocialSolutions.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(User value)
        {
            var res = await _context.Users.AddAsync(value);
            if (!(await _context.SaveChangesAsync() > 0))
                throw new ApplicationException("Didn't added");
            
            return res.Entity.Id;
        }

        public async Task<User> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task Remove(User value) => await Task.Factory.StartNew(() =>
        {
            _context.Remove<User>(value);
            _context.SaveChanges();
        });

        public async Task Update(User oldValue, User newValue)
        {
            var user = await GetByIdAsync(oldValue.Id);
            user = newValue;
            if (!(await _context.SaveChangesAsync() > 0))
                throw new ApplicationException("Value didn't changed");
        }
    }
}
