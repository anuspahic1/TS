using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RewardRepository : RepositoryBase<Reward>, IRewardRepository
    {
        public RewardRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Reward>> GetRewardsAsync(Guid userId, bool trackChanges)
        {
            return await FindByCondition(r => r.UserId.Equals(userId), trackChanges)
                    .OrderBy(e => e.Description)
                    .ToListAsync();
        }

        public async Task<Reward> GetRewardAsync(Guid userId, Guid id, bool trackChanges)
        {
            return await FindByCondition(r => r.UserId.Equals(userId) && r.Id.Equals(id), trackChanges)
                   .SingleOrDefaultAsync();
        }

        public void CreateRewardForUser(Guid userId, Reward reward)
        {
            reward.UserId = userId;
            Create(reward);
        }

        public void DeleteReward(Reward reward)
        {
            Delete(reward);
        }
    }
}
