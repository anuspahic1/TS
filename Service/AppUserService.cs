using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

        public AppUserDto GetUser(Guid userId, bool trackChanges)
        {
            var user = _repository.AppUser.GetUser(userId, trackChanges);
            if (user == null)
                throw new UserNotFoundException(userId);

            var userDto = _mapper.Map<AppUserDto>(user);
            return userDto;
        }

        public AppUserDto CreateUser(AppUserForCreationDto user)
        {
            var userEntity = _mapper.Map<AppUser>(user);

            _repository.AppUser.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<AppUserDto>(userEntity);

            return userToReturn;
        }

        public void DeleteUser(Guid userId, bool trackChanges)
        {
            var user = _repository.AppUser.GetUser(userId, trackChanges);
            if (user is null)
                throw new LocationNotFoundException(userId);

            _repository.AppUser.DeleteUser(user);
            _repository.Save();
        }
    }
}
