using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Claims;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/users/{userId}/events")]
    [ApiController]
    public class UserEventsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserEventsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventsForUser(Guid userId)
        {
            var events = await _service.EventService.GetEventsForUserAsync(userId, trackChanges: false);
            return Ok(events);
        }
    }
}
