namespace Shared.DataTransferObjects
{
    public record LocationDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string? Address { get; init; }
        public double? GeoLongitude { get; init; }
        public double? GeoLatitude { get; init; }
        public string FullAddress { get; init; }
    }
}
