using AutoMapper;
using Contracts;
using Entities.Exceptions;
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


        public IEnumerable<TicketDto> GetTicketsForEvent(Guid eventId, bool trackChanges)
        {
            var ev = _repository.Event.GetEvent(eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var tickets = _repository.Ticket.GetTicketsForEvent(eventId, trackChanges);
            var ticketDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return ticketDto;
        }

        public TicketDto GetTicket(Guid ticketId, bool trackChanges)
        {
            var ticket = _repository.Ticket.GetTicket(ticketId, trackChanges);
            if (ticket is null)
                throw new TicketNotFoundException(ticketId);

            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return ticketDto;
        }
    }
}
