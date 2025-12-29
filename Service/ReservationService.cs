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

            var user = await _repository.AppUser.GetUserAsync(reservation.UserId, trackChanges: true) 
                        ?? throw new UserNotFoundException(reservation.UserId);
            
            var reservationEntity = _mapper.Map<Reservation>(reservation);
            reservationEntity.EventId = eventId;
            reservationEntity.CreatedAt = DateTime.UtcNow;

            reservationEntity.Tickets.Clear(); 

            if (reservation.Tickets != null)
            {
                var ticketIds = reservation.Tickets.Select(t => t.Id).ToList();
                var existingTickets = await _repository.Ticket.GetTicketsByIdsAsync(ticketIds, trackChanges: true);

                foreach (var ticket in existingTickets)
                {
                    if (ticket.ReservationId != null || ticket.IsReserved) 
                        throw new Exception($"Seat {ticket.SeatNumber} is already taken.");
                    ticket.EventId = eventId; 
                    ticket.IsReserved = true;
                    reservationEntity.Tickets.Add(ticket); 
                }
            }

            if (reservation.UseLoyaltyPoints && user.LoyaltyPoints >= 10)
            {
                reservationEntity.TotalPrice *= 0.9m;
                user.LoyaltyPoints -= 10;
            }
            user.LoyaltyPoints += reservation.Tickets?.Count() ?? 0;

            _repository.Reservation.CreateReservationForEvent(eventId, reservationEntity);
            await _repository.SaveAsync(); 

            return _mapper.Map<ReservationDto>(reservationEntity);
        }
public async Task DeleteReservationForEventAsync(Guid locationId, Guid eventId, Guid id, bool trackChanges)
{
    await CheckIfLocationExists(locationId, trackChanges);
    await CheckIfEventExists(locationId, eventId, trackChanges);

    // Moramo pratiti promjene (trackChanges: true) jer mijenjamo Usera i Tickets
    var reservation = await GetReservationForEventAndCheckIfItExists(locationId, eventId, id, trackChanges: true);

    var user = await _repository.AppUser.GetUserAsync(reservation.UserId, trackChanges: true)
                ?? throw new UserNotFoundException(reservation.UserId);

    // 1. LOGIKA ZA LOYALTY BODOVE
    // Ako je u toj rezervaciji korišten popust (pretpostavljamo po TotalPrice logici ili ako imaš polje)
    // Ovdje koristimo istu logiku kao u Create: ako je iskorišteno 10, vrati ih korisniku.
    // Napomena: Možda bi bilo dobro u Reservation entitet uvesti bool "WasLoyaltyUsed"
    
    // Oduzimamo bodove koje je dobio ovom kupovinom (1 karta = 1 bod)
    int pointsEarned = reservation.Tickets?.Count ?? 0;
    user.LoyaltyPoints -= pointsEarned;

    // Ako je korisnik iskoristio bodove pri kupovini, moramo mu ih vratiti
    // (Ovdje bi bilo idealno provjeriti da li je plaćena cijena bila snižena, 
    // ali za sada pratimo logiku: ako su mu oduzeti pri kreiranju, ovdje ih vraćamo)
    // user.LoyaltyPoints += 10; // Ovu liniju otkomentariši ako pratiš fiksno trošenje 10 bodova

    // 2. LOGIKA ZA KARTE (Oslobađanje sjedišta)
    if (reservation.Tickets != null)
    {
        foreach (var ticket in reservation.Tickets)
        {
            ticket.IsReserved = false;
            ticket.ReservationId = null;
        }
    }

    // 3. BRISANJE REZERVACIJE
    _repository.Reservation.DeleteReservation(reservation);
    
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
        public async Task<IEnumerable<EventVisitorDto>> GetEventVisitorsAsync(
             Guid locationId, Guid eventId, bool trackChanges)
        {

            await CheckIfLocationExists(locationId, trackChanges);
            await CheckIfEventExists(locationId, eventId, trackChanges);

            var visitors = await _repository.Reservation
                .GetEventVisitorsAsync(locationId, eventId, trackChanges);

            return visitors;
        }

    }
}
