using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class Linea
    {
        public Linea()
        {
            Maquinas = new HashSet<Maquina>();
            Referencia = new HashSet<Referencia>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual ICollection<Maquina> Maquinas { get; set; }
        public virtual ICollection<Referencia> Referencia { get; set; }
    }
}
