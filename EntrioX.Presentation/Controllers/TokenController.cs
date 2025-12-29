using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized();

            try
            {
                var token = await _service.AuthenticationService.RefreshToken(refreshToken);

                return Ok(new
                {
                    accessToken = token.AccessToken
                });
            }
            catch (RefreshTokenBadRequest)
            {
                return Unauthorized();
            }
        }
    }
}
