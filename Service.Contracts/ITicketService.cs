using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ITicketService
    {
        IEnumerable<TicketDto> GetAllTickets(bool trackChanges);
    }
}
