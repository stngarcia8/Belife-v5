namespace Belife.Domain.Recargo
{
    public sealed class SexNullException : DomainException
    {
        public SexNullException(string message)
            : base(message)
        {
        }
    }
}
