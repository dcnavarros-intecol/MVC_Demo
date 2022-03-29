using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Demo.Models.ViewModels
{
    public class MaquinaViewModel
    {

        //public long Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Id_linea")]
        public long IdLinea { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        //[Required]
        //[Display(Name = "Fecha")]
        //public DateTime FechaHora { get; set; }
    }
}
