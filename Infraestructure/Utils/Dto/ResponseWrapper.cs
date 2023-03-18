namespace Infraestructure.Utils.Dto
{
    public class ResponseWrapper<T>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / (decimal)PageSize);
        public T Data { get; set; }
    }
}
