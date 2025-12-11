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

        public IEnumerable<RewardDto> GetRewards(Guid userId, bool trackChanges)
        {
            var user = _repository.AppUser.GetUser(userId, trackChanges);

            if (user == null)
                throw new UserNotFoundException(userId);

            var rewardsFromDb = _repository.Reward.GetRewards(userId, trackChanges);

            var rewardsDto = _mapper.Map<IEnumerable<RewardDto>>(rewardsFromDb);

            return rewardsDto;
        }

        public RewardDto GetReward(Guid userId, Guid id, bool trackChanges)
        {
            var user = _repository.AppUser.GetUser(userId, trackChanges);

            if (user == null)
                throw new UserNotFoundException(userId);

            var rewardDb = _repository.Reward.GetReward(userId, id, trackChanges);
            if (rewardDb is null)
                throw new RewardNotFoundException(id);

            var rewardDto = _mapper.Map<RewardDto>(rewardDb);
            return rewardDto;
        }

        public RewardDto CreateRewardForUser(Guid userId, RewardForCreationDto rewardForCreation, bool trackChanges)
        {
            var user = _repository.AppUser.GetUser(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var rewardEntity = _mapper.Map<Reward>(rewardForCreation);

            _repository.Reward.CreateRewardForUser(userId, rewardEntity);
            _repository.Save();

            var rewardToReturn = _mapper.Map<RewardDto>(rewardEntity);

            return rewardToReturn;
        }
    }
}
