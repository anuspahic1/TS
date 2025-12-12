namespace Contracts
{
    public interface IAppUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync(bool trackChanges);
        Task<AppUser> GetUserAsync(Guid userId, bool trackChanges);
        void CreateUser(AppUser user);
        void DeleteUser(AppUser user);
    }
}
