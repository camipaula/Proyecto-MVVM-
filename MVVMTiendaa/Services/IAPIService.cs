using MVVMTiendaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Services
{
    internal interface IAPIService
    {
        //PRENDAS
        public Task<List<Prenda>> GetAllPrendas();
        public Task<Prenda> GetPrenda(int IdPrenda);
        public Task<Prenda> CreatePrenda(PrendaUsuario prenda);
        public Task<Prenda> UpdatePrenda(int IdPrenda, Prenda prenda);
        public Task<bool> DeletePrenda(int IdPrenda);
        //ACCESORIOS
        public Task<List<Accesorio>> GetAllAccesorios();
        public Task<Accesorio> GetAccesorio(int IdAccesorio);
        public Task<Accesorio> CreateAccesorio(Accesorio accesorio);
        public Task<Accesorio> UpdateAccesorio(int IdAccesorio, Accesorio accesorio);
        public Task<bool> DeleteAccesorio(int IdAccesorio);
        //PROMOCIONES
        public Task<List<Promocion>> GetAllPromociones();
        public Task<Promocion> GetPromocion(int IdPromocion);
        public Task<Promocion> CreatePromocion(Promocion promocion);
        public Task<Promocion> UpdatePromocion(int IdPromocion, Promocion promocion);
        public Task<bool> DeletePromocion(int IdPromocion);
    }
}
