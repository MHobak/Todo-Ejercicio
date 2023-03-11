namespace Domain.Views
{
    public class MetaView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        #region CamposCalculados 

        public int TareasCompletadas { get; set; }
        public int TotalTareas { get; set; }
        public decimal PorcentajeCumplimiento { get; set; }

        #endregion
    }
}
