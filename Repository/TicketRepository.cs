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
    }
}
