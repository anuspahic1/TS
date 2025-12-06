using Entities.Models;

namespace Contracts
{
    public interface IAppUserRepository
    {
        IEnumerable<AppUser> GetAllUsers(bool trackChanges);
        AppUser GetUser(Guid userId, bool trackChanges);
    }
}
