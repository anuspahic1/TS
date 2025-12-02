using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class TicketService : ITicketService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public TicketService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<TicketDto> GetAllTickets(bool trackChanges)
        {
            try
            {
                var tickets = _repository.Ticket.GetAllTickets(trackChanges);

                var ticketsDto = tickets.Select(t =>
                    new TicketDto(
                        t.Id,
                        t.Price,
                        t.SeatNumber,
                        t.IsReserved,
                        t.QRCode,
                        t.EventId,
                        t.Event?.Name ?? string.Empty
                    ))
                    .ToList();

                return ticketsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the{nameof(GetAllTickets)} service method {ex}");
                throw;
            }
        }
    }
}
