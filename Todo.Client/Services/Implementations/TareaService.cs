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
            int pageNumber, 
            int pageSize , 
            string sortColumn,
            string sortOrder,
            string searchTerm)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pageNumber.ToString(),
                ["pageSize"] = pageSize.ToString(),
                ["sortColumn"] = sortColumn ?? "Nombre",
                ["sortOrder"] = sortOrder ?? "Ascending",
                ["searchTerm"] = searchTerm ?? ""
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
    }
}