using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ILocationService
    {
        IEnumerable<LocationDto> GetAllLocations(bool trackChanges);
        LocationDto GetLocation(Guid locationId, bool trackChanges);
        LocationDto CreateLocation(LocationForCreationDto location);
        void DeleteLocation(Guid locationId, bool trackChanges);
    }
}
