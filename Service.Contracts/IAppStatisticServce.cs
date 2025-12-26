public interface IAppStatisticService
{
    Task<AdminStatisticsDto> GetAdminStatisticsAsync(bool trackChanges);
}