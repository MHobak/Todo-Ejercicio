namespace Todo.Client.Exceptions
{
    public class ValidationRuleException : Exception
    {
        public readonly IDictionary<string, string[]> Errors;

        public ValidationRuleException(): base("Se han producido uno o más errores de validación")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationRuleException(IDictionary<string, string[]> errors) 
        : base("Se han producido uno o más errores de validación")
        {
            Errors = errors;
        }
    }
}