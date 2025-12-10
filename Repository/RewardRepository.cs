using Contracts;
using Entities.Models;

namespace Repository
{
    public class RewardRepository : RepositoryBase<Reward>, IRewardRepository
    {
        public RewardRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Reward> GetAllRewards(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(e => e.Description)
                .ToList();
        }

        public IEnumerable<Reward> GetRewardsForUser(Guid userId, bool trackChanges)
        {
            return FindByCondition(r => r.UserId.Equals(userId), trackChanges)
                    .OrderBy(r => r.GrantedAt)
                    .ToList();
        }

        public Reward GetReward(Guid rewardId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(rewardId), trackChanges)
                   .SingleOrDefault();
        }

        public void CreateReward(Reward reward)
        {
            Create(reward);
        }
    }
}
