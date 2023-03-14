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

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint) =>
            await client.DeleteAsync(endpoint);

        public async Task<T> GetAsync<T>(string endpoint) => 
            await client.GetFromJsonAsync<T>(endpoint);

        public async Task<HttpResponseMessage> PatchAsync(string endpoint, HttpContent content = null) =>
            await client.PatchAsync(endpoint, content);

        public async Task<HttpResponseMessage> PostAsync<TValue>(string endpoint, TValue value) =>
            await client.PostAsJsonAsync<TValue>(endpoint, value);
        
        public async Task<HttpResponseMessage> PutAsync<TValue>(string endpoint, TValue value) =>
            await client.PutAsJsonAsync<TValue>(endpoint, value);

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage) => 
            await client.SendAsync(httpRequestMessage);
    }
}