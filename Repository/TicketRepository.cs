using Contracts;
using Entities.Models;

namespace Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Ticket> GetAllTickets(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(e => e.Price)
                .ToList();
        }

        public IEnumerable<Ticket> GetTicketsForEvent(Guid eventId, bool trackChanges)
        {
            return FindByCondition(t => t.EventId.Equals(eventId), trackChanges)
                    .OrderBy(t => t.SeatNumber)
                    .ToList();
        }

        public Ticket GetTicket(Guid ticketId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(ticketId), trackChanges)
                   .SingleOrDefault();
        }

        public void CreateTicket(Ticket ticket)
        {
            Create(ticket);
        }
    }
}
