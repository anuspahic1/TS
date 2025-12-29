using Entities.Models;

namespace Contracts
{
    public interface IRewardRepository
    {
        Task<IEnumerable<Reward>> GetRewardsAsync(Guid userId, bool trackChanges);
        Task<Reward> GetRewardAsync(Guid userId, Guid id, bool trackChanges);
        void CreateRewardForUser(Guid userId, Reward reward);
        void DeleteReward(Reward reward);

    }
}
