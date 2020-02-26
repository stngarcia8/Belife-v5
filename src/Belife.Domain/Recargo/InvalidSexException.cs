namespace Belife.Domain.Recargo
{
    public sealed class InvalidSexException : DomainException
    {
        public InvalidSexException(string message)
            : base(message)
        {
        }
    }
}
