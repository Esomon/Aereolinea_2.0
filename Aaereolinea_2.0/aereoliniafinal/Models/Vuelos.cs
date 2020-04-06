using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace aereoliniafinal.Models
{
    public class Vuelos
    {
        public int VuelosID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string FechaSalida { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string FechaLlegada { get; set; }
        public int AvionesID { get; set; }
        public virtual Aviones Aviones { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int CiudadesID { get; set; }
        public virtual Ciudades Ciudades { get; set; }
        


    }
}
