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
            var user = await _repository.AppUser.GetUserAsync(userId, trackChanges);

            if (user == null)
                throw new UserNotFoundException(userId);

            var rewardsFromDb = await _repository.Reward.GetRewardsAsync(userId, trackChanges);

            var rewardsDto = _mapper.Map<IEnumerable<RewardDto>>(rewardsFromDb);

            return rewardsDto;
        }

        public async Task<RewardDto> GetRewardAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _repository.AppUser.GetUserAsync(userId, trackChanges);

            if (user == null)
                throw new UserNotFoundException(userId);

            var rewardDb = await _repository.Reward.GetRewardAsync(userId, id, trackChanges);
            if (rewardDb is null)
                throw new RewardNotFoundException(id);

            var rewardDto = _mapper.Map<RewardDto>(rewardDb);
            return rewardDto;
        }

        public async Task<RewardDto> CreateRewardForUserAsync(Guid userId, RewardForCreationDto rewardForCreation, bool trackChanges)
        {
            var user = _repository.AppUser.GetUserAsync(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var rewardEntity = _mapper.Map<Reward>(rewardForCreation);

            _repository.Reward.CreateRewardForUser(userId, rewardEntity);
            await _repository.SaveAsync();

            var rewardToReturn = _mapper.Map<RewardDto>(rewardEntity);

            return rewardToReturn;
        }

        public async Task DeleteRewardForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _repository.AppUser.GetUserAsync(userId, trackChanges);
            if (user is null)
                throw new EventNotFoundException(userId);

            var rewardForUser = await _repository.Reward.GetRewardAsync(userId, id, trackChanges);
            if (rewardForUser is null)
                throw new RewardNotFoundException(id);

            _repository.Reward.DeleteReward(rewardForUser);
            await _repository.SaveAsync();
        }
    }
}
