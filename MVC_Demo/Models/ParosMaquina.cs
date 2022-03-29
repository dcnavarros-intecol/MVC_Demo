using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class ParosMaquina
    {
        public long Id { get; set; }
        public string Referencia { get; set; }
        public DateTime? FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }
        public string Linea { get; set; }
        public string Maquina { get; set; }
        public int CodigoParo { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual CodigoParo CodigoParoNavigation { get; set; }
    }
}
