using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetAllEvents(bool trackChanges);
    }
}
