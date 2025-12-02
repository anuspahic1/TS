using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class AppUserService : IAppUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public AppUserService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<AppUserDto> GetAllUsers(bool trackChanges)
        {
            try
            {
                var users = _repository.AppUser.GetAllUsers(trackChanges);

                var usersDto = users.Select(u =>
                    new AppUserDto(
                        u.Id,
                        u.FullName,
                        u.Email
                    ))
                    .ToList();

                return usersDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the{nameof(GetAllUsers)} service method {ex}");
                throw;
            }
        }
    }
}
