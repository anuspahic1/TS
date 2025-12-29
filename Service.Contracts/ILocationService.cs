using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAllLocationsAsync(bool trackChanges);
        Task<LocationDto> GetLocationAsync(Guid locationId, bool trackChanges);
        Task<LocationDto> CreateLocationAsync(LocationForCreationDto location);
        Task DeleteLocationAsync(Guid locationId, bool trackChanges);
        Task UpdateLocationAsync(Guid locationId, LocationForUpdateDto locationForUpdate, bool trackChanges);
        Task<(LocationForUpdateDto locationToPatch, Guid locationId)>
        GetLocationForPatchAsync(Guid locationId, bool trackChanges);
        Task SaveChangesForPatchAsync(LocationForUpdateDto locationToPatch, Guid locationId, bool trackChanges);
    }
}
