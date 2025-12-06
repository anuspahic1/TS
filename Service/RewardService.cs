using AutoMapper;
using Contracts;
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
    }
}
