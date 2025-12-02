using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class ReservationService : IReservationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ReservationService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<ReservationDto> GetAllReservations(bool trackChanges)
        {
            try
            {
                var reservations = _repository.Reservation.GetAllReservations(trackChanges);

                var reservationsDto = reservations.Select(r =>
                    new ReservationDto(
                        r.Id,
                        r.CreatedAt,
                        r.TotalPrice,
                        r.UserId,
                        r.User?.FullName ?? string.Empty,
                        r.EventId,
                        r.Event?.Name ?? string.Empty
                    ))
                    .ToList();

                return reservationsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the{nameof(GetAllReservations)} service method {ex}");
                throw;
            }
        }
    }
}
