using MVVMTiendaa.Models;
using MVVMTiendaa.Services;

namespace MVVMTiendaa;

public partial class DetalleCarritoPage : ContentPage
{
    private Carrito _carrito;
    private DetalleCarrito _detalleCarrito;
    private readonly APIService _ApiService;

    public DetalleCarritoPage(APIService apiservice)
    {

        InitializeComponent();
        _ApiService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _carrito = BindingContext as Carrito;
        int idcarrito = _carrito.idCarrito;
        _detalleCarrito = BindingContext as DetalleCarrito;
        Nombre.Text = _detalleCarrito.prenda.nombre;
        Cantidad.Text = _detalleCarrito.prenda.cantidad.ToString();
        Descripcion.Text = _detalleCarrito.prenda.descripcion;
        Precio.Text = _detalleCarrito.prenda.precio.ToString();
        var totalprecio =  _ApiService.GetPrecioTotalCarrito(idcarrito);
        PrecioTotalCompra.Text = totalprecio.ToString();

    }

    private async void OnClickSalir(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }

    private async void OnClickEliminar(object sender, EventArgs e)
    {

        var codigo = _detalleCarrito.idDetalleCarrito;

        var desc = await _ApiService.DeleteDetalleCarrito(codigo);
        await DisplayAlert("Éxito", "Eliminaste el producto a tu carrito con éxito", "OK");
        await Navigation.PopAsync();

    }

}