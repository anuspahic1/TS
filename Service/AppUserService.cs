using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

        public async Task<IEnumerable<AppUserDto>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await _repository.AppUser.GetAllUsersAsync(trackChanges);

            var usersDto = _mapper.Map<IEnumerable<AppUserDto>>(users);

            return usersDto;
        }

        public async Task<AppUserDto> GetUserAsync(Guid userId, bool trackChanges)
        {
            var user = await _repository.AppUser.GetUserAsync(userId, trackChanges);
            if (user == null)
                throw new UserNotFoundException(userId);

            var userDto = _mapper.Map<AppUserDto>(user);
            return userDto;
        }

        public async Task<AppUserDto> CreateUserAsync(AppUserForCreationDto user)
        {
            var userEntity = _mapper.Map<AppUser>(user);

            _repository.AppUser.CreateUser(userEntity);
            await _repository.SaveAsync();

            var userToReturn = _mapper.Map<AppUserDto>(userEntity);

            return userToReturn;
        }

        public async Task DeleteUserAsync(Guid userId, bool trackChanges)
        {
            var user = await _repository.AppUser.GetUserAsync(userId, trackChanges);
            if (user is null)
                throw new LocationNotFoundException(userId);

            _repository.AppUser.DeleteUser(user);
            await _repository.SaveAsync();
        }
    }
}
