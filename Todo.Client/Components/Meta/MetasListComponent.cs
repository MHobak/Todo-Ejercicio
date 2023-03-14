using Microsoft.AspNetCore.Components;
using Todo.Client.Services.Interfaces;
using Domain.DTOs;
using MudBlazor;
using Todo.Client.Utils;
using Infraestructure.Utils.Dto;

namespace Todo.Client.Components.Meta
{
    public class MetasListComponentBase : ComponentBase
    {
        [Inject]
        private IMetaService metaService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }
        
        [Inject]
        private ISnackbar Snackbar { get; set; }

        protected ResponseWrapper<List<MetaDto>> response;

        protected List<MetaDto>? metas;

        protected override async Task OnInitializedAsync()
        {
            await GetMetas();
        }

        #region Dialogs
        protected void OpenAddMetaDialog()
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessCreateEditMethod", async() => await GetMetas());

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AgregarEditarMetaDialogComponent>("Agregar nueva meta",parameters, options);
        }

        protected void OpenUpdateMetaDialog(MetaDto meta)
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessCreateEditMethod", async() => await GetMetas());
            parameters.Add("Actualizar", true);
            parameters.Add("Model", ObjectCloner.Clone<MetaDto>(meta));//se clona el objecto para evitar cambiar el original por referancia

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AgregarEditarMetaDialogComponent>("Editar meta",parameters, options);
        }

        protected void OpenDeleteMetaDialog(MetaDto meta)
        {
            var parameters = new DialogParameters();
            //metodo declarado como parametro en el componente del dialogo
            parameters.Add("OnSuccessDeleteMethod", async() => await GetMetas());
            parameters.Add("Meta", meta);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<EliminarMetaDialogComponent>("¿Estas Seguro?",parameters, options);
        }
        #endregion    

        protected async Task GetMetas()
        {
            try
            {
                var response = await metaService.Get();

                if (response?.Data != null)
                {
                    metas = response.Data;
                }
            }
            catch (System.Exception)
            {
                Snackbar.Add("No pudo obtener las metas", Severity.Error);
            }

            StateHasChanged();
        }   
    }
}