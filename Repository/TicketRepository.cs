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

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(Guid userId, bool trackChanges)
        {
            return await FindByCondition(t => 
                t.Reservation != null && t.Reservation.UserId == userId, 
                trackChanges)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdWithDetailsAsync(Guid userId, bool trackChanges)
        {
            return await FindByCondition(t => 
                t.Reservation != null && t.Reservation.UserId == userId, 
                trackChanges)
                .Include(t => t.Event) 
                .Include(t => t.Reservation) 
                .OrderByDescending(t => t.Event.EventDate) 
                .ToListAsync();
        }
      public async Task<IEnumerable<Ticket>> GetAllTicketsAsync(bool trackChanges)
                {
                    return await FindAll(trackChanges)
                        .Include(t => t.Event) 
                        .Include(t => t.Reservation) 
                        .OrderByDescending(t => t.Event.EventDate) 
                        .ThenByDescending(t => t.Price)           
                        .ToListAsync();
                }

        public async Task<IEnumerable<Ticket>> GetTicketsByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
                {
                    return await FindByCondition(t => ids.Contains(t.Id), trackChanges)
                        .ToListAsync();
                }
}
}
