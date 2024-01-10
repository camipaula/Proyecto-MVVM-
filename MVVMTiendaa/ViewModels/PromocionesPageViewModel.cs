using CommunityToolkit.Mvvm.ComponentModel;
using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.ViewModels
{
    public partial class PromocionesPageViewModel : ObservableObject
    {
        private APIService _ApiService;
        [ObservableProperty]
        public string buscarPorID;
        [ObservableProperty]
        public ObservableCollection<Promocion> promociones;


        public PromocionesPageViewModel()
        {

        }
        public void SetAPIService(APIService apiService)
        {
            _ApiService = apiService;
        }

        public async Task<Promocion> OnClickBuscar()
        {
            if (string.IsNullOrWhiteSpace(BuscarPorID) || !int.TryParse(BuscarPorID, out int buscarPorID))
            {
                return null;
            }

            Promocion p = await _ApiService.GetPromocion(buscarPorID);

            if (p != null)
            {

                return p;
            }
            else
            {
                return null;

            }
        }



        public async void CargarPromocionesAsync()
        {
            Promociones = new ObservableCollection<Promocion>();
            var prom = await _ApiService.GetAllPromociones();
            foreach (var p in prom)
            {
                Promociones.Add(p);
            }
        }
    }
}
