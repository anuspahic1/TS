using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EventsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEvents() 
        {
            var events = _service.EventService.GetAllEvents(trackChanges: false);
            return Ok(events);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEvent(Guid id)
        {
            var ev = _service.EventService.GetEvent(id, trackChanges: false);
            return Ok(ev);
        }
    }
}
