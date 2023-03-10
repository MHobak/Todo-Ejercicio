using Domain.Enums;

namespace Domain.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsImportante { get; set; }
        public EstadoTarea Estado { get; set; }

        public int MetaId { get; set; }
        public Meta Meta { get; set; }
    }
}
