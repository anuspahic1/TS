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
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var reservationsFromDb = await _repository.Reservation.GetReservationsAsync(locationId, eventId, trackChanges);

            var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservationsFromDb);

            return reservationsDto;
        }

        public async Task<ReservationDto> GetReservationAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var reservation = await GetReservationForEventAndCheckIfItExists(locationId, eventId, id, trackChanges);

            var reservationDto = _mapper.Map<ReservationDto>(reservation);

            return reservationDto;
        }

        public async Task<ReservationDto> CreateReservationForEventAsync(Guid locationId, Guid eventId, ReservationForCreationDto reservation, bool trackChanges)
        {
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

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
            await CheckIfLocationExists(locationId, trackChanges);

            await CheckIfEventExists(locationId, eventId, trackChanges);

            var reservationForEvent = await GetReservationForEventAndCheckIfItExists(locationId, eventId, id, trackChanges);

            _repository.Reservation.DeleteReservation(reservationForEvent);
            await _repository.SaveAsync();
        }

        private async Task CheckIfLocationExists(Guid id, bool trackChanges)
        {
            _ = await _repository.Location.GetLocationAsync(id, trackChanges) ?? throw new LocationNotFoundException(id);
        }

        private async Task CheckIfEventExists(Guid locationId, Guid id, bool trackChanges)
        {
            _ = await _repository.Event.GetEventAsync(locationId, id, trackChanges) ?? throw new EventNotFoundException(id);
        }

        private async Task<Reservation> GetReservationForEventAndCheckIfItExists(Guid locationId, Guid eventId, Guid id, bool trackChanges)
        {
            var reservationDb = await _repository.Reservation.GetReservationAsync(locationId, eventId, id, trackChanges);
            return reservationDb is null ? throw new ReservationNotFoundException(id) : reservationDb;
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsByUserIdAsync(Guid userId, bool trackChanges)
        {
   
            var user = await _repository.AppUser.GetUserAsync(userId, trackChanges: false);
            if (user == null)
                throw new UserNotFoundException(userId);
            

            var reservations = await _repository.Reservation
                .GetReservationsByUserIdWithDetailsAsync(userId, trackChanges);
            
 
            var reservationsDto = reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                CreatedAt = r.CreatedAt,
                TotalPrice = r.TotalPrice,
                UserId = r.UserId,
                UserFullName = r.User?.FullName ?? "Unknown",
                EventId = r.EventId,
                EventName = r.Event?.Name ?? "Unknown Event",
                EventDate = r.Event?.EventDate ?? DateTime.MinValue,
                TicketsCount = r.Tickets?.Count ?? 0,
                Status = DetermineReservationStatus(r.Event?.EventDate)
            });
            
            return reservationsDto;
        }
        
        private string DetermineReservationStatus(DateTime? eventDate)
        {
            if (!eventDate.HasValue)
                return "completed";
                
            if (eventDate.Value < DateTime.UtcNow)
                return "completed";
            else
                return "upcoming";
        }
    }
}
