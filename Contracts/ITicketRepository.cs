using Entities.Models;

namespace Contracts
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAllTickets(bool trackChanges);
        Ticket GetTicket(Guid ticketId, bool trackChanges);
    }
}
