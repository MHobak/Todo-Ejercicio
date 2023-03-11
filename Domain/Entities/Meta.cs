namespace Domain.Entities
{
    public class Meta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
