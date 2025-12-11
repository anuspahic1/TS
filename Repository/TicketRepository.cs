using Contracts;
using Entities.Models;

namespace Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Ticket> GetTickets(Guid locationId, Guid eventId, bool trackChanges)
        {
            return FindByCondition(t => t.EventId.Equals(eventId) && 
                                   t.Event.LocationId.Equals(locationId), 
                                   trackChanges)
                    .OrderBy(t => t.Price)
                    .ToList();
        }

        public Ticket GetTicket(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            return FindByCondition(t => t.EventId.Equals(eventId) &&
                                    t.Event.LocationId.Equals(locationId) &&
                                    t.Id.Equals(id), 
                                    trackChanges)
                   .SingleOrDefault();
        }

        public void CreateTicketForEvent(Guid eventId, Ticket ticket)
        {
            ticket.EventId = eventId;
            Create(ticket);
        }
    }
}
