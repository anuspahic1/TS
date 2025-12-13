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

        public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync(bool trackChanges)
        {
            var locations = await _repository.Location.GetAllLocationsAsync(trackChanges);

            var locationsDto = _mapper.Map<IEnumerable<LocationDto>>(locations);

            return locationsDto;
        }

        public async Task<LocationDto> GetLocationAsync(Guid locationId, bool trackChanges)
        {
            var location = await GetLocationAndCheckIfItExist(locationId, trackChanges);

            var locationDto = _mapper.Map<LocationDto>(location);
            return locationDto;
        }

        public async Task<LocationDto> CreateLocationAsync(LocationForCreationDto location)
        {
            var locationEntity = _mapper.Map<Location>(location);

            _repository.Location.CreateLocation(locationEntity);
            await _repository.SaveAsync();

            var locationToReturn = _mapper.Map<LocationDto>(locationEntity);

            return locationToReturn;
        }

        public async Task DeleteLocationAsync(Guid locationId, bool trackChanges)
        {
            var location = await GetLocationAndCheckIfItExist(locationId, trackChanges);

            _repository.Location.DeleteLocation(location);
            await _repository.SaveAsync();
        }

        private async Task<Location> GetLocationAndCheckIfItExist(Guid id, bool trackChanges)
        {
            var location = await _repository.Location.GetLocationAsync(id, trackChanges);
            return location is null ? throw new LocationNotFoundException(id) : location;
        }

        public async Task UpdateLocationAsync(Guid locationId, LocationForUpdateDto locationForUpdate, bool trackChanges)
        {
            var locationEntity = await GetLocationAndCheckIfItExist(locationId, trackChanges) ?? throw new LocationNotFoundException(locationId);
            _mapper.Map(locationForUpdate, locationEntity);
            await _repository.SaveAsync();
        }
        public async Task<(LocationForUpdateDto locationToPatch, Guid locationId)> GetLocationForPatchAsync(Guid locationId, bool trackChanges)
        {
            var locationEntity = await GetLocationAndCheckIfItExist(locationId, trackChanges);

            var locationToPatch = _mapper.Map<LocationForUpdateDto>(locationEntity);

            return (locationToPatch, locationId);
        }
        public async Task SaveChangesForPatchAsync(LocationForUpdateDto locationToPatch, Guid locationId, bool trackChanges)
        {
            var locationEntity = await GetLocationAndCheckIfItExist(locationId, trackChanges);

            _mapper.Map(locationToPatch, locationEntity);

            await _repository.SaveAsync();
        }
        
    }
}
