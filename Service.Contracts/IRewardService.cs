using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IRewardService
    {
        IEnumerable<RewardDto> GetAllRewards(bool trackChanges);
        IEnumerable<RewardDto> GetRewardsForUser(Guid userId, bool trackChanges);
        RewardDto GetReward(Guid rewardId, bool trackChanges);
    }
}
