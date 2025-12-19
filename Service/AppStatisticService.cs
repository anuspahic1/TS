using AutoMapper;
using Contracts;

public sealed class AppStatisticService : IAppStatisticService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public AppStatisticService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        
    }

    public async Task<AdminStatisticsDto> GetAdminStatisticsAsync(bool trackChanges)
    {
        var totalUsers = await _repository.AppUser.GetTotalUsersCount(trackChanges);
        var totalEvents = await _repository.Event.GetTotalEventsCountAsync(trackChanges);
        var totalBookings = await _repository.Reservation.GetTotalBookingsCountAsync(trackChanges);
        var adminStatisticsDto = new AdminStatisticsDto
        {
            TotalUsers = totalUsers,
            TotalEvents = totalEvents,
            TotalBookings = totalBookings
        };

        return adminStatisticsDto;
    }
}