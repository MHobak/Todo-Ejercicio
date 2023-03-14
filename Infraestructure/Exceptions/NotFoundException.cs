namespace Infraestructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Registro no encontrado."){}
        public NotFoundException(string? message) : base(message){}
    }
}