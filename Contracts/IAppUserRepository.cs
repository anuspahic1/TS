using System.Numerics;

namespace Contracts
{
    public interface IAppUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync(UserParameters userParameters, bool trackChanges);
        Task<AppUser> GetUserAsync(Guid userId, bool trackChanges);
        void CreateUser(AppUser user);
        void DeleteUser(AppUser user);
        Task<int> GetTotalUsersCount(bool trackChanges);

    }
}
