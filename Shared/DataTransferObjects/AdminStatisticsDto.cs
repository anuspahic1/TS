public record AdminStatisticsDto
{
    public int TotalUsers { get; init; }
    public int TotalEvents { get; init; }
    public int TotalBookings { get; init; }
}