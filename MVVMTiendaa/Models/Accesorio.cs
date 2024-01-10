using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Models
{
    public class Accesorio
    {
        public int idAccesorio { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }

        public int cantidad { get; set; }

        public float precio { get; set; }
    }
}
