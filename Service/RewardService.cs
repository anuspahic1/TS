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

        public IEnumerable<RewardDto> GetAllRewards(bool trackChanges)
        {
            var rewards = _repository.Reward.GetAllRewards(trackChanges);

            var rewardsDto = _mapper.Map<IEnumerable<RewardDto>>(rewards);

            return rewardsDto;
        }

        public IEnumerable<RewardDto> GetRewardsForUser(Guid userId, bool trackChanges)
        {
            var user = _repository.AppUser.GetUser(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var rewards = _repository.Reward.GetRewardsForUser(userId, trackChanges);
            var rewardsDto = _mapper.Map<IEnumerable<RewardDto>>(rewards);

            return rewardsDto;
        }

        public RewardDto GetReward(Guid rewardId, bool trackChanges)
        {
            var reward = _repository.Reward.GetReward(rewardId, trackChanges);
            if (reward is null)
                throw new RewardNotFoundException(rewardId);

            var rewardDto = _mapper.Map<RewardDto>(reward);
            return rewardDto;
        }

        public RewardDto CreateReward(RewardForCreationDto reward)
        {
            var rewardEntity = _mapper.Map<Reward>(reward);

            _repository.Reward.CreateReward(rewardEntity);
            _repository.Save();

            var rewardToReturn = _mapper.Map<RewardDto>(rewardEntity);

            return rewardToReturn;
        }
    }
}
