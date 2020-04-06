using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aereoliniafinal.Models
{
    public class Aviones
    {
        public int AvionesID { get; set; }
        [Required(ErrorMessage = "Modelos Requerido")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Año Requerido ")]
        public string Eye { get; set; }
        [Required(ErrorMessage = "Capacidad Requerida De Persona ")]
        public string Capacidad { get; set; }
        public ICollection<Vuelos> Vuelos { get; set; }
    }
}
