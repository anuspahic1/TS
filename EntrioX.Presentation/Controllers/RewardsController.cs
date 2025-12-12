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
        public IActionResult GetRewards(Guid userId)
        {
            var rewards = _service.RewardService.GetRewards(userId, trackChanges: false);
            return Ok(rewards);
        }

        [HttpGet("{id:guid}", Name = "GetRewardForUser")]
        public IActionResult GetReward(Guid userId, Guid id)
        {
            var reward = _service.RewardService.GetReward(userId, id, trackChanges: false);
            return Ok(reward);
        }

        [HttpPost]
        public IActionResult CreateRewardForUser(Guid userId, [FromBody] RewardForCreationDto reward)
        {
            if (reward is null)
                return BadRequest("RewardForCreationDto is null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var rewardToReturn = _service.RewardService.CreateRewardForUser(userId, reward, trackChanges: false);

            return CreatedAtRoute("GetRewardForUser", new { userId, id = rewardToReturn.Id }, rewardToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteReward(Guid userId, Guid id)
        {
            _service.RewardService.DeleteRewardForUser(userId, id, trackChanges: false);
            return NoContent();
        }
    }
}
