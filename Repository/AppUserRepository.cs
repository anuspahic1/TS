using Contracts;
using Entities.Models;

namespace Repository
{
    public class AppUserRepository : RepositoryBase<AppUser>, IAppUserRepository
    {
        public AppUserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { 
        }

        public IEnumerable<AppUser> GetAllUsers(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(e => e.Email)
                .ToList();
        }
    }
}
