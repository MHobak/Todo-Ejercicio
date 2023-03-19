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
    }
}