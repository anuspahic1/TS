using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;

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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRewardForUser(Guid userId, [FromBody] RewardForCreationDto reward)
        {
            var rewardToReturn = await _service.RewardService.CreateRewardForUserAsync(userId, reward, trackChanges: false);

            return CreatedAtRoute("GetRewardForUser", new { userId, id = rewardToReturn.Id }, rewardToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReward(Guid userId, Guid id)
        {
            await _service.RewardService.DeleteRewardForUserAsync(userId, id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateRewardForUser(Guid userId, Guid id, [
            FromBody] RewardForUpdateDto reward)
        {
            await _service.RewardService.UpdateRewardForUserAsync(userId, id, reward, trackChanges: true);
            return NoContent();
        }
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateRewardForUser(Guid userId, Guid id

            , [FromBody] JsonPatchDocument<RewardForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object is null");

            var (rewardToPatch, _, _) = await _service.RewardService
                .GetRewardForPatchAsync(userId, id, trackChanges: true);

            patchDoc.ApplyTo(rewardToPatch);
            if (!TryValidateModel(rewardToPatch))
                return UnprocessableEntity(ModelState);

            await _service.RewardService.SaveChangesForPatchAsync(rewardToPatch, userId, id, trackChanges: true);

            return NoContent();
        }
    }
}
