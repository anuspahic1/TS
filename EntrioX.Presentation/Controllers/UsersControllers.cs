using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

        [HttpGet("{id:guid}", Name = "UserById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _service.AppUserService.GetUser(id, trackChanges: false);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] AppUserForCreationDto user)
        {
            if (user is null)
                return BadRequest("AppUserForCreationDto is null.");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdUser = _service.AppUserService.CreateUser(user);
            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            _service.AppUserService.DeleteUser(id, trackChanges: false);
            return NoContent();
        }
    }
}
