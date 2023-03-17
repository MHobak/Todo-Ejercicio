using FluentValidation.Results;

namespace Infraestructure.Extensions.ValidationErros
{
    public static class ValidationsErrorsExtensions
    {
        public static Dictionary<string, string[]> GroupValidationErrors(this IEnumerable<ValidationFailure> failures)
        {
            var errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

            return errors;
        }
    }
}