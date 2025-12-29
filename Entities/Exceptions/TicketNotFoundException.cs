namespace Entities.Exceptions
{
    public sealed class TicketNotFoundException : NotFoundException
    {
        public TicketNotFoundException(Guid ticketId) : base($"The ticket with id: {ticketId} doesn't exist in the database.")
        {
        }
    }
}
