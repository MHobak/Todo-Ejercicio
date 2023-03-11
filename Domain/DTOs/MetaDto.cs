namespace Domain.DTOs
{
    public class MetaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TareasCompletadas { get; set; }
        public int TotalTareas { get; set; }
        public decimal PorcentajeCumplimiento { get; set; }
    }
}