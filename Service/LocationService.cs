using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class LocationService : ILocationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public LocationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<LocationDto> GetAllLocations(bool trackChanges)
        {
            var locations = _repository.Location.GetAllLocations(trackChanges);

            var locationsDto = _mapper.Map<IEnumerable<LocationDto>>(locations);

            return locationsDto;
        }

        public LocationDto GetLocation(Guid locationId, bool trackChanges)
        {
            var location = _repository.Location.GetLocation(locationId, trackChanges);
            if (location is null)
                throw new LocationNotFoundException(locationId);

            var locationDto = _mapper.Map<LocationDto>(location);
            return locationDto;
        }
    }
}
