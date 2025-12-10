using Contracts;
using Entities.Models;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Location> GetAllLocations(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(e => e.Name)
                .ToList();
        }

        public Location GetLocation(Guid locationId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(locationId), trackChanges)
                   .SingleOrDefault();
        }

        public void CreateLocation(Location location)
        {
            Create(location);
        }

    }
}
