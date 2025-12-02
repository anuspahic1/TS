using Entities.Models;

namespace Contracts
{
    public interface IRewardRepository
    {
        IEnumerable<Reward> GetAllRewards(bool trackChanges);
    }
}
