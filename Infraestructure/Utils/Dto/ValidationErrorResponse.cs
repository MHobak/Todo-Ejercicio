namespace Infraestructure.Utils.Dto
{
    public class ValidationErrorResponse
    {
        public string Message { get; set; } = "Ha ocurrido uno o mas errores.";
        public IDictionary<string, string[]> Errors { get; set; }
    }
}