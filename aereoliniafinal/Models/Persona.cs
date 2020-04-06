using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aereoliniafinal.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }
        public int Edad { get; set; }
    }
}
