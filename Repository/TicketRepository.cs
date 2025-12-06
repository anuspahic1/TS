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

        public Ticket GetTicket(Guid ticketId, bool trackChanges)
        {
            return FindByCondition(e => e.Id.Equals(ticketId), trackChanges)
                   .SingleOrDefault();
        }
    }
}
