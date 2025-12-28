using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;
using System.Security.Claims;

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
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetUsers([FromQuery] UserParameters userParameters)
        {
            var users = await _service.AppUserService.GetAllUsersAsync(userParameters, trackChanges: false);
            return Ok(users);
        }

        [HttpGet("{id:guid}", Name = "UserById")]
        [Authorize]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var currentUserId = GetCurrentUserId();
            var isAdmin = User.IsInRole(AppRoles.Administrator);

            if (id != currentUserId && !isAdmin)
                return Forbid();

            var user = await _service.AppUserService.GetUserAsync(id, trackChanges: false);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateUser([FromBody] AppUserForCreationDto user)
        {
            var createdUser = await _service.AppUserService.CreateUserAsync(user);

            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _service.AppUserService.DeleteUserAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] AppUserForUpdateDto user)
        {
            if (user is null)
                return BadRequest("UserForUpdateDto object is null");

            var currentUserId = GetCurrentUserId();
            var isAdmin = User.IsInRole(AppRoles.Administrator);

            if (id != currentUserId && !isAdmin)
                return Forbid();
            await _service.AppUserService.UpdateUserAsync(id, user, trackChanges: true);
            return NoContent();
        }

        [HttpPost("{id:guid}/roles")]
        [Authorize(Policy = "AdminOnly")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUserRole(Guid id, [FromBody] string roleName)
        {
            await _service.AppUserService.UpdateUserRoleAsync(id, roleName);
            
            return NoContent();
        }


        [HttpPatch("{id:guid}")]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PartiallyUpdateUser(Guid id, [FromBody] JsonPatchDocument
            <AppUserForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object is null");

            var currentUserId = GetCurrentUserId();
            var isAdmin = User.IsInRole(AppRoles.Administrator);

            if (id != currentUserId && !isAdmin)
                return Forbid();

            var (userToPatch, userId) = await _service.AppUserService.GetUserForPatchAsync(id, trackChanges: true);
            patchDoc.ApplyTo(userToPatch);
            if (!TryValidateModel(userToPatch))
                return UnprocessableEntity(ModelState);

            await _service.AppUserService.SaveChangesForPatchAsync(userToPatch, userId, trackChanges: true);

            return NoContent();
        }

        [HttpGet("{userId}/reservations")]
        [Authorize] 
        public async Task<IActionResult> GetUserReservations(Guid userId)
        {
            var currentUserId = GetCurrentUserId();
            var isAdmin = User.IsInRole(AppRoles.Administrator);
            
            if (userId != currentUserId && !isAdmin)
                return Forbid();
            
            var reservations = await _service.ReservationService.GetReservationsByUserIdAsync(userId, trackChanges: false);
            return Ok(reservations);
        }
        
        [HttpGet("{userId}/tickets")]
        [Authorize]
        public async Task<IActionResult> GetUserTickets(Guid userId)
        {
            var currentUserId = GetCurrentUserId();
            var isAdmin = User.IsInRole(AppRoles.Administrator);
            
            if (userId != currentUserId && !isAdmin)
                return Forbid();
            
            var tickets = await _service.TicketService.GetTicketsByUserIdAsync(userId, trackChanges: false);
            return Ok(tickets);
        }
        
        [HttpGet("{userId}/dashboard")]
            [Authorize]
            public async Task<IActionResult> GetUserDashboard(Guid userId)
            {
                var currentUserId = GetCurrentUserId();
                var isAdmin = User.IsInRole(AppRoles.Administrator);
                
                if (userId != currentUserId && !isAdmin)
                    return Forbid();

                var user = await _service.AppUserService.GetUserAsync(userId, trackChanges: false);
                var reservations = await _service.ReservationService.GetReservationsByUserIdAsync(userId, trackChanges: false);
                var tickets = await _service.TicketService.GetTicketsByUserIdAsync(userId, trackChanges: false);
                
                var dashboardData = new
                {
                    User = user,
                    Reservations = reservations,
                    Tickets = tickets,
                    Stats = new
                    {
                        TotalReservations = reservations.Count(),
                        ActiveTickets = tickets.Count(t => t.EventDate > DateTime.UtcNow),
                        TotalSpent = reservations.Sum(r => r.TotalPrice)
                    }
                };
                
                return Ok(dashboardData);
            }
        
        private Guid GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
                throw new UnauthorizedAccessException("Invalid user ID in token");
            
            return userId;
        }

    }
}
