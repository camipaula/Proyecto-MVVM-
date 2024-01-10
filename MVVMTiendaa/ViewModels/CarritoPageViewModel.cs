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
    public partial class CarritoPageViewModel : ObservableObject
    {
        private APIService _apiService;
        [ObservableProperty]
        public ObservableCollection<DetalleCarrito> listaprendasC;
        [ObservableProperty]
        public double totalpreciof;
        [ObservableProperty]
        public string precioTotalCompra;

        public CarritoPageViewModel()
        {

        }

        public void SetAPIService(APIService apiService)
        {
            _apiService = apiService;

        }

        public async void CargarProductosCarritoAsync()
        {
            int intcarrito = Preferences.Get("idCarrito", 0);
            ListaprendasC = new ObservableCollection<DetalleCarrito>();
            var listaprendasc = await _apiService.GetDetalleCarrito(intcarrito);
            foreach (var product in listaprendasc)
            {
                ListaprendasC.Add(product);
            }

        }







        }
}
