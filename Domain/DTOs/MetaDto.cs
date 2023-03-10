namespace Domain.DTOs
{
    internal class MetaDto
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TareasCompletadas { get; set; }
        public int TotalTareas { get; set; }
        public decimal PorcentajeCumplimiento { get; set; }
    }
}