using Contracts;
using Entities.Models;

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

        public Reservation GetReservation(Guid reservationId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(reservationId), trackChanges)
                   .SingleOrDefault();
        }
    }
}
