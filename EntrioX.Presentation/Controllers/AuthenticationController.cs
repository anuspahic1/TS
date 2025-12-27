using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Claims;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var result = await _service.AuthenticationService.Authenticate(user);
            return Ok(result);
        }

        [HttpGet("tfa-setup")]
        [Authorize(AuthenticationSchemes = "PreAuth")]
        public async Task<IActionResult> GetTfaSetup()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tfaSetup = await _service.AuthenticationService.GetTfaSetupByUserId(userId);
            return Ok(tfaSetup);
        }

        [HttpPost("tfa-setup")]
        [Authorize(AuthenticationSchemes = "PreAuth")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PostTfaSetup([FromBody] TfaSetupDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _service.AuthenticationService.PostTfaSetup(dto, userId);
            return Ok(result);
        }

        [HttpPost("verify-tfa")]
        [Authorize(AuthenticationSchemes = "PreAuth")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyTfa([FromBody] VerifyTfaDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var stage = User.FindFirst("auth_stage")?.Value;

            var token = await _service.AuthenticationService
                .VerifyTfaByUserId(dto, userId, stage);

            return Ok(token);
        }
    }
}
