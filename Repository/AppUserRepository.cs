using Contracts;
using Entities.Models;
using Microsoft.Extensions.Logging;

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

        public AppUser GetUser(Guid userId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(userId), trackChanges)
                   .SingleOrDefault();
        }

        public void CreateUser(AppUser user)
        {
            Create(user);
        }
    }
}
