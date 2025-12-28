using EntrioX.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace EntrioX.Presentation.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public LocationsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _service.LocationService.GetAllLocationsAsync(trackChanges: false);
            return Ok(locations);
        }

        [HttpGet("{id:guid}", Name = "LocationById")]
        public async Task<IActionResult> GetLocation(Guid id)
        {
            var location = await _service.LocationService.GetLocationAsync(id, trackChanges: false);
            return Ok(location);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateLocation([FromBody] LocationForCreationDto location)
        {
            var createdLocation = await _service.LocationService.CreateLocationAsync(location);

            return CreatedAtRoute("LocationById", new { id = createdLocation.Id }, createdLocation);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            await _service.LocationService.DeleteLocationAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateLocation(Guid id, [FromBody] LocationForUpdateDto location)
        {
            if (location is null)
                return BadRequest("LocationForUpdateDto object is null");
            await _service.LocationService.UpdateLocationAsync(id, location, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> PartiallyUpdateLocation(Guid id, [FromBody] JsonPatchDocument
            <LocationForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object is null");

            var (locationToPatch, locationId) = await _service.LocationService
                .GetLocationForPatchAsync(id, trackChanges: true);

            patchDoc.ApplyTo(locationToPatch);

            if (!TryValidateModel(locationToPatch))
                return UnprocessableEntity(ModelState);

            await _service.LocationService.SaveChangesForPatchAsync(locationToPatch, locationId, trackChanges: true);

            return NoContent();
        }
    }
}
