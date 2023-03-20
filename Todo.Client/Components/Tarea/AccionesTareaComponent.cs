using Microsoft.AspNetCore.Components;
using MudBlazor;
using Todo.Client.Services.Interfaces;
using Domain.DTOs;
using Todo.Client.Utils;

namespace Todo.Client.Components.Tarea
{
    public class AccionesTareaComponentaBase : ComponentBase
    {        
        #region Variables
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
        
        public int metaId { get; set; }
        public int tareaId { get; set; }
        #endregion

        #region Dialogs
        protected void OpenAddTareaDialog()
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessCreateEditMethod", OnSuccessActionMethod);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            dialogService.Show<AgregarEditarTareaDialogComponent>("Agregar nueva tarea",parameters, options);
        }

        protected void OpenUpdateTareaDialog()
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessCreateEditMethod",OnSuccessActionMethod);
            parameters.Add("Actualizar", true);
            parameters.Add("TareaId", tareaId);
            parameters.Add("MetaId", metaId);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            dialogService.Show<AgregarEditarTareaDialogComponent>("Editar tarea",parameters, options);
        }

        protected void OpenDeleteTareasDialog(TareaDto tarea)
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessDeleteMethod", OnSuccessActionMethod);
            parameters.Add("Meta", tarea);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            dialogService.Show<AgregarEditarTareaDialogComponent>("¿Estas Seguro?",parameters, options);
        }
        #endregion    

    }
}