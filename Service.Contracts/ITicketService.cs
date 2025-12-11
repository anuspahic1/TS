using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ITicketService
    {
        IEnumerable<TicketDto> GetTickets(Guid locationId, Guid eventId, bool trackChanges);
        TicketDto GetTicket(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        TicketDto CreateTicketForEvent(Guid locationId, Guid eventId, TicketForCreationDto ticket, bool trackChanges);
    }
}
