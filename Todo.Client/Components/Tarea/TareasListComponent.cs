using Domain.DTOs;
using Infraestructure.Utils.Dto;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Todo.Client.Services.Interfaces;

namespace Todo.Client.Components.Tarea
{
    public class TareasListComponentBase : ComponentBase
    {
        #region Varaiables
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
        private string estadoString;
        private string fechaString;
        public HashSet<TareaDto> selectedItems = new HashSet<TareaDto>();
        public TareaDto SelectedRow { get; set; } = new();
        #endregion

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
                    state.Page + 1, //la propiedad del componente es idex basado en 0
                    state.PageSize,
                    state.SortLabel,
                    state.SortDirection == SortDirection.None ? SortDirection.Ascending.ToString() : state.SortDirection.ToString(),
                    searchString,
                    fechaString,
                    estadoString);   
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

        /// <summary>
        /// Método para actualizar la fecha seleccionada
        /// </summary>
        /// <param name="date">Fecha</param>
        protected void OnPickDate(DateTime? date)
        {
            fechaString = date is not null ? date?.ToString("MM/dd/yyyy") : string.Empty;
            mudTable.ReloadServerData();
        }
        
        /// <summary>
        ///  Método para actualizar el estado seleccionado
        /// </summary>
        /// <param name="estado">Nombre del estado</param>
        protected void OnSelectEstado(string estado)
        {
            estadoString = estado ?? string.Empty;
            mudTable.ReloadServerData();
            StateHasChanged();
        }

        /// <summary>
        /// Método para perzonalizar la seleccion de un row
        /// </summary>
        /// <param name="tarea">Elemento de tarea</param>
        /// <param name="rowNumber">Numero de row seleccionado</param>
        /// <returns></returns>
        protected string SelectedRowClassFunc(TareaDto tarea, int rowNumber)
        {
            return SelectedRow.Equals(tarea) ? "selected" : string.Empty;
        }

        /// <summary>
        /// Se ejecuta al hacer click en un row, necesario para personalizar la selección
        /// </summary>
        /// <param name="tableRowClickEventArgs"></param>
        protected void RowClickEvent(TableRowClickEventArgs<TareaDto> tableRowClickEventArgs)
        {
            SelectedRow = tableRowClickEventArgs.Item;
        }

        /// <summary>
        /// Metodo publico para recargar la tabla de tareas
        /// </summary>
        public void ReloadTareasTable()
        {
            mudTable.ReloadServerData();
        }
    }
}