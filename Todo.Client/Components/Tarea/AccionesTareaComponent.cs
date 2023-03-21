using Microsoft.AspNetCore.Components;
using MudBlazor;
using Todo.Client.Services.Interfaces;
using Domain.DTOs;

namespace Todo.Client.Components.Tarea
{
    public class AccionesTareaComponentaBase : ComponentBase
    {        
        #region Variables
        [CascadingParameter] 
        public Func<Task> RecargarMetas { get; set; }
        
        [Inject]
        private IDialogService dialogService { get; set; }

        [Inject]
        public ITareaService tareaService { get; set; }

        [Inject]
        protected ISnackbar Snackbar { get; set; }

        [CascadingParameter] 
        public MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public EventCallback OnSuccessActionMethod { get; set; }
        
        [CascadingParameter]
        public int MetaId { get; set; }
        
        [Parameter]
        public int TareaId { get; set; }

        [Parameter]
        public HashSet<TareaDto> Tareas { get; set; } = new HashSet<TareaDto>();
        #endregion

        protected async Task CompleTarTareas()
        {
            try
            {
                var ids = Tareas.Select(x => x.Id).ToArray();
                if (ids is null) return;

                await tareaService.Completar(ids);
                
                Snackbar.Add(ids.Count() > 1 ? "¡Tareas Completadas!" : "¡Tarea completada!", Severity.Success);
                
                await OnSuccessActionMethod.InvokeAsync();
                await RecargarMetas.Invoke();
            }
            catch (System.Exception ex)
            {
                Snackbar.Add($"No realizó la operación de manera correcta: {ex.Message}", Severity.Error);
            }
        }

        #region Dialogs
        protected void OpenAddTareaDialog()
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessCreateEditMethod", OnSuccessActionMethod);
            parameters.Add("MetaId", MetaId);
            parameters.Add("RecargarMetas", RecargarMetas);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            dialogService.Show<AgregarEditarTareaDialogComponent>("Agregar nueva tarea",parameters, options);
        }

        protected void OpenUpdateTareaDialog()
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessCreateEditMethod",OnSuccessActionMethod);
            parameters.Add("Actualizar", true);
            parameters.Add("TareaId", TareaId);
            parameters.Add("MetaId", MetaId);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            dialogService.Show<AgregarEditarTareaDialogComponent>("Editar tarea",parameters, options);
        }

        protected void OpenDeleteTareasDialog()
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessDeleteMethod", OnSuccessActionMethod);
            parameters.Add("Tareas", Tareas);
            parameters.Add("RecargarMetas", RecargarMetas);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            dialogService.Show<EliminarTareasDialogComponent>("¿Estas Seguro?",parameters, options);
        }
        #endregion
    }
}