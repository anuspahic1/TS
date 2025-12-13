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
            var user = await GetUserAndCheckIfItExist(userId, trackChanges);

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
            var user = await GetUserAndCheckIfItExist(userId, trackChanges);

            _repository.AppUser.DeleteUser(user);
            await _repository.SaveAsync();
        }

        private async Task<AppUser> GetUserAndCheckIfItExist(Guid id, bool trackChanges)
        {
            var user = await _repository.AppUser.GetUserAsync(id, trackChanges);
            return user is null ? throw new UserNotFoundException(id) : user;
        }

        public async Task UpdateUserAsync(Guid userId, AppUserForUpdateDto userForUpdate, bool trackChanges)
        {
            var userEntity = await GetUserAndCheckIfItExist(userId, trackChanges) ?? throw new UserNotFoundException(userId);
            _mapper.Map(userForUpdate, userEntity);
            await _repository.SaveAsync();
        }

        public async Task<(AppUserForUpdateDto userToPatch, Guid userId)> GetUserForPatchAsync(Guid userId, bool trackChanges)
        {
            var userEntity = await GetUserAndCheckIfItExist(userId, trackChanges);

            var userToPatch = _mapper.Map<AppUserForUpdateDto>(userEntity);

            return (userToPatch, userId);
        }


        public async Task SaveChangesForPatchAsync(AppUserForUpdateDto userToPatch, Guid userId, bool trackChanges)
        {
            var userEntity = await GetUserAndCheckIfItExist(userId, trackChanges);

            _mapper.Map(userToPatch, userEntity);

            await _repository.SaveAsync();
        }



    }
}
