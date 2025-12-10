using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ITicketService
    {
        IEnumerable<TicketDto> GetAllTickets(bool trackChanges);
        IEnumerable<TicketDto> GetTicketsForEvent(Guid eventId, bool trackChanges);
        TicketDto GetTicket(Guid ticketId, bool trackChanges);
    }
}
