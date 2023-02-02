namespace VendasWebCore.Services.Excepction
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string? message) : base(message)
        {
        }
    }
}
