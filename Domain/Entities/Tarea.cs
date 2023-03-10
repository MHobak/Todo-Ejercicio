using Domain.Enums;

namespace Domain.Entities
{
    public class Tarea
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsImportante { get; set; }
        public EstadoTarea Estado { get; set; }
        public Meta Meta { get; set; }
    }
}
