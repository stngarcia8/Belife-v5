namespace Belife.Domain.Recargo
{
    public sealed class DateNullException : DomainException
    {
        public DateNullException(string message)
            : base(message)
        {
        }
    }
}
