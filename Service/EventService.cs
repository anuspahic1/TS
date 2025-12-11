using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

        public IEnumerable<EventDto> GetEvents(Guid locationId, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);

            if (location == null) 
                throw new LocationNotFoundException(locationId);

            var eventsFromDb = _repository.Event.GetEvents(locationId, trackChanges);

            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(eventsFromDb);

            return eventsDto;
        }

        public EventDto GetEvent(Guid locationId, Guid id, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var eventDb = _repository.Event.GetEvent(locationId, id, trackChanges);
            if (eventDb is null)
                throw new EventNotFoundException(locationId);

            var ev = _mapper.Map<EventDto>(eventDb);

            return ev;
        }

        public EventDto CreateEventForLocation(Guid locationId, EventForCreationDto eventForCreation, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);
            
            var eventEntity = _mapper.Map<Event>(eventForCreation);

            _repository.Event.CreateEventForLocation(locationId, eventEntity);
            _repository.Save();

            var eventToReturn =_mapper.Map<EventDto>(eventEntity);

            return eventToReturn;
        }

        public void DeleteEventForLocation(Guid locationId, Guid id, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var eventForLocation = _repository.Event.GetEvent(locationId, id, trackChanges);
            if (eventForLocation is null)
                throw new EventNotFoundException(id);

            _repository.Event.DeleteEvent(eventForLocation);
            _repository.Save();
        }
    }
}
