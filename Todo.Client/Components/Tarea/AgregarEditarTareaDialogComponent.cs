using Domain.DTOs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Todo.Client.Exceptions;
using Todo.Client.Services.Interfaces;

namespace Todo.Client.Components.Meta
{
    public class AgregarEditarTareaDialogComponentBase : ComponentBase
    {
        [CascadingParameter] 
        public MudDialogInstance mudDialog { get; set; }
        
        [Parameter] 
        public Func<Task> RecargarMetas { get; set; }
        
        [Inject]
        protected ITareaService tareaService { get; set; }

        [Inject]
        protected ISnackbar snackbar { get; set; }

        [Parameter]
        public EventCallback OnSuccessCreateEditMethod { get; set; }
        
        [Parameter]
        public bool Actualizar { get; set; } = false;

        [Parameter]
        public int TareaId { get; set; } = new();

        [Parameter]
        public int MetaId { get; set; } = new();

        public TareaDto model { get; set; } = new();

        protected IDictionary<string, string[]>? validationErrors;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (TareaId <= 0)return;
                
                var tarea = await tareaService.GetById(TareaId);
                model = tarea;
                StateHasChanged();
                
                if (tarea == null)
                {
                    snackbar.Add("No se encontró la tarea", Severity.Warning);
                    return;
                }
            }
            catch (System.Exception ex)
            {
                snackbar.Add($"No se pudo consultar la tarea: {ex.Message}", Severity.Error);
            }
        }

        protected async Task Submit()
        {
            validationErrors = null;

            if (Actualizar)
            {
                await UpdateTarea();
            }
            else 
            {
                await CreateTarea();
            }

            StateHasChanged();
            
            if (validationErrors == null)
            {
                mudDialog.Close(DialogResult.Ok(true));   
            }
        }
        protected void Cancel() => mudDialog.Cancel();

        protected async Task CreateTarea()
        {
            try
            {
                model.MetaId = MetaId;
                var result = await tareaService.Create(model);
                if (result != null)
                {
                    model = result;
                    snackbar.Add("¡Tarea registrada!", Severity.Success);
                    await OnSuccessCreateEditMethod.InvokeAsync();
                    await RecargarMetas?.Invoke();
                }
                else
                {
                    snackbar.Add("No se registró la tarea", Severity.Warning);
                }
            }
            catch (ValidationRuleException ex)
            {
                validationErrors = ex.Errors;
            }
            catch (System.Exception ex)
            {
                snackbar.Add($"No se registró la tarea: {ex.Message}", Severity.Error);
            }
        }

        protected async Task UpdateTarea()
        {
            try
            {
                var result = await tareaService.Update(model);
                if (result != null)
                {
                    model = result;
                    snackbar.Add("¡Tarea actualizada!", Severity.Success);
                    await OnSuccessCreateEditMethod.InvokeAsync();
                    await RecargarMetas?.Invoke();
                }
                else
                {
                    snackbar.Add("No se actualizó la tarea", Severity.Warning);
                }
            }
            catch (ValidationRuleException ex)
            {
                validationErrors = ex.Errors;
            }
            catch (System.Exception ex)
            {
                snackbar.Add($"No se actualizó la tarea: {ex.Message}", Severity.Error);
            }
        }
    }
}