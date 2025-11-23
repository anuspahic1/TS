using Contracts;
using Entities.Models;

namespace Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
