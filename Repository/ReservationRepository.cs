using Contracts;
using Entities.Models;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Reservation> GetAllReservations(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(e => e.TotalPrice)
                .ToList();
        }

        public IEnumerable<Reservation> GetReservationsForEvent(Guid eventId, bool trackChanges)
        {
            return FindByCondition(r => r.EventId.Equals(eventId), trackChanges)
                    .OrderBy(r => r.CreatedAt)
                    .ToList();
        }

        public IEnumerable<Reservation> GetReservationsForUser(Guid userId, bool trackChanges)
        {
            return FindByCondition(r => r.EventId.Equals(userId), trackChanges)
                    .OrderBy(r => r.CreatedAt)
                    .ToList();
        }

        public Reservation GetReservation(Guid reservationId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(reservationId), trackChanges)
                   .SingleOrDefault();
        }
    }
}
