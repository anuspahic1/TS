using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAppUserService
    {
        IEnumerable<AppUserDto> GetAllUsers(bool trackChanges);
        AppUserDto GetUser(Guid userId, bool trackChanges);
    }
}
