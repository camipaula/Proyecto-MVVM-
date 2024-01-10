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
    public partial class UsuarioModificadoViewModel : ObservableObject
    {


        private APIService _ApiService;

        [ObservableProperty]
        public string usuario;
        [ObservableProperty]
        public Usuario usuarioo;
        [ObservableProperty]
        public string correo;
        [ObservableProperty]
        public string telefono;
        [ObservableProperty]
        public string direccion;
        [ObservableProperty]
        public string contrasenia;


        public UsuarioModificadoViewModel()
        {

        }

        public void SetAPIService(APIService apiService)
        {
            _ApiService = apiService;
        }


        public async Task<int> CargarClienteDatos()
        {

            int idUsuario = Preferences.Get("idUsuario", 0);
            Usuarioo = await _ApiService.GetUsuarioPorCodigo(idUsuario);
            Usuario = Usuarioo.usuario;
            Correo = Usuarioo.correo;
            Telefono = Usuarioo.telefono;
            Direccion = Usuarioo.direccion;
            Contrasenia = Usuarioo.contrasena;

            return 1;
        }


        public async Task<int> Editar()
        {
            if (string.IsNullOrWhiteSpace(Usuario) ||
                string.IsNullOrWhiteSpace(Correo) ||
           string.IsNullOrWhiteSpace(Telefono) ||
           string.IsNullOrWhiteSpace(Direccion) ||
           string.IsNullOrWhiteSpace(Contrasenia))
            {
                return -1;

            }
            else
            {
                Usuario usuarioNuevo = new Usuario
                {
                    usuario = Usuario,
                    correo = Correo,
                    telefono = Telefono,
                    direccion = Direccion,
                    contrasena = Contrasenia,
                };
                int idUsuario = Preferences.Get("idUsuario", 0);
                await _ApiService.UpdateUsuario(idUsuario,usuarioNuevo);

                return 1;
            }


        }




    }
}
