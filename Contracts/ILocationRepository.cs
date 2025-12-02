using Entities.Models;

namespace Contracts
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocations(bool trackChanges);
    }
}
