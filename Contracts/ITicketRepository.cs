namespace Contracts
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync(Guid locationId, Guid eventId, bool trackChanges);
        Task<Ticket> GetTicketAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        void CreateTicketForEvent(Guid eventId, Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}
