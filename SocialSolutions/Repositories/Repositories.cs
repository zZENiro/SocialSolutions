using SocialSolutions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialSolutions.Repositories
{
    public interface IRepository<T>
    {
        Task<int> Add(T value);

        Task Remove(T value);

        Task Update(T oldValue, T newValue);
    }

    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetByLoginAsync(string login);
    }

    public interface IProfileRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(int id);
    }

    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByNameAsync(string roleName);

        Task<IEnumerable<Role>> GetAllAsync();
    }

    public interface ILocationRepository : IRepository<Location>
    {
        
    }

    public class LocationRepository : ILocationRepository
    {
        public Task<int> Add(Location value)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(Location value)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Location oldValue, Location newValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
