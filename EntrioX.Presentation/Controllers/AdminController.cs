using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    //[Authorize(Policy = "AdminOnly")]
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAppStatisticService _appStatisticService;

        private readonly IServiceManager _service; 

        public AdminController(ILogger<AdminController> logger, IAppStatisticService appStatisticService, IServiceManager service)
        {
            _logger = logger;
            _appStatisticService = appStatisticService;
            _service = service;
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetAdminStatistics()
        {
            var statistics = await _appStatisticService.GetAdminStatisticsAsync(trackChanges: false);
            return Ok(statistics);
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetAllEvents([FromQuery] EventParameters eventParameters)
        {
            var events = await _service.EventService.GetAllEventsAsync(eventParameters, trackChanges: false);
            return Ok(events);
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _service.TicketService.GetAllTicketsAsync(trackChanges: false);
            return Ok(tickets);
        }
    }
}