using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class RewardService : IRewardService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RewardService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RewardDto>> GetRewardsAsync(Guid userId, bool trackChanges)
        {
            await CheckIfUserExists(userId, trackChanges);

            var rewardsFromDb = await _repository.Reward.GetRewardsAsync(userId, trackChanges);

            var rewardsDto = _mapper.Map<IEnumerable<RewardDto>>(rewardsFromDb);

            return rewardsDto;
        }

        public async Task<RewardDto> GetRewardAsync(Guid userId, Guid id, bool trackChanges)
        {
            await CheckIfUserExists(userId, trackChanges);

            var rewardDb = await GetRewardForUserAndCheckIfItExists(userId, id, trackChanges);

            var rewardDto = _mapper.Map<RewardDto>(rewardDb);
            return rewardDto;
        }

        public async Task<RewardDto> CreateRewardForUserAsync(Guid userId, RewardForCreationDto rewardForCreation, bool trackChanges)
        {
            await CheckIfUserExists(userId, trackChanges);

            var rewardEntity = _mapper.Map<Reward>(rewardForCreation);

            _repository.Reward.CreateRewardForUser(userId, rewardEntity);
            await _repository.SaveAsync();

            var rewardToReturn = _mapper.Map<RewardDto>(rewardEntity);

            return rewardToReturn;
        }

        public async Task DeleteRewardForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            await CheckIfUserExists(userId, trackChanges);

            var rewardForUser = await GetRewardForUserAndCheckIfItExists(userId, id, trackChanges);

            _repository.Reward.DeleteReward(rewardForUser);
            await _repository.SaveAsync();
        }

        private async Task CheckIfUserExists(Guid id, bool trackChanges)
        {
            _ = await _repository.AppUser.GetUserAsync(id, trackChanges) ?? throw new UserNotFoundException(id);
        }

        private async Task<Reward> GetRewardForUserAndCheckIfItExists(Guid userId, Guid id, bool trackChanges)
        {
            var reward = await _repository.Reward.GetRewardAsync(userId, id, trackChanges);
            return reward is null ? throw new RewardNotFoundException(id) : reward;
        }
        public async Task UpdateRewardForUserAsync(Guid userId, Guid id, RewardForUpdateDto reward, bool trackChanges)
        {
            await CheckIfUserExists(userId, trackChanges);

            var rewardEntity = await GetRewardForUserAndCheckIfItExists(userId, id, trackChanges) ?? throw new RewardNotFoundException(id);
            _mapper.Map(reward, rewardEntity);
            await _repository.SaveAsync();
        }
    }
}
