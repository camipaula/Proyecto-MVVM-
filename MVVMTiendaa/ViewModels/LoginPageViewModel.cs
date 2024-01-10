using CommunityToolkit.Mvvm.ComponentModel;
using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.Services.Maps;

namespace MVVMTiendaa.ViewModels
{
    public partial class LoginPageViewModel: ObservableObject
    {
        private APIService _ApiService;
        [ObservableProperty]
        public string nombreUsuario;
        [ObservableProperty]
        public string contrasenia;
        public LoginPageViewModel()
        {
            
        }
        public void SetAPIService(APIService apiService)
        {
            _ApiService = apiService;
        }


        public async Task<int> OnClickIniciarSesion()
        {
            Usuario usuario = await _ApiService.GetUsuario(NombreUsuario, Contrasenia);
            if (usuario != null)
            {
                CarritoUsuario carritoUsuario = new CarritoUsuario
                {
                    usuarioidUsuario = usuario.idUsuario,
                    fecha = "10/11/2024"
                };
                Carrito carritoGuardado = await _ApiService.PostCarrito(carritoUsuario);
                Preferences.Set("idUsuario", usuario.idUsuario);
                Preferences.Set("idCarrito", carritoGuardado.idCarrito);
                NombreUsuario = "";
                Contrasenia = "";
                return 1;
            }
            else
            {
               
                return 0;
            }
        }
        
    }
}
