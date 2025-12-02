using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class LocationService : ILocationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public LocationService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<LocationDto> GetAllLocations(bool trackChanges)
        {
            try
            {
                var locations = _repository.Location.GetAllLocations(trackChanges);

                var locationsDto = locations.Select(l =>
                    new LocationDto(
                        l.Id,
                        l.Name,
                        l.Address,
                        l.GeoLongitude,
                        l.GeoLatitude,
                        $"{l.Name}, {l.Address}"
                    ))
                    .ToList();

                return locationsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the{nameof(GetAllLocations)} service method {ex}");
                throw;
            }
        }
    }
}
