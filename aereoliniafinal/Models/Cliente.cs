using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aereoliniafinal.Models
{
    public class Cliente :  Persona
    {

        public int ClienteID { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int PaisID { get; set; }
        public virtual Pais Pais { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int TipoSexoID { get; set; }
        public virtual TipoSexo TipoSexo { get; set; }
    }
}
