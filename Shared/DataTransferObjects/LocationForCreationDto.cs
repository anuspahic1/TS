namespace Shared.DataTransferObjects
{
    public record LocationForCreationDto
    {
        public string Name { get; init; }
        public string? Address { get; init; }
        public double? GeoLongitude { get; init; }
        public double? GeoLatitude { get; init; }
        public IEnumerable<EventForCreationDto>? Events { get; init; }
    }
}
