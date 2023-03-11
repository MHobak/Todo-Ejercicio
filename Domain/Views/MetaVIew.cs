using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views
{
    internal class MetaVIew
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
