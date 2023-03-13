namespace Todo.Client.Services.Interfaces
{
    public interface IWebApiService
    {
        Task<T> GetAsync<T>(string endpoint);
        Task<HttpResponseMessage> PostAsync<TValue>(string endpoint, TValue value);
        Task<HttpResponseMessage> PutAsync<TValue>(string endpoint, TValue value);
        Task<HttpResponseMessage> DeleteAsync(string endpoint);
        Task<HttpResponseMessage> PatchAsync(string endpoint, HttpContent content = null);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
    }
}