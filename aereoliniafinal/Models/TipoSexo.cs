using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aereoliniafinal.Models
{
    public class TipoSexo
    {
        public int TipoSexoID { get; set; }
        public string Sexo { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
