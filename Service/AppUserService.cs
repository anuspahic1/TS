using Contracts;
using Service.Contracts;

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
    }
}
