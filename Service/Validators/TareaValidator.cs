using Domain.DTOs;
using FluentValidation;
using Persistence.Interfaces.Repository;

namespace Service.Validators
{
    public class TareaValidator : AbstractValidator<TareaDto>
    {
        private readonly ITareaRepository repository;

        public TareaValidator(ITareaRepository repository)
        {
             this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("es-MX", false);

            RuleFor(v => v.Nombre)
                .Length(1, 80)
                .NotEmpty()
                .NotNull()
                .MustAsync(TareaNameAlreadyExist)
                .WithMessage("Ya existe una tarea con este nombre")
                .WithName("El nombre");
        }

        private async Task<bool> TareaNameAlreadyExist(string name, CancellationToken token) =>
            !await repository.Any(x => x.Nombre.Trim().ToLower() == name.Trim().ToLower());
    }
}