namespace Todo.Client.Utils
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
        public T Data { get; set; }
    }
}