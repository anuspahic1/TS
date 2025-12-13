using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUserDto>> GetAllUsersAsync(bool trackChanges);
        Task<AppUserDto> GetUserAsync(Guid userId, bool trackChanges);
        Task<AppUserDto> CreateUserAsync(AppUserForCreationDto user);
        Task UpdateUserAsync(Guid userId, AppUserForUpdateDto userForUpdate, bool trackChanges);
        Task DeleteUserAsync(Guid userId, bool trackChanges);

        Task<(AppUserForUpdateDto userToPatch, Guid userId)>
        GetUserForPatchAsync(Guid userId, bool trackChanges);

        Task SaveChangesForPatchAsync(AppUserForUpdateDto userToPatch, Guid userId, bool trackChanges);
    }
}
