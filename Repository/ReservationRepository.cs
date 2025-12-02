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
    }
}
