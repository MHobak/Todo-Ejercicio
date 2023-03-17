using Domain.DTOs;
using FluentValidation;
using Persistence.Interfaces.Repository;

namespace Service.Validators
{
    public class MetaValidator : AbstractValidator<MetaDto>
    {
        private readonly IMetaRepository repository;

        public MetaValidator(IMetaRepository repository)
        {
             this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("es-MX", false);

            RuleFor(v => v.Nombre)
                .Length(1, 80)
                .NotEmpty()
                .NotNull()
                .MustAsync(MetaNameAlreadyExist)
                .WithMessage("Ya existe una meta con este nombre")
                .WithName("El nombre");
        }

        private async Task<bool> MetaNameAlreadyExist(string name, CancellationToken token) =>
            !await repository.Any(x => x.Nombre.Trim().ToLower() == name.Trim().ToLower());
        
    }
}