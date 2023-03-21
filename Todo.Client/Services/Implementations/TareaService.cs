using System.Net.Http.Json;
using Domain.DTOs;
using Infraestructure.Utils.Dto;
using Microsoft.AspNetCore.WebUtilities;
using Todo.Client.Services.Interfaces;
using Todo.Client.Utils;


namespace Todo.Client.Services.Implementations
{
    public class TareaService : RequestService<TareaDto>, ITareaService
    {
        public TareaService(IWebApiService webApiService) 
        : base(webApiService, ApiRoutes.TareaRoute)
        {
        }

        /// <summary>
        /// Método para obtener tareas de una meta
        /// </summary>
        /// <returns>Respuesta de la api</returns>
        public async Task<ResponseWrapper<List<TareaDto>>> Get(
            int metaId,
            int pageNumber, 
            int pageSize , 
            string sortColumn,
            string sortOrder,
            string searchTerm,
            string fecha,
            string estado)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["metaId"] = metaId.ToString(),
                ["pageNumber"] = pageNumber.ToString(),
                ["pageSize"] = pageSize.ToString(),
                ["sortColumn"] = sortColumn ?? "Nombre",
                ["sortOrder"] = sortOrder ?? "Ascending",
                ["searchTerm"] = searchTerm ?? "",
                ["fecha"] = fecha ?? "",
                ["estado"] = estado ?? ""
            };

            try
            {
                string query = QueryHelpers.AddQueryString(apiResourceRoute, queryStringParam);
                
                var result = await webApiService.GetAsync<ResponseWrapper<List<TareaDto>>>(query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para marcar una tarea como importante
        /// </summary>
        /// <param name="tareaId">Identificador de la tarea</param>
        /// <returns>Elemento modificado</returns>
        public async Task<TareaDto> EstablecerImportancia(int tareaId)
        {
            var response = await webApiService.PatchAsync($"{ApiRoutes.MarcarTareaComoImportante}?id={tareaId}");

            if (!response.IsSuccessStatusCode)
            {
                var badResponse = await response.Content.ReadAsStringAsync();

                throw new Exception(badResponse);
            }

            var result = await response.Content.ReadFromJsonAsync<TareaDto>();

            return result;
        }

        /// <summary>
        /// Método para eliminar varios registors
        /// </summary>
        /// <param name="ids">Identificadores de registros</param>
        /// <returns>Task</returns>
        public async Task Delete(int[] ids)
        {
            var response = await webApiService.PostAsync<int[]>(ApiRoutes.EliminarTareas, ids);

            if (!response.IsSuccessStatusCode)
            {
                var badResponse = await response.Content.ReadAsStringAsync();

                throw new Exception(badResponse);
            }
        }

        /// <summary>
        /// Método para completar varios registros
        /// </summary>
        /// <param name="ids">Identificadores de registros</param>
        /// <returns>Task</returns>
        public async Task Completar(int[] ids)
        {
            var response = await webApiService.PostAsync<int[]>(ApiRoutes.CompletarTareas, ids);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
    }
}