using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);
            return Ok(tokenDto);
        }

        [HttpGet("tfa-setup")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))] // remove this when we dont have parameters
        //[Authorize] 
        public async Task<IActionResult> GetTfaSetup()  //security issue, removing email from query param, should use authorize + user.identity
        {
            var email = "admin@entriox.com";
            //var email = "anuspahic1@etf.unsa.ba";
            var tfaSetup = await _service.AuthenticationService.GetTfaSetup(email);
            return Ok(tfaSetup);
        }

        [HttpPost("tfa-setup")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PostTfaSetup([FromBody] TfaSetupDto tfaModel)
        {
            var tfaSetup = await _service.AuthenticationService.PostTfaSetup(tfaModel);
            return Ok(tfaSetup);
        }

        [HttpPost("verify-tfa")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> VerifyTfa([FromBody] VerifyTfaDto dto)
        {
            var email = "admin@entriox.com";
            //var email = "anuspahic1@etf.unsa.ba";
            var token = await _service.AuthenticationService.VerifyTfa(dto, email); // should be used really identity mail, hardcoded for now
            return Ok(token);
        }
    }
}
