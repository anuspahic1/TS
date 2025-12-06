using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class TicketService : ITicketService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TicketService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<TicketDto> GetAllTickets(bool trackChanges)
        {
            var tickets = _repository.Ticket.GetAllTickets(trackChanges);

            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return ticketsDto;
        }
    }
}
