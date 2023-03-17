using Domain.Enums;

namespace Domain.DTOs
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        
        public bool EsImportante { get; set; }
        public EstadoTarea Estado { get; set; }

        public int MetaId { get; set; }
    }
}
