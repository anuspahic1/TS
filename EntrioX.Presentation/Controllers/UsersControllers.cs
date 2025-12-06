using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UsersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _service.AppUserService.GetAllUsers(trackChanges: false);
            return Ok(users);
        }
    }
}
