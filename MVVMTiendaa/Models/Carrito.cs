using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Models
{
    public class Carrito
    {
        public int idCarrito { get; set; }
        public int usuarioidUsuario { get; set; }

        public virtual Usuario usuario { get; set; }
        public string fecha { get; set; }
       
    }
}
