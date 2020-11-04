using Microsoft.AspNetCore.Identity;
using SocialSolutions.Models;
using SocialSolutions.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialSolutions.Repositories.Stores
{
    public class ApplicationUserStore : IUserStore<User>
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return IdentityResult.Failed(new IdentityError() { Description = "Cancellation requested" });

            await _context.Users.AddAsync(user, cancellationToken);

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        { }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return null;

            var queryableUser = await _context.FindAsync<User>(userId, cancellationToken);
            if (queryableUser is null)
                return null;

            return queryableUser;
        }


        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return null;

            var queryableUser = await _context.FindAsync<User>(normalizedUserName, cancellationToken);
            if (queryableUser is null)
                return null;

            return queryableUser;
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return IdentityResult.Failed(new IdentityError() { Description = "Cancellation requested." } );

            throw new Exception();
        }
    }
}
