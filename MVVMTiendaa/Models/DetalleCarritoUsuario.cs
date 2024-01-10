using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Models
{
    public class DetalleCarritoUsuario
    {
        public int idDetalleCarrito { get; set; }
        //public bool status { get; set; }
        public int cantidad { get; set; }
        //public float precioTotal { get; set; }
        public int prendaIdPrenda { get; set; }

        public int accesorioIdAccesorio { get; set; }

        public int promocionIdPromocion { get; set; }
        public int carritoIdCarrito { get; set; }
    }
}
