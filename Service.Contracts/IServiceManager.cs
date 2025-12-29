namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAppUserService AppUserService { get; }
        IEventService EventService { get; }
        ILocationService LocationService { get; }
        IReservationService ReservationService { get; }
        IRewardService RewardService { get; }
        ITicketService TicketService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
