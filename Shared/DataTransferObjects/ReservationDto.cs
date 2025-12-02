namespace Shared.DataTransferObjects
{
    public record ReservationDto(Guid Id, DateTime CreatedAt, decimal TotalPrice, Guid UserId, string UserFullName, Guid EventId, string EventName);
}
