using SocialSolutions.Models;
using SocialSolutions.Repositories.Data;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SocialSolutions.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Role value)
        {
            var res = await _context.Roles.AddAsync(value);
            if (!(await _context.SaveChangesAsync() > 0))
                throw new ApplicationException("Didn't added");

            return res.Entity.Id;
        }

        public async Task<IEnumerable<Role>> GetAllAsync() =>
             await Task.Factory.StartNew(() => _context.Roles.ToList<Role>());

        public async Task<Role> GetByNameAsync(string roleName) =>
            await Task.Factory.StartNew(() => _context.Roles.Where(prop => prop.Name == roleName).FirstOrDefault());

        public async Task Remove(Role value) => await Task.Factory.StartNew(() =>
        {
            _context.Remove<Role>(value);
            _context.SaveChanges();
        });

        public async Task Update(Role oldValue, Role newValue)
        {
            var user = await GetByNameAsync(oldValue.Name);
            user = newValue;
            if (!(await _context.SaveChangesAsync() > 0))
                throw new ApplicationException("Value didn't changed");
        }
    }
}
