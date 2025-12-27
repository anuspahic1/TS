using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class EventService : IEventService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public EventService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> GetEventsAsync(Guid locationId, EventParameters eventParameters, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            var eventsFromDb = await _repository.Event.GetEventsAsync(locationId, eventParameters, trackChanges);

            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(eventsFromDb);

            return eventsDto;
        }

        public async Task<EventDto> GetEventAsync(Guid locationId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            var eventDb = await GetEventForLocationAndCheckIfItExists(locationId, id, trackChanges);

            var ev = _mapper.Map<EventDto>(eventDb);

            return ev;
        }

        public async Task<EventDto> CreateEventForLocationAsync(Guid locationId, EventForCreationDto eventForCreation, bool trackChanges)
{
    const int MAX_CAPACITY = 100;

    await CheckIfLocationExists(locationId, trackChanges);

    if (eventForCreation.EventDate < DateTime.Now)
        throw new Exception("Event date cannot be in the past.");

    if (eventForCreation.Capacity > MAX_CAPACITY)
        throw new Exception($"Capacity exceeds maximum limit of {MAX_CAPACITY}.");

    var eventEntity = _mapper.Map<Event>(eventForCreation);

    _repository.Event.CreateEventForLocation(locationId, eventEntity);
    await _repository.SaveAsync();

    int seatsPerRow = eventEntity.Capacity <= 100 ? 10 : 20;
    
    for (int i = 0; i < eventEntity.Capacity; i++)
    {
        char rowLetter = (char)('A' + (i / seatsPerRow));
        int seatNumInRow = (i % seatsPerRow) + 1;

        var ticket = new Ticket
        {
            EventId = eventEntity.Id,
            SeatNumber = $"{rowLetter}{seatNumInRow}",
            Price = eventEntity.MinTicketPrice, 
            IsReserved = false
        };

        _repository.Ticket.CreateTicketForEvent(eventEntity.Id, ticket);
    }

    await _repository.SaveAsync();

    return _mapper.Map<EventDto>(eventEntity);
}

        public async Task DeleteEventForLocationAsync(Guid locationId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            var eventDb = await GetEventForLocationAndCheckIfItExists(locationId, id, trackChanges);

            _repository.Event.DeleteEvent(eventDb);
            await _repository.SaveAsync();
        }

        private async Task CheckIfLocationExists(Guid id, bool trackChanges)
        {
            var location = await _repository.Location.GetLocationAsync(id, trackChanges) ?? throw new LocationNotFoundException(id);
        }

        private async Task<Event> GetEventForLocationAndCheckIfItExists(Guid locationId, Guid id, bool trackChanges)
        {
            var eventDb = await _repository.Event.GetEventAsync(locationId, id, trackChanges);
            return eventDb is null ? throw new EventNotFoundException(id) : eventDb;
        }

        public async Task UpdateEventForLocationAsync(Guid locationId, Guid id, EventForUpdateDto eventForUpdate, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            var eventEntity = await GetEventForLocationAndCheckIfItExists(locationId, id, trackChanges) ?? throw new EventNotFoundException(id);
            if (eventForUpdate.LocationId.HasValue && eventForUpdate.LocationId != locationId)
            {
                await CheckIfLocationExists(eventForUpdate.LocationId.Value, trackChanges);
                eventEntity.LocationId = eventForUpdate.LocationId.Value;
            }
            _mapper.Map(eventForUpdate, eventEntity);
            await _repository.SaveAsync();
        }
        public async Task<(EventForUpdateDto eventToPatch, Guid eventId)> GetEventForPatchAsync(Guid locationId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            var eventEntity = await GetEventForLocationAndCheckIfItExists(locationId, id, trackChanges);

            var eventToPatch = _mapper.Map<EventForUpdateDto>(eventEntity);

            return (eventToPatch, eventEntity.Id);
        }
        public async Task SaveChangesForPatchAsync(EventForUpdateDto eventToPatch, Guid locationId, Guid id, bool trackChanges)
        {
            var eventEntity = await GetEventForLocationAndCheckIfItExists(locationId, id, trackChanges);

            if (eventToPatch.LocationId.HasValue && eventToPatch.LocationId != locationId)
            {
                await CheckIfLocationExists(eventToPatch.LocationId.Value, trackChanges);
                eventEntity.LocationId = eventToPatch.LocationId.Value;
            }

            _mapper.Map(eventToPatch, eventEntity);

            await _repository.SaveAsync();
        }
        public async Task<IEnumerable<EventDto>> GetEventsForUserAsync(Guid userId, bool trackChanges)
        {
            var eventsFromDb = await _repository.Event.GetEventsForUserAsync(userId, trackChanges);

            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(eventsFromDb);

            return eventsDto;
        }
        public async Task<IEnumerable<EventDto>> GetAllEventsAsync(EventParameters eventParameters, bool trackChanges)
            {
                var eventsWithMetaData = await _repository.Event.GetAllEventsAsync(eventParameters, trackChanges);

                var eventsDto = _mapper.Map<IEnumerable<EventDto>>(eventsWithMetaData);

                return eventsDto;
            }
    }
}
