using Contracts;
using Entities.Models;

namespace Repository
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Reservation> GetReservations(Guid locationId, Guid eventId, bool trackChanges)
        {
            return FindByCondition(r => r.EventId.Equals(eventId) &&
                                   r.Event != null &&
                                   r.Event.LocationId.Equals(locationId), trackChanges)
                    .OrderBy(r => r.CreatedAt)
                    .ToList();
        }

        public Reservation GetReservation(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            return FindByCondition(r => r.EventId.Equals(eventId) &&
                                    r.Event != null &&
                                    r.Event.LocationId.Equals(locationId) &&
                                    r.Id.Equals(id), trackChanges)
                   .SingleOrDefault();
        }


        public void CreateReservationForEvent(Guid locationId, Guid eventId, Reservation reservation)
        {
            reservation.Event.LocationId = locationId;
            reservation.EventId = eventId;
            Create(reservation);
        }
    }
}
