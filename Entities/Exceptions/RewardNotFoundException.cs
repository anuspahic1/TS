namespace Entities.Exceptions
{
    public sealed class RewardNotFoundException : NotFoundException
    {
        public RewardNotFoundException(Guid rewardId) : base($"The reward with id: {rewardId} doesn't exist in the database.")
        {
        }
    }
}
