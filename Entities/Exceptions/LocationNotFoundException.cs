namespace Entities.Exceptions
{
    public sealed class LocationNotFoundException : NotFoundException
    {
        public LocationNotFoundException(Guid locationId) : base($"The location with id: {locationId} doesn't exist in the database.")
        {
        }
    }
}
