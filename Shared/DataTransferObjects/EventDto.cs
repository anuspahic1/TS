namespace Shared.DataTransferObjects
{
    public record EventDto(Guid Id, string Name, string? Description, DateTime Date, string LocationName);
}
