using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aereoliniafinal.Models
{
    public class Pais
    {
        public int PaisID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Ciudades> Ciudades { get; set; }
    }
}
