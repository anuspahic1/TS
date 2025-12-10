using Entities.Models;

namespace Contracts
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocations(bool trackChanges);
        Location GetLocation(Guid locationId,  bool trackChanges);
        void CreateLocation(Location location);
    }
}
