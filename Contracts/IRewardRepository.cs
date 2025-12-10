using Entities.Models;

namespace Contracts
{
    public interface IRewardRepository
    {
        IEnumerable<Reward> GetAllRewards(bool trackChanges);
        IEnumerable<Reward> GetRewardsForUser(Guid userId, bool trackChanges);
        Reward GetReward(Guid rewardId, bool trackChanges);
        void CreateReward(Reward reward);
    }
}
