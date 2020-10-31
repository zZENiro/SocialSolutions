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
                prop.Login == login).
                    Include(prop => prop.User)
                        .ThenInclude(prop => prop.Roles).
                            ThenInclude(prop => prop.Role).FirstOrDefaultAsync();

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
