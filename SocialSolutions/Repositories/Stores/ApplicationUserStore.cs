using Microsoft.AspNetCore.Identity;
using SocialSolutions.Models;
using SocialSolutions.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore;

namespace SocialSolutions.Repositories.Stores
{
    public class ApplicationUserStore : IUserStore<User>
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IdentityResult> RemoveRoleFromUser(User user, Role role, CancellationToken cancellationToken) => await Task.Factory.StartNew(() =>
        {
            if (cancellationToken.IsCancellationRequested)
                return IdentityResult.Failed(new IdentityError() { Description = "Cancellation requested" });

            _context.UserRoles.FromSqlInterpolated($"EXEC RemoveRoleFromUser @UserId={user.Id}, @RoleId={role.Id}");

            return IdentityResult.Success;
        });

        public async Task<IdentityResult> AddRoleToUser(User user, Role role, CancellationToken cancellationToken) => await Task.Factory.StartNew(() =>
        {
            if (cancellationToken.IsCancellationRequested)
                return IdentityResult.Failed(new IdentityError() { Description = "Cancellation requested" });

            _context.UserRoles.FromSqlInterpolated<UsersRoles>($"EXEC Append_Role @UserId={user.Id}, @RoleId={role.Id}");

            return IdentityResult.Success;
        });

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken) => await Task.Factory.StartNew(() =>
        {
            if (cancellationToken.IsCancellationRequested)
                return IdentityResult.Failed(new IdentityError() { Description = "Cancellation requested" });

            _context.Users.FromSqlInterpolated<User>(
                $"EXEC Create_User @Login={user.Login}, @PasswordHash={user.PasswordHash}, @ConcurrencyStamp={user.ConcurrencyStamp}");

            return IdentityResult.Success;
        });

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

            var queryableUser = await _context.FindAsync<User>(int.Parse(userId), cancellationToken);
            if (queryableUser is null)
                return null;

            return queryableUser;
        }

        public async Task<User> FindByLogin(string login, CancellationToken cancellationToken) => await Task.Factory.StartNew(() =>
        {
            if (cancellationToken.IsCancellationRequested)
                return null;

            var queryableUser = _context.Users.FromSqlInterpolated<User>($"EXEC FindByLogin_User @Login = {login}").AsEnumerable<User>().FirstOrDefault();

            if (queryableUser is null)
                return null;

            return queryableUser;
        });

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
                return IdentityResult.Failed(new IdentityError() { Description = "Cancellation requested." });

            var affectedRow = await _context.Database.ExecuteSqlCommandAsync("Update_User @UserName, @NormalizedUserName, @Login, @SecondName, @AboutMe, @Birthdate, @Gender, @Id",
                                                                             new[] { user.UserName, user.NormalizedUserName, user.Login, user.SecondName, user.AboutMe, user.Birthdate.ToString(), user.Gender, user.Id.ToString() });
            if (affectedRow < 0)
                return IdentityResult.Failed(new IdentityError() { Description = "Query has been droped" });

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdatePasswordHash(string hashedPassword, int userId, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return IdentityResult.Failed(new IdentityError() { Description = "Cancellation requested." });

            var affectedRow = await _context.Database.ExecuteSqlCommandAsync("Update_PasswordHash @PasswordHash, @Id",
                                                                             new[] { hashedPassword, userId.ToString() });

            if (affectedRow < 0)
                return IdentityResult.Failed(new IdentityError() { Description = "Query has been droped" });

            return IdentityResult.Success;
        }
    }
}
