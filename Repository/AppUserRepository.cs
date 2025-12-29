using System.Numerics;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppUserRepository : RepositoryBase<AppUser>, IAppUserRepository
    {
        public AppUserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync(UserParameters userParameters, bool trackChanges)
        {
            userParameters ??= new UserParameters();
            return await FindAll(trackChanges)
                .OrderBy(e => e.Email)
                .Search(userParameters.SearchTerm)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserAsync(Guid userId, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(userId), trackChanges)
                   .SingleOrDefaultAsync();
        }

        public void CreateUser(AppUser user)
        {
            Create(user);
        }

        public void DeleteUser(AppUser user)
        {
            Delete(user);
        }

        public async Task<int> GetTotalUsersCount(bool trackChanges)
        {
            return await FindAll(trackChanges).CountAsync();
        }
    }
}
