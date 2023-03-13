using System.Net.Http.Json;
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
        public async Task<List<T>> Get()
        {
            try
            {
                var result = await webApiService.GetAsync<List<T>>(apiResourceRoute);
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
                var message = await response.Content.ReadAsStringAsync();
                //do something
            }

            T result = await response.Content.ReadFromJsonAsync<T>();

            return result;
        }
    }
}