
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAppStatisticService _appStatisticService;

        public AdminController(ILogger<AdminController> logger, IAppStatisticService appStatisticService)
        {
            _logger = logger;
            _appStatisticService = appStatisticService;
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetAdminStatistics()
        {
            var statistics = await _appStatisticService.GetAdminStatisticsAsync(trackChanges: false);
            return Ok(statistics);
        }
    }
}