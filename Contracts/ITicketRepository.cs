namespace Contracts
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync(Guid locationId, Guid eventId, bool trackChanges);
        Task<Ticket> GetTicketAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges);
        void CreateTicketForEvent(Guid eventId, Ticket ticket);
        void DeleteTicket(Ticket ticket);

        Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(Guid userId, bool trackChanges);
        Task<IEnumerable<Ticket>> GetTicketsByUserIdWithDetailsAsync(Guid userId, bool trackChanges);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync(bool trackChanges);
    }
}
