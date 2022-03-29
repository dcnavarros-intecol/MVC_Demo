using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class PlanProduccion
    {
        public long Id { get; set; }
        public string Producto { get; set; }
        public string TrazabilidadTapa1 { get; set; }
        public string TrazabilidadTapa2 { get; set; }
        public string TrazabilidadEtiqueta1 { get; set; }
        public string TrazabilidadEtiqueta2 { get; set; }
        public int CantidadProducto { get; set; }
        public int InspeccionManual { get; set; }
        public int CantidadInspeccionManual { get; set; }
        public int ContadorExpulsion { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
