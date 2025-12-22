using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync(Guid locationId, Guid eventId, bool trackChanges)
        {
            return await FindByCondition(r => r.EventId.Equals(eventId) &&
                                   r.Event.LocationId.Equals(locationId), trackChanges)
                    .OrderBy(r => r.CreatedAt)
                    .ToListAsync();
        }

        public async Task<Reservation> GetReservationAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            return await FindByCondition(r => r.EventId.Equals(eventId) &&
                                    r.Event.LocationId.Equals(locationId) &&
                                    r.Id.Equals(id), trackChanges)
                   .SingleOrDefaultAsync();
        }


        public void CreateReservationForEvent(Guid eventId, Reservation reservation)
        {
            reservation.EventId = eventId;
            Create(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            Delete(reservation);
        }
        public async Task<int> GetTotalBookingsCountAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).CountAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(Guid userId, bool trackChanges) =>
            await FindByCondition(r => r.UserId == userId, trackChanges)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        
        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdWithDetailsAsync(Guid userId, bool trackChanges) =>
            await FindByCondition(r => r.UserId == userId, trackChanges)
                .Include(r => r.Event) 
                .Include(r => r.Tickets) 
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
    }
}
