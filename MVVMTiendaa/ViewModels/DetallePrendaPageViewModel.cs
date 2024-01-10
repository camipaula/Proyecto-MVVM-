
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.ViewModels
{
    public partial class DetallePrendaPageViewModel : ObservableObject
    {
        private APIService _ApiService;
        [ObservableProperty]
        public Prenda prenda;
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string cantidad;
        [ObservableProperty]
        public string descripcion;
        [ObservableProperty]
        public string categoria;
        [ObservableProperty]
        public string categoriaDescripcion;
        [ObservableProperty]
        public string marca;
        [ObservableProperty]
        public string marcaDescripcion;
        [ObservableProperty]
        public int cantidadP;
        [ObservableProperty]
        public List<string> num;
        [ObservableProperty]
        public int cantidadMaximaProductos;


        
        public DetallePrendaPageViewModel()
        {

        }

        public void SetAPIService(APIService apiService)
        {
            _ApiService = apiService;
        }



        public async Task CargarDetallePrendaAsync(int idPrenda)
        {
          
            Prenda = await _ApiService.GetPrenda(idPrenda);//prenda desde servicio

            // Detalles de cada prenda
            Nombre = Prenda.nombre;
            Cantidad = Prenda.cantidad.ToString();
            cantidadMaximaProductos = Prenda.cantidad;
            Descripcion = Prenda.descripcion;
            Marca = Prenda.marca.nombre;
            Categoria = Prenda.categoria.nombre;
            MarcaDescripcion = Prenda.marca.descripcion;
            CategoriaDescripcion = Prenda.categoria.descripcion;

        }


        public async Task<List<string>> CargarStock(int idPrenda)
        {

            Prenda = await _ApiService.GetPrenda(idPrenda);
            cantidadMaximaProductos = Prenda.cantidad;

            List<string> num = new List<string>();
            for (int i = 1; i <= cantidadMaximaProductos; i++)
            {
                num.Add(i.ToString());
            }

            return num;
        }



        //Añadir al carrito
        [RelayCommand]
        public async Task<int> OnClickAnadir()
        {

            int usuarioid = Preferences.Get("idUsuario", 0);
            if (usuarioid == 0)
            {
                return -1;
            }
            else
            {
                //toma el indice del picker y suma uno para saber la cantidad que mando el usuario
                var cantidadSeleccionada = CantidadP;
                

                if (cantidadSeleccionada == 0)
                {
                    return 0;
                }
                else
                {
                    int carritoid = Preferences.Get("idCarrito", 0);
                    cantidadSeleccionada = CantidadP + 1;
                    DetalleCarritoUsuario detalleCarritoUsuario = new DetalleCarritoUsuario
                    {
                        cantidad = cantidadSeleccionada,
                        prendaIdPrenda = prenda.idPrenda,
                        carritoIdCarrito = carritoid,
                    };

                    DetalleCarrito detallecarrito = await _ApiService.PostDetalleCarrito(detalleCarritoUsuario);
                    return 1;

                }
                    



            
            }
        }




    }
}
