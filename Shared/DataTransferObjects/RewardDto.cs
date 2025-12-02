namespace Shared.DataTransferObjects
{
    public record RewardDto(Guid Id, string Description, string? ImageUrl, DateTime GrantedAt, Guid UserId, string UserFullName);
}
