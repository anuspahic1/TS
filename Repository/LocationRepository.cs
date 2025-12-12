using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        public async Task<Location> GetLocationAsync(Guid locationId, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(locationId), trackChanges)
                   .SingleOrDefaultAsync();
        }

        public void CreateLocation(Location location)
        {
            Create(location);
        }

        public void DeleteLocation(Location location)
        {
            Delete(location);
        }
    }
}
