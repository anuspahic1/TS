using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IRewardService
    {
        IEnumerable<RewardDto> GetRewards(Guid userId, bool trackChanges);
        RewardDto GetReward(Guid userId, Guid id, bool trackChanges);
        RewardDto CreateRewardForUser(Guid userId, RewardForCreationDto reward, bool trackChanges);
    }
}
