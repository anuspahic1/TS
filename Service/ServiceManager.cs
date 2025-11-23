using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAppUserService> _appUserService;
        private readonly Lazy<IEventService> _eventService;
        private readonly Lazy<ILocationService> _locationService;
        private readonly Lazy<IReservationService> _reservationService;
        private readonly Lazy<IRewardService> _rewardService;
        private readonly Lazy<ITicketService> _ticketService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _appUserService = new Lazy<IAppUserService>(() => new AppUserService(repository, logger));
            _eventService = new Lazy<IEventService>(() => new EventService(repository, logger));
            _locationService = new Lazy<ILocationService>(() => new LocationService(repository, logger));
            _reservationService = new Lazy<IReservationService>(() => new ReservationService(repository, logger));
            _rewardService = new Lazy<IRewardService>(() => new RewardService(repository, logger));
            _ticketService = new Lazy<ITicketService>(() => new TicketService(repository, logger));
        }
        public IAppUserService AppUserService
        {
            get { return _appUserService.Value; }
        }
        public IEventService EventService
        {
            get { return _eventService.Value; }
        }
        public ILocationService LocationService
        {
            get { return _locationService.Value; }
        }
        public IReservationService ReservationService
        {
            get { return _reservationService.Value; }
        }
        public IRewardService RewardService
        {
            get { return _rewardService.Value;  }
        }
        public ITicketService TicketService
        {
            get { return _ticketService.Value; }
        }
    }
}
