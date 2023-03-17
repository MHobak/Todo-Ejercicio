using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Todo.Client.Exceptions;
using Todo.Client.Services.Interfaces;

namespace Todo.Client.Components.Meta{
    public class AgregarEditarMetaDialogComponentBase : ComponentBase
    {
        [CascadingParameter] 
        public MudDialogInstance MudDialog { get; set; }
        
        [Inject]
        protected IMetaService MetaService { get; set; }

        [Inject]
        protected ISnackbar Snackbar { get; set; }

        [Parameter]
        public Func<Task> OnSuccessCreateEditMethod { get; set; }
        
        [Parameter]
        public bool Actualizar { get; set; } = false;

        [Parameter]
        public MetaDto Model { get; set; } = new();

        protected IDictionary<string, string[]>? validationErrors;

        protected async Task Submit()
        {
            validationErrors = null;

            if (Actualizar)
            {
                await UpdateMeta();
            }
            else 
            {
                await CreateMeta();
            }

            StateHasChanged();
            
            if (validationErrors == null)
            {
                MudDialog.Close(DialogResult.Ok(true));   
            }
        }
        protected void Cancel() => MudDialog.Cancel();

        protected async Task CreateMeta()
        {
            try
            {
                var result = await MetaService.Create(Model);
                if (result != null)
                {
                    Model = result;
                    Snackbar.Add("¡Meta registrada!", Severity.Success);
                    OnSuccessCreateEditMethod?.Invoke();
                }
                else
                {
                    Snackbar.Add("No se registró la meta", Severity.Warning);
                }
            }
            catch (ValidationRuleException ex)
            {
                validationErrors = ex.Errors;
            }
            catch (System.Exception ex)
            {
                Snackbar.Add($"No se registró la meta: {ex.Message}", Severity.Error);
            }
        }

        protected async Task UpdateMeta()
        {
            try
            {
                var result = await MetaService.Update(Model);
                if (result != null)
                {
                    Model = result;
                    Snackbar.Add("¡Meta actualizada!", Severity.Success);
                    OnSuccessCreateEditMethod?.Invoke();
                }
                else
                {
                    Snackbar.Add("No se actualizó la meta", Severity.Warning);
                }
            }
            catch (ValidationRuleException ex)
            {
                validationErrors = ex.Errors;
            }
            catch (System.Exception ex)
            {
                Snackbar.Add($"No se actualizó la meta: {ex.Message}", Severity.Error);
            }
        }
    }
}