using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ILocationService
    {
        IEnumerable<LocationDto> GetAllLocations(bool trackChanges);
    }
}
