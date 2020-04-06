using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aereoliniafinal.Models
{
    public class TipoEmpleado
    {
        public int TipoEmpleadoID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
