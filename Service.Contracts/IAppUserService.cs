using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUserDto>> GetAllUsersAsync(bool trackChanges);
        Task<AppUserDto> GetUserAsync(Guid userId, bool trackChanges);
        Task<AppUserDto> CreateUserAsync(AppUserForCreationDto user);
        Task DeleteUserAsync(Guid userId, bool trackChanges);
    }
}
