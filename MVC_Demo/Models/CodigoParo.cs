using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Demo.Models
{
    public partial class CodigoParo
    {
        public CodigoParo()
        {
            ParosMaquinas = new HashSet<ParosMaquina>();
        }

        public long Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Nivel { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual ICollection<ParosMaquina> ParosMaquinas { get; set; }
    }
}
