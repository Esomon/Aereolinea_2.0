using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aereoliniafinal.Models
{
    public class Ciudades
    {
        public int CiudadesID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        public ICollection<Vuelos> Vuelos { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int PaisID { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
