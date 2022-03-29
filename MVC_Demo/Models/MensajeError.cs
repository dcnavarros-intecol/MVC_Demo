using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class MensajeError
    {
        public long Id { get; set; }
        public string Mensaje { get; set; }
        public string Color { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
