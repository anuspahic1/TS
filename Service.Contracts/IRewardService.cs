using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IRewardService
    {
        IEnumerable<RewardDto> GetAllRewards(bool trackChanges);
        RewardDto GetReward(Guid rewardId, bool trackChanges);
    }
}
