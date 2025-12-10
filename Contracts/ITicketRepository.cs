using Entities.Models;

namespace Contracts
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAllTickets(bool trackChanges);
        IEnumerable<Ticket> GetTicketsForEvent(Guid eventId, bool trackChanges);
        Ticket GetTicket(Guid ticketId, bool trackChanges);
        void CreateTicket(Ticket ticket);
    }
}
