using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/users/{userId}/rewards")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RewardsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRewards(Guid userId)
        {
            var rewards = await _service.RewardService.GetRewardsAsync(userId, trackChanges: false);
            return Ok(rewards);
        }

        [HttpGet("{id:guid}", Name = "GetRewardForUser")]
        public async Task<IActionResult> GetReward(Guid userId, Guid id)
        {
            var reward = await _service.RewardService.GetRewardAsync(userId, id, trackChanges: false);
            return Ok(reward);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRewardForUser(Guid userId, [FromBody] RewardForCreationDto reward)
        {
            if (reward is null)
                return BadRequest("RewardForCreationDto is null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var rewardToReturn = await _service.RewardService.CreateRewardForUserAsync(userId, reward, trackChanges: false);

            return CreatedAtRoute("GetRewardForUser", new { userId, id = rewardToReturn.Id }, rewardToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReward(Guid userId, Guid id)
        {
            await _service.RewardService.DeleteRewardForUserAsync(userId, id, trackChanges: false);
            return NoContent();
        }
    }
}
