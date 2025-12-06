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

        public IEnumerable<EventDto> GetAllEvents(bool trackChanges)
        {
            var events = _repository.Event.GetAllEvents(trackChanges);

            var eventsDto = _mapper.Map<IEnumerable<EventDto>>(events);

            return eventsDto;
        }

        public EventDto GetEvent(Guid eventId, bool trackChanges)
        {
            var ev = _repository.Event.GetEvent(eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var eventDto = _mapper.Map<EventDto>(ev);
            return eventDto;
        }
    }
}
