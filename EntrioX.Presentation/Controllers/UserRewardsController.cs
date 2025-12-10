using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/users/{userId}/rewards")]
    [ApiController]
    public class UserRewardsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UserRewardsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetRewardsForUser(Guid userId)
        {
            var rewards = _service.RewardService.GetRewardsForUser(userId, false);
            return Ok(rewards);
        }
    }
}
