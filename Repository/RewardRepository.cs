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

        public Reward GetReward(Guid rewardId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(rewardId), trackChanges)
                   .SingleOrDefault();
        }
    }
}
