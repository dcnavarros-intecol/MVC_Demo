using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class Producido
    {
        public long Id { get; set; }
        public string Referencia { get; set; }
        public string Linea { get; set; }
        public string Maquina { get; set; }
        public int CantidadProducto { get; set; }
        public int Estado { get; set; }
        public int EstadoEnvio { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime? TimeStampSalidas { get; set; }
    }
}
