namespace Infraestructure.Utils.Dto
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public Response()
        {
            Message = "";
            Success = true;
            Errors = new Dictionary<string, string[]>();
            StatusCode = 0;
        }
    }
}
