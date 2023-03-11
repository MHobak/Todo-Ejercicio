namespace Domain.Entities
{
    public class Meta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

        #region CamposCalculados 

        public int TareasCompletadas { get; set; }
        public int TotalTareas { get; set; }
        //public decimal PorcentajeCumplimiento => TotalTareas > 0 ? 0 : (TareasCompletadas * 100) / TotalTareas;

        #endregion
    }
}
