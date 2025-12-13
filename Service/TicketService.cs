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
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var ticketsFromDb = await _repository.Ticket.GetTicketsAsync(locationId, eventId, trackChanges);

            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(ticketsFromDb);

            return ticketsDto;
        }

        public async Task<TicketDto> GetTicketAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var ticket = await GetTicketForEventAndCheckIfItExists(locationId, eventId, id, trackChanges);

            var ticketDto = _mapper.Map<TicketDto>(ticket);

            return ticketDto;
        }

        public async Task<TicketDto> CreateTicketForEventAsync(Guid locationId, Guid eventId, TicketForCreationDto ticketForCreation, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var ticketEntity = _mapper.Map<Ticket>(ticketForCreation);

            _repository.Ticket.CreateTicketForEvent(eventId, ticketEntity);
            await _repository.SaveAsync();

            var ticketToReturn = _mapper.Map<TicketDto>(ticketEntity);

            return ticketToReturn;
        }

        public async Task DeleteTicketForEventAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var ticketForEvent = await GetTicketForEventAndCheckIfItExists(locationId, eventId, id, trackChanges);

            _repository.Ticket.DeleteTicket(ticketForEvent);
            await _repository.SaveAsync();
        }

        private async Task CheckIfLocationExists(Guid id, bool trackChanges)
        {
            _ = await _repository.Location.GetLocationAsync(id, trackChanges) ?? throw new LocationNotFoundException(id);
        }

        private async Task CheckIfEventExists(Guid locationId, Guid id, bool trackChanges)
        {
            _ = await _repository.Event.GetEventAsync(locationId, id, trackChanges) ?? throw new EventNotFoundException(id);
        }

        private async Task<Ticket> GetTicketForEventAndCheckIfItExists(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var ticketDb = await _repository.Ticket.GetTicketAsync(locationId, eventId, id, trackChanges);
            return ticketDb is null ? throw new TicketNotFoundException(id) : ticketDb;
        }

        public async Task UpdateTicketForEventAsync(Guid locationId, Guid eventId, Guid id, TicketForUpdateDto ticket, bool locationTrackChanges, bool eventTrackChanges, bool ticketTrackChanges)
        {
            await CheckIfLocationExists(locationId, locationTrackChanges);

            await CheckIfEventExists(locationId, eventId, eventTrackChanges);

            var ticketEntity = await GetTicketForEventAndCheckIfItExists(locationId, eventId, id, ticketTrackChanges);

            _mapper.Map(ticket, ticketEntity);
            await _repository.SaveAsync();
        }
        public async Task<(TicketForUpdateDto ticketToPatch, Guid ticketId)> GetTicketForPatchAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var ticketEntity = await GetTicketForEventAndCheckIfItExists(locationId, eventId, id, trackChanges);

            var ticketToPatch = _mapper.Map<TicketForUpdateDto>(ticketEntity);

            return (ticketToPatch, ticketEntity.Id);
        }

        public async Task SaveChangesForPatchAsync(TicketForUpdateDto ticketToPatch, Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var ticketEntity = await GetTicketForEventAndCheckIfItExists(locationId, eventId, id, trackChanges);

            _mapper.Map(ticketToPatch, ticketEntity);

            await _repository.SaveAsync();
        }

    }
}
