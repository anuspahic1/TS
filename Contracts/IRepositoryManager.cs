namespace Contracts
{
    public interface IRepositoryManager
    {
        IAppUserRepository AppUser { get; }
        IEventRepository Event { get; }
        ILocationRepository Location { get; }
        IReservationRepository Reservation { get; }
        IRewardRepository Reward { get; }
        ITicketRepository Ticket { get; }
        void Save();
    }

}
