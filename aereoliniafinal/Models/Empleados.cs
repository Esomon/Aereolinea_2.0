using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aereoliniafinal.Models
{
    public class Empleados : Persona
    {
        public int EmpleadosID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int TipoEmpleadoID { get; set; }
        public virtual TipoEmpleado TipoEmpleado { get; set; }
    }
}
