namespace Belife.Domain.Recargo
{
    public sealed class InvalidDateException : DomainException
    {
        public InvalidDateException(string message)
            : base(message)
        {
        }
    }
}
