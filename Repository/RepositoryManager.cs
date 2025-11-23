using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IAppUserRepository> _appUserRepository;
        private readonly Lazy<IEventRepository> _eventRepository;
        private readonly Lazy<ILocationRepository> _locationRepository;
        private readonly Lazy<IReservationRepository> _reservationRepository;
        private readonly Lazy<IRewardRepository> _rewardRepository;
        private readonly Lazy<ITicketRepository> _ticketRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _appUserRepository = new Lazy<IAppUserRepository>(() => new AppUserRepository(repositoryContext));
            _eventRepository = new Lazy<IEventRepository>(() => new EventRepository(repositoryContext));
            _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
            _reservationRepository = new Lazy<IReservationRepository>(() => new ReservationRepository(repositoryContext));
            _rewardRepository = new Lazy<IRewardRepository>(() => new RewardRepository(repositoryContext));
            _ticketRepository = new Lazy<ITicketRepository>(() => new TicketRepository(repositoryContext));
        }

        public IAppUserRepository AppUser
        {
            get { return _appUserRepository.Value; }    
        }

        public IEventRepository Event
        {
            get { return _eventRepository.Value; }
        }

        public ILocationRepository Location
        {
            get { return _locationRepository.Value; }
        }

        public IReservationRepository Reservation
        {
            get { return _reservationRepository.Value; }
        }

        public IRewardRepository Reward
        {
            get { return _rewardRepository.Value; }
        }
        public ITicketRepository Ticket
        {
            get { return _ticketRepository.Value; }
        }
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
