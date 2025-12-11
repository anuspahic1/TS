using Entities.Models;

namespace Contracts
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets(Guid locationId, Guid eventId, bool trackChanges);
        Ticket GetTicket(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        void CreateTicketForEvent(Guid eventId, Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}
