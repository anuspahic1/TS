namespace Entities.Exceptions
{
    public sealed class TfaBadRequest : BadRequestException
    {
        public TfaBadRequest() : base("User does not exist")
        {
        }
    }
}

