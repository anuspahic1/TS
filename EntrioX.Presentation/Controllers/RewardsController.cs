using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/rewards")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public RewardsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetRewards()
        {
            var rewards = _service.RewardService.GetAllRewards(trackChanges: false);
            return Ok(rewards);
        }

        [HttpGet("{id:guid}", Name = "RewardById")]
        public IActionResult GetReward(Guid id)
        {
            var reward = _service.RewardService.GetReward(id, trackChanges: false);
            return Ok(reward);
        }

        [HttpPost]
        public IActionResult CreateReward([FromBody] RewardForCreationDto reward)
        {
            if (reward is null)
                return BadRequest("RewardForCreationDto is null.");

            var createdReward = _service.RewardService.CreateReward(reward);
            return CreatedAtRoute("RewardById", new { id = createdReward.Id }, createdReward);
        }
    }
}
