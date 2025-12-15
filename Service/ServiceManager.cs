using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _appUserService = new Lazy<IAppUserService>(() => new AppUserService(repository, logger, mapper));
            _eventService = new Lazy<IEventService>(() => new EventService(repository, logger, mapper));
            _locationService = new Lazy<ILocationService>(() => new LocationService(repository, logger, mapper));
            _reservationService = new Lazy<IReservationService>(() => new ReservationService(repository, logger, mapper));
            _rewardService = new Lazy<IRewardService>(() => new RewardService(repository, logger, mapper));
            _ticketService = new Lazy<ITicketService>(() => new TicketService(repository, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
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
            get { return _rewardService.Value; }
        }
        public ITicketService TicketService
        {
            get { return _ticketService.Value; }
        }
        public IAuthenticationService AuthenticationService
        {
            get { return _authenticationService.Value; }
        }
    }
}
