using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

        public IEnumerable<ReservationDto> GetReservationsForEvent(Guid eventId, bool trackChanges)
        {
            var ev = _repository.Event.GetEvent(eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var reservations = _repository.Reservation.GetReservationsForEvent(eventId, trackChanges);
            var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservations);

            return reservationsDto;
        }

        public IEnumerable<ReservationDto> GetReservationsForUser(Guid userId, bool trackChanges)
        {
            var user = _repository.AppUser.GetUser(userId, trackChanges);
            if (user is null)
                throw new UserNotFoundException(userId);

            var reservations = _repository.Reservation.GetReservationsForUser(userId, trackChanges);
            var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservations);

            return reservationsDto;
        }

        public ReservationDto GetReservation(Guid reservationId, bool trackChanges)
        {

            var reservation = _repository.Reservation.GetReservation(reservationId, trackChanges);
            if (reservation is null)
                throw new ReservationNotFoundException(reservationId);

            var reservationDto = _mapper.Map<ReservationDto>(reservation);
            return reservationDto;
        }
    }
}
