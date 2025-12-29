namespace Entities.Exceptions
{
    public sealed class ReservationNotFoundException : NotFoundException
    {
        public ReservationNotFoundException(Guid userId) : base($"The user with id: {userId} doesn't exist in the database.")
        {
        }
    }

}
