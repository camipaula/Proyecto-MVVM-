//using Android.App;
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
    public partial class AccesoriosPageViewModel : ObservableObject
    {
        private APIService _ApiService;
        [ObservableProperty]
        public string buscarPorID;
        [ObservableProperty]
        public ObservableCollection<Accesorio> accesorios;

        public AccesoriosPageViewModel()
        {

        }

        public void SetAPIService(APIService apiService)
        {
            _ApiService = apiService;
        }


        public async Task<Accesorio> OnClickBuscar()
        {
            if (string.IsNullOrWhiteSpace(BuscarPorID) || !int.TryParse(BuscarPorID, out int buscarPorID))
            {
                return null;
            }

            Accesorio a = await _ApiService.GetAccesorio(buscarPorID);

            if (a != null)
            {

                return a;
            }
            else
            {
                return null;

            }
        }


        public async void CargarAccesoriosAsync()
        {
            Accesorios = new ObservableCollection<Accesorio>();
            var accesorioss = await _ApiService.GetAllAccesorios();
            foreach (var a in accesorioss)
            {
                Accesorios.Add(a);
            }
        }

    }
}
