using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
            try
            {
                var rewards = _service.RewardService.GetAllRewards(trackChanges: false);
                return Ok(rewards);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
