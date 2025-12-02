namespace Shared.DataTransferObjects
{
    public record LocationDto(Guid Id, string Name, string? Address, double? GeoLongitude, double? GeoLatitude, string FullAddress);
}
