using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class Referencia
    {
        public long Id { get; set; }
        public long IdLinea { get; set; }
        public long IdMaquina { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual Linea IdLineaNavigation { get; set; }
        public virtual Maquina IdMaquinaNavigation { get; set; }
    }
}
