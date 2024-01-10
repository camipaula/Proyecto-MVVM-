using CommunityToolkit.Mvvm.ComponentModel;
using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.ViewModels
{
    public partial class RegistrarsePageViewModel : ObservableObject
    {
        private APIService _ApiService;
        [ObservableProperty]
        public string nombreUsuario;
        [ObservableProperty]
        public string correo;
        [ObservableProperty]
        public string telefono;
        [ObservableProperty]
        public string direccion;
        [ObservableProperty]
        public string contrasenia;
        [ObservableProperty]
        public string confirmarContrasenia;


        public RegistrarsePageViewModel()
        {

        }

        public void SetAPIService(APIService apiService)
        {
            _ApiService = apiService;
        }



        public async Task<int>  OnClickRegistrarNuevoUsuario()
        {
            string contrasenia1 = contrasenia;
            string confirmarContrasenia1 = confirmarContrasenia;

            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(contrasenia) ||
           string.IsNullOrWhiteSpace(correo) ||
           string.IsNullOrWhiteSpace(telefono) ||
           string.IsNullOrWhiteSpace(direccion))
            {
                return -1;

            }
            else
            {
                Usuario nuevoUsuario = new Usuario
                {
                    usuario = nombreUsuario,
                    contrasena = contrasenia,
                    correo = correo,
                    telefono = telefono,
                    direccion = direccion
                };

                await _ApiService.PostUsuario(nuevoUsuario);
                return 1;

            }
        }




    }
}
