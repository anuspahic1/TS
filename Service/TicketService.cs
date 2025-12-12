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

        public async Task<IEnumerable<TicketDto>> GetTicketsAsync(Guid locationId, Guid eventId, bool trackChanges)
        {
            var location = await _repository.Location.GetLocationAsync(locationId, trackChanges);

            if (location == null)
                throw new LocationNotFoundException(locationId);

            var ev = await _repository.Event.GetEventAsync(locationId, eventId, trackChanges);

            if (ev == null)
                throw new EventNotFoundException(eventId);

            var ticketsFromDb = await _repository.Ticket.GetTicketsAsync(locationId, eventId, trackChanges);

            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(ticketsFromDb);

            return ticketsDto;
        }

        public async Task<TicketDto> GetTicketAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var location = await _repository.Location.GetLocationAsync(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = await _repository.Event.GetEventAsync(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(locationId);

            var ticket = await _repository.Ticket.GetTicketAsync(locationId, eventId, id, trackChanges);
            if (ticket is null)
                throw new TicketNotFoundException(id);

            var ticketDto = _mapper.Map<TicketDto>(ticket);

            return ticketDto;
        }

        public async Task<TicketDto> CreateTicketForEventAsync(Guid locationId, Guid eventId, TicketForCreationDto ticketForCreation, bool trackChanges)
        {
            var location = await _repository.Location.GetLocationAsync(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = await _repository.Event.GetEventAsync(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var ticketEntity = _mapper.Map<Ticket>(ticketForCreation);

            _repository.Ticket.CreateTicketForEvent(eventId, ticketEntity);
            await _repository.SaveAsync();

            var ticketToReturn = _mapper.Map<TicketDto>(ticketEntity);

            return ticketToReturn;
        }

        public async Task DeleteTicketForEventAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var ev = await _repository.Event.GetEventAsync(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var ticketForEvent = await _repository.Ticket.GetTicketAsync(locationId, eventId, id, trackChanges);
            if (ticketForEvent is null)
                throw new TicketNotFoundException(id);

            _repository.Ticket.DeleteTicket(ticketForEvent);
            await _repository.SaveAsync();
        }
    }
}
