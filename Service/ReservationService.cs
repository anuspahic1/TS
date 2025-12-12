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

        public async Task<IEnumerable<ReservationDto>> GetReservationsAsync(Guid locationId, Guid eventId, bool trackChanges)
        {
            var location = await _repository.Location.GetLocationAsync(locationId, trackChanges);

            if (location == null)
                throw new LocationNotFoundException(locationId);

            var ev = await _repository.Event.GetEventAsync(locationId, eventId, trackChanges);

            if (ev == null)
                throw new EventNotFoundException(eventId);

            var reservationsFromDb = await _repository.Reservation.GetReservationsAsync(locationId, eventId, trackChanges);

            var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservationsFromDb);

            return reservationsDto;
        }

        public async Task<ReservationDto> GetReservationAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var location = await _repository.Location.GetLocationAsync(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = await _repository.Event.GetEventAsync(locationId, eventId, trackChanges);
                if (ev is null)
                    throw new EventNotFoundException(locationId);

            var reservation = await _repository.Reservation.GetReservationAsync(locationId, eventId, id, trackChanges);
            if (reservation is null)
                throw new ReservationNotFoundException(id);

            var reservationDto = _mapper.Map<ReservationDto>(reservation);

            return reservationDto;
        }

        public async Task<ReservationDto> CreateReservationForEventAsync(Guid locationId, Guid eventId, ReservationForCreationDto reservation, bool trackChanges)
        {
            var location = _repository.Location.GetLocationAsync(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var ev = _repository.Event.GetEventAsync(locationId, eventId, trackChanges);
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
           await _repository.SaveAsync();

            var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity);

            return reservationToReturn;
        }

        public async Task DeleteReservationForEventAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var ev = _repository.Event.GetEventAsync(locationId, eventId, trackChanges);
            if (ev is null)
                throw new EventNotFoundException(eventId);

            var reservationForEvent = await _repository.Reservation.GetReservationAsync(locationId, eventId, id, trackChanges);
            if (reservationForEvent is null)
                throw new ReservationNotFoundException(id);

            _repository.Reservation.DeleteReservation(reservationForEvent);
           await _repository.SaveAsync();
        }
    }
}
