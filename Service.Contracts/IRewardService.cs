using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IRewardService
    {
        Task<IEnumerable<RewardDto>> GetRewardsAsync(Guid userId, bool trackChanges);
        Task<RewardDto> GetRewardAsync(Guid userId, Guid id, bool trackChanges);
        Task<RewardDto> CreateRewardForUserAsync(Guid userId, RewardForCreationDto reward, bool trackChanges);
        Task DeleteRewardForUserAsync(Guid userId, Guid id, bool trackChanges);
        Task UpdateRewardForUserAsync(Guid userId, Guid id, RewardForUpdateDto reward, bool trackChanges);
        Task<(RewardForUpdateDto rewardToPatch, Guid userId, Guid rewardId)>
        GetRewardForPatchAsync(Guid userId, Guid rewardId, bool trackChanges);
        Task SaveChangesForPatchAsync(RewardForUpdateDto rewardToPatch, Guid userId, Guid rewardId, bool trackChanges);
    }
}
