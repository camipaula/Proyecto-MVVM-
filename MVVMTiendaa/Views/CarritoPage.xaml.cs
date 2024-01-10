using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using System.Collections.ObjectModel;

namespace MVVMTiendaa;

public partial class CarritoPage : ContentPage
{
    private readonly APIService _ApiService;

    public CarritoPage(APIService apiservice)
    {

        InitializeComponent();
        _ApiService = apiservice;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int intcarrito = Preferences.Get("idCarrito", 0);
        List<DetalleCarrito> listadeDetallesCarrito = await _ApiService.GetDetalleCarrito(intcarrito);
        var detalleCarrito1 = new ObservableCollection<DetalleCarrito>(listadeDetallesCarrito);
        detalleCarrito.ItemsSource = detalleCarrito1;
    }

    private async void OnClickMostrarDetalleCarrito(object sender, SelectedItemChangedEventArgs e)
    {

        DetalleCarrito detalleCarrito = e.SelectedItem as DetalleCarrito;
        await Navigation.PushAsync(new DetalleCarritoPage(_ApiService)
        {
            BindingContext = detalleCarrito,
        });
    }

    private async void OnClickComprar(object sender, EventArgs e)
    {
        int idcarrito = Preferences.Get("idCarrito", 0);
        Compra compra = await _ApiService.PostNuevaCompra(idcarrito);
        int idCompra = compra.idCompra;
        MandarDescripcion soli = new MandarDescripcion
        {
            carritoIdCarrito = idcarrito,
            compraIdCompra = idCompra,
        };
        bool detallegenerar = await _ApiService.PostGenerarDetalleFactura(soli);
        if (detallegenerar)
        {
            int idUsuario = Preferences.Get("idUsuario", 0);
            await DisplayAlert("Éxito", "Tu compra ha sido exitosa", "OK");
            CarritoUsuario carritoUsuario = new CarritoUsuario
            {
                usuarioidUsuario = idUsuario,
                fecha = "HOY"

            };
            Carrito carritoResp = await _ApiService.PostCarrito(carritoUsuario);
            Preferences.Set("idCarrito", carritoResp.idCarrito);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Lo sentimos", "Algo salió mal, inténtalo de nuevo", "OK");
        }

    }
}