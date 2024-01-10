using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Models
{
    public class DetalleCompra
    {
        public int idDetalleCompra { get; set; }
        public bool status { get; set; }
        public int cantidad { get; set; }
        public float precioTotal { get; set; }

        public int prendaIdPrenda { get; set; }
        public virtual Prenda prenda { get; set; }
        //public int accesorioIdAccesorio { get; set; }
        //public virtual Accesorio accesorios { get; set; }
        //public int promocionIdPromocion { get; set; }
        //public virtual Promocion promocion { get; set; }
        public int compraIdCompra { get; set; }
        public virtual Compra compra { get; set; }
    }
}
