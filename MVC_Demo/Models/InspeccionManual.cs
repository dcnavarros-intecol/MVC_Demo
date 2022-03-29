using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class InspeccionManual
    {
        public long Id { get; set; }
        public string Referencia { get; set; }
        public int Modulo { get; set; }
        public int Linea { get; set; }
        public string TipoError { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
