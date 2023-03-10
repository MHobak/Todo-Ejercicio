namespace Domain.Entities
{
    public class Meta
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<Tarea> Tareas { get; set; }
    }
}
