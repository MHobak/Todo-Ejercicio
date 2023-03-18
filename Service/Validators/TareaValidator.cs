using Domain.DTOs;
using FluentValidation;
using Persistence.Interfaces.Repository;

namespace Service.Validators
{
    public class TareaValidator : AbstractValidator<TareaDto>
    {
        private readonly ITareaRepository tareaRepository;
        private readonly IMetaRepository metaRepository;

        public TareaValidator(ITareaRepository tareaRepository, IMetaRepository metaRepository)
        {
             this.tareaRepository = tareaRepository ?? throw new ArgumentNullException(nameof(tareaRepository));
             this.metaRepository = metaRepository ?? throw new ArgumentNullException(nameof(metaRepository));

            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("es-MX", false);

            RuleFor(v => v.Nombre)
                .Length(1, 80)
                .NotEmpty()
                .NotNull()
                .MustAsync(TareaNameAlreadyExist)
                .WithMessage("Ya existe una tarea con este nombre")
                .WithName("El nombre");
            
            RuleFor(v => v.MetaId)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(MetaExist)
                .WithMessage("La meta asociada no existe")
                .WithName("El nombre");
        }

        private async Task<bool> TareaNameAlreadyExist(string name, CancellationToken token) =>
            !await tareaRepository.Any(x => x.Nombre.Trim().ToLower() == name.Trim().ToLower());

        private async Task<bool> MetaExist(int metaId, CancellationToken token) =>
            await metaRepository.Any(x => x.Id == metaId); //valida que exista la meta
    }
}