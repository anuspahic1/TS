using AutoMapper;
using Contracts;
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
            try
            {
                var rewards = _repository.Reward.GetAllRewards(trackChanges);

                var rewardsDto = rewards.Select(r =>
                    new RewardDto(
                        r.Id,
                        r.Description,
                        r.ImageUrl,
                        r.GrantedAt,
                        r.UserId,
                        r.User?.FullName ?? string.Empty
                    )).
                    ToList();

                return rewardsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the{nameof(GetAllRewards)} service method {ex}");
                throw;
            }
        }
    }
}
