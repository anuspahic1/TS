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

        public async Task<IEnumerable<EventDto>> GetEventsAsync(Guid locationId, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            var eventsFromDb = await _repository.Event.GetEventsAsync(locationId, trackChanges);

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
            await CheckIfLocationExists(locationId, trackChanges);

            var eventEntity = _mapper.Map<Event>(eventForCreation);

            _repository.Event.CreateEventForLocation(locationId, eventEntity);
            await _repository.SaveAsync();

            var eventToReturn =_mapper.Map<EventDto>(eventEntity);

            return eventToReturn;
        }

        public async Task DeleteEventForLocationAsync(Guid locationId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            var eventDb = await GetEventForLocationAndCheckIfItExists(locationId, id, trackChanges)

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
    }
}
