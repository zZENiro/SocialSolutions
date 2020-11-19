using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialSolutions.Models;
using SocialSolutions.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialSolutions.Repositories.Stores
{
    public class ApplicationRoleStore : IRoleStore<Role>
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRoleStore(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken) => await Task.Factory.StartNew(() =>
        {
            _context.Roles.FromSqlInterpolated($"EXEC ");

            return IdentityResult.Success;
        });

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        { }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
