using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class AppUserService : IAppUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AppUserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<AppUserDto> GetAllUsers(bool trackChanges)
        {
            var users = _repository.AppUser.GetAllUsers(trackChanges);

            var usersDto = _mapper.Map<IEnumerable<AppUserDto>>(users);

            return usersDto;
        }
    }
}
