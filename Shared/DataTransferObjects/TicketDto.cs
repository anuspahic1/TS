namespace Shared.DataTransferObjects
{
    public record TicketDto(Guid Id, decimal Price, string? SeatNumber, bool IsReserved, string? QRCode, Guid EventId, string EventName);
}
