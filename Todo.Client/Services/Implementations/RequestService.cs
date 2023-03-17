using Infraestructure.Utils.Dto;
using System.Net.Http.Json;
using Todo.Client.Exceptions;
using Todo.Client.Services.Interfaces;

namespace Todo.Client.Services.Implementations
{
    public class RequestService<T> : IRequestService<T>
    {
        private readonly IWebApiService webApiService;
        protected readonly string apiResourceRoute;

        public RequestService(IWebApiService webApiService, string route)
        {
            this.webApiService = webApiService;
            this.apiResourceRoute = route;
        }

        /// <summary>
        /// Método para obtener registros
        /// </summary>
        /// <param name="route">Ruta de la api para consulta</param>
        /// <returns>Respuesta de la api</returns>
        public async Task<ResponseWrapper<List<T>>> Get(int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                string query = apiResourceRoute;
                query += $"?pageNumber={pageNumber}";
                query += $"&pageSize={pageSize}";

                var result = await webApiService.GetAsync<ResponseWrapper<List<T>>>(query);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<T> Create(T value)
        {
            var response = await webApiService.PostAsync<T>(apiResourceRoute, value);

            if (!response.IsSuccessStatusCode)
            {
                var badResponse = await response.Content.ReadAsStringAsync();

                var validationErrors = await response.Content.ReadFromJsonAsync<ValidationErrorResponse>();
                if (validationErrors != null)
                {
                    throw new ValidationRuleException(validationErrors.Errors);
                }

                Console.WriteLine(badResponse);
                throw new Exception(badResponse);
            }

            T result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }

        public async Task Delete(int Id)
        {
            var response = await webApiService.DeleteAsync($"{apiResourceRoute}/{Id}");

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="value">Registro a actualizar</param>
        /// <returns>Registro actualizado</returns>
        public async Task<T> Update(T value)
        {
            var response = await webApiService.PutAsync<T>(apiResourceRoute, value);

            if (!response.IsSuccessStatusCode)
            {
                var badResponse = await response.Content.ReadAsStringAsync();

                var validationErrors = await response.Content.ReadFromJsonAsync<ValidationErrorResponse>();
                if (validationErrors != null)
                {
                    throw new ValidationRuleException(validationErrors.Errors);
                }

                Console.WriteLine(badResponse);
                throw new Exception(badResponse);
            }

            T result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }
    }
}