using Entities.Models;

namespace Contracts
{
    public interface IRewardRepository
    {
        IEnumerable<Reward> GetRewards(Guid userId, bool trackChanges);
        Reward GetReward(Guid userId, Guid id, bool trackChanges);
        void CreateRewardForUser(Guid userId, Reward reward);
        void DeleteReward(Reward reward);
    }
}
