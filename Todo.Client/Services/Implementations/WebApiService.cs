using Todo.Client.Services.Interfaces;
using System.Net.Http.Json;

namespace Todo.Client.Services.Implementations
{
    public class WebApiService : IWebApiService
    {
        /// <summary>
        /// Cliente HTTP
        /// </summary>
        private readonly HttpClient client;

        public WebApiService(IConfiguration configuration){
            var apiUri = configuration["ApiUrl:TodoServer.Api"];
            client = new();
            client.BaseAddress = new Uri(apiUri);
        }

        public Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync<T>(string endpoint) => 
            await client.GetFromJsonAsync<T>(endpoint);

        public Task<HttpResponseMessage> PatchAsync(string endpoint, HttpContent content = null)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsync<TValue>(string endpoint, TValue value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync<TValue>(string endpoint, TValue value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            throw new NotImplementedException();
        }
    }
}