using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Models
{
    public class Prenda
    {
        public int idPrenda { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
        //public Marca marca { get; set; }
        public Marca marca { get; set; }
        //public Categoria categoria { get; set; }
        public Categoria categoria { get; set; }
        public int cantidad { get; set; }

        public float precio { get; set; }
    }
}
