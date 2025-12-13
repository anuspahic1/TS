using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.AppUserService.GetAllUsersAsync(trackChanges: false);
            return Ok(users);
        }

        [HttpGet("{id:guid}", Name = "UserById")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _service.AppUserService.GetUserAsync(id, trackChanges: false);
            return Ok(user);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateUser([FromBody] AppUserForCreationDto user)
        {
            var createdUser = await _service.AppUserService.CreateUserAsync(user);

            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _service.AppUserService.DeleteUserAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] AppUserForUpdateDto user)
        {
            if (user is null)
                return BadRequest("UserForUpdateDto object is null");
            await _service.AppUserService.UpdateUserAsync(id, user, trackChanges: true);
            return NoContent();
        }
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateUser(Guid id, [FromBody] JsonPatchDocument
            <AppUserForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object is null");

            var (userToPatch, userId) = await _service.AppUserService.GetUserForPatchAsync(id, trackChanges: true);
            patchDoc.ApplyTo(userToPatch);
            if (!TryValidateModel(userToPatch))
                return UnprocessableEntity(ModelState);

            await _service.AppUserService.SaveChangesForPatchAsync(userToPatch, userId, trackChanges: true);

            return NoContent();
        }

    }
}
