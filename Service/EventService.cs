using AutoMapper;
using Contracts;
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
            try
            {
                var events = _repository.Event.GetAllEvents(trackChanges);

                var eventsDto = events.Select(e =>
                    new EventDto(
                        e.Id,
                        e.Name ?? string.Empty,
                        e.Description,
                        e.Created,
                        e.Location?.Name ?? string.Empty
                    ))
                    .ToList();

                return eventsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the{ nameof(GetAllEvents)} service method { ex }");
                throw;
            }
        }
    }
}
