namespace Infraestructure.Utils.Dto
{
    public class ResponseWrapper<T>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / (decimal)PageSize);
        public string SortColumn { get; set; } = "Name";
        public string SortOrder { get; set; } = "asc";
        public string Nombre { get; set; } = "";
        public T Data { get; set; }
    }
}
