using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(Guid locationId, Guid eventId, bool trackChanges)
        {
            return await FindByCondition(t => t.EventId.Equals(eventId) && 
                                   t.Event.LocationId.Equals(locationId), 
                                   trackChanges)
                    .OrderBy(t => t.Price)
                    .ToListAsync();
        }

        public async Task<Ticket> GetTicketAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            return await FindByCondition(t => t.EventId.Equals(eventId) &&
                                    t.Event.LocationId.Equals(locationId) &&
                                    t.Id.Equals(id), 
                                    trackChanges)
                   .SingleOrDefaultAsync();
        }

        public void CreateTicketForEvent(Guid eventId, Ticket ticket)
        {
            ticket.EventId = eventId;
            Create(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            Delete(ticket);
        }
    }
}
