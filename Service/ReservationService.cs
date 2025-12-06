using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class ReservationService : IReservationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ReservationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ReservationDto> GetAllReservations(bool trackChanges)
        {
            var reservations = _repository.Reservation.GetAllReservations(trackChanges);

            var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservations);

            return reservationsDto;
        }
    }
}
