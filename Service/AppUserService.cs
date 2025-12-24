using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Identity; 
using Entities.Models;

namespace Service
{
    internal sealed class AppUserService : IAppUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AppUserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<AppUserDto>> GetAllUsersAsync(UserParameters userParameters, bool trackChanges)
        {
            var users = await _repository.AppUser.GetAllUsersAsync(userParameters, trackChanges);

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
            // 1. Ažuriranje Identity tabele (AspNetUsers)
            var identityUser = await _userManager.FindByIdAsync(userId.ToString());
            if (identityUser == null) throw new UserNotFoundException(userId);

            identityUser.FirstName = userForUpdate.FirstName;
            identityUser.LastName = userForUpdate.LastName;
            identityUser.UserName = userForUpdate.UserName;
            identityUser.Email = userForUpdate.Email;

            var result = await _userManager.UpdateAsync(identityUser);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Identity error: {errors}");
            }

            // 2. Ažuriranje tvoje tabele (AppUsers)
            var userEntity = await GetUserAndCheckIfItExist(userId, trackChanges);
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
