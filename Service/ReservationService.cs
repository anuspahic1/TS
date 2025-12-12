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

        public IEnumerable<ReservationDto> GetReservations(Guid locationId, Guid eventId, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);

            if (location == null)
                throw new LocationNotFoundException(locationId);

            var ev = _repository.Event.GetEvent(locationId, eventId, trackChanges);

            if (ev == null)
                throw new EventNotFoundException(eventId);

            var reservationsFromDb = _repository.Reservation.GetReservations(locationId, eventId, trackChanges);

            var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservationsFromDb);

            return reservationsDto;
        }

        public ReservationDto GetReservation(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = _repository.Event.GetEvent(locationId, eventId, trackChanges);
                if (ev is null)
                    throw new EventNotFoundException(locationId);

            var reservation = _repository.Reservation.GetReservation(locationId, eventId, id, trackChanges);
            if (reservation is null)
                throw new ReservationNotFoundException(id);

            var reservationDto = _mapper.Map<ReservationDto>(reservation);

            return reservationDto;
        }

        public ReservationDto CreateReservationForEvent(Guid locationId, Guid eventId, ReservationForCreationDto reservation, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = _repository.Event.GetEvent(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var reservationEntity = _mapper.Map<Reservation>(reservation);

            if (reservationEntity.Tickets != null)
            {
                foreach (var ticket in reservationEntity.Tickets)
                {
                    ticket.EventId = eventId;
                    ticket.Reservation = reservationEntity;
                }
            }

            _repository.Reservation.CreateReservationForEvent(eventId, reservationEntity);
            _repository.Save();

            var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity);

            return reservationToReturn;
        }

        public void DeleteReservationForEvent(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var ev = _repository.Event.GetEvent(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var reservationForEvent = _repository.Reservation.GetReservation(locationId, eventId, id, trackChanges);
            if (reservationForEvent is null)
                throw new ReservationNotFoundException(id);

            _repository.Reservation.DeleteReservation(reservationForEvent);
            _repository.Save();
        }
    }
}
