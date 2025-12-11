using Contracts;
using Entities.Models;

namespace Repository
{
    public class RewardRepository : RepositoryBase<Reward>, IRewardRepository
    {
        public RewardRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Reward> GetRewards(Guid userId, bool trackChanges)
        {
            return FindByCondition(r => r.UserId.Equals(userId), trackChanges)
                    .OrderBy(e => e.Description)
                    .ToList();
        }

        public IEnumerable<Reward> GetRewardsForUser(Guid userId, bool trackChanges)
        {
            return FindByCondition(r => r.UserId.Equals(userId), trackChanges)
                    .OrderBy(r => r.GrantedAt)
                    .ToList();
        }

        public Reward GetReward(Guid userId, Guid id, bool trackChanges)
        {
            return FindByCondition(r => r.UserId.Equals(userId) && r.Id.Equals(id), trackChanges)
                   .SingleOrDefault();
        }

        public void CreateRewardForUser(Guid userId, Reward reward)
        {
            reward.UserId = userId;
            Create(reward);
        }
    }
}
