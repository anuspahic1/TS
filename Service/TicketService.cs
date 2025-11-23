using Contracts;
using Service.Contracts;

namespace Service
{
    internal sealed class TicketService : ITicketService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public TicketService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
