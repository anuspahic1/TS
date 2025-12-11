using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

        public IEnumerable<TicketDto> GetTickets(Guid locationId, Guid eventId, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);

            if (location == null)
                throw new LocationNotFoundException(locationId);

            var ev = _repository.Event.GetEvent(locationId, eventId, trackChanges);

            if (ev == null)
                throw new EventNotFoundException(eventId);

            var ticketsFromDb = _repository.Ticket.GetTickets(locationId, eventId, trackChanges);

            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(ticketsFromDb);

            return ticketsDto;
        }

        public TicketDto GetTicket(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = _repository.Event.GetEvent(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(locationId);

            var ticket = _repository.Ticket.GetTicket(locationId, eventId, id, trackChanges);
            if (ticket is null)
                throw new TicketNotFoundException(id);

            var ticketDto = _mapper.Map<TicketDto>(ticket);

            return ticketDto;
        }

        public TicketDto CreateTicketForEvent(Guid locationId, Guid eventId, TicketForCreationDto ticketForCreation, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = _repository.Event.GetEvent(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var ticketEntity = _mapper.Map<Ticket>(ticketForCreation);

            _repository.Ticket.CreateTicketForEvent(eventId, ticketEntity);
            _repository.Save();

            var ticketToReturn = _mapper.Map<TicketDto>(ticketEntity);

            return ticketToReturn;
        }
    }
}
