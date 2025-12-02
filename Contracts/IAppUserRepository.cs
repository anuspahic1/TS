using Entities.Models;

namespace Contracts
{
    public interface IAppUserRepository
    {
        IEnumerable<AppUser> GetAllUsers(bool trackChanges);
    }
}
