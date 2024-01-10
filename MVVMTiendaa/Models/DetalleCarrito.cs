using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Models
{
    public class DetalleCarrito
    {
        public int idDetalleCarrito { get; set; }
        public bool status { get; set; }
        public int cantidad { get; set; }
        public float precioTotal { get; set; }

        public int prendaIdPrenda { get; set; }
        public virtual Prenda prenda { get; set; }
        public int aaccesorioIdAccesorio { get; set; }
        public virtual Accesorio accesorios { get; set; }
        public int promocionIdPromocion { get; set; }
        public virtual Promocion promocion { get; set; }
        public int carritoIdCarrito { get; set; }
        public virtual Carrito carrito { get; set; }
    }
}
