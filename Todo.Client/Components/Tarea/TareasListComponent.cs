using Domain.DTOs;
using Infraestructure.Utils.Dto;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Todo.Client.Services.Interfaces;

namespace Todo.Client.Components.Tarea
{
    public class TareasListComponentBase : ComponentBase
    {
        [Inject]
        protected ITareaService tareaService { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }
        
        [Inject]
        private ISnackbar Snackbar { get; set; }

        public int MetaId { get; set; }
        public string NombreMeta { get; set; }

        protected ResponseWrapper<List<TareaDto>> serverResponse = new();
        
        protected MudTable<TareaDto> mudTable;

        protected readonly int[] pageSizeOption = { 2, 5, 10, 15, 20 };
        private string searchString;
        private int selectedRowNumber = -1;
        protected TareaDto selectedRow;

        /// <summary>
        /// Consulta para obtener tareas utilizando paginación y filtros
        /// </summary>
        protected async Task<TableData<TareaDto>> ServerReload(TableState state)
        {
            try
            {
                if (MetaId > 0)
                {
                    serverResponse = await tareaService.Get(
                    MetaId,
                    state.Page + 1, 
                    state.PageSize,
                    state.SortLabel,
                    state.SortDirection == SortDirection.None ? SortDirection.Ascending.ToString() : state.SortDirection.ToString(),
                    searchString);   
                }
            }
            catch (System.Exception)
            {
                Snackbar.Add("No se pudo obtener las tareas", Severity.Error);
            }

            IEnumerable<TareaDto> data = serverResponse.Data;
            return new TableData<TareaDto>() {TotalItems = serverResponse.TotalItems, Items = data}; 
        }

        /// <summary>
        /// Metodo para realiozar busqueda en la tabla
        /// </summary>
        /// <param name="text">texto a buscar</param>
        protected void OnSearch(string text)
        {
            searchString = text;
            mudTable.ReloadServerData();
        }
        
        protected string SelectedRowClassFunc(TareaDto tarea, int rowNumber)
        {
            //Deseleccionar
            if (selectedRowNumber == rowNumber)
            {
                selectedRowNumber = -1;
                Console.WriteLine("NO seleccionado");
                return string.Empty;
            }
            //seleccionar
            else if (mudTable.SelectedItem != null && mudTable.SelectedItem.Equals(tarea))
            {
                selectedRowNumber = rowNumber;
                Console.WriteLine($"Seleccionado: {tarea.Id}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void ReloadTareasTable()
        {
            mudTable.ReloadServerData();
        }
    }
}