using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVVMTiendaa;

public partial class DetalleCompraPage : ContentPage
{
    private Compra _compra;
    private readonly APIService _ApiService;

    public DetalleCompraPage(APIService apiservice)
    {

        InitializeComponent();
        _ApiService = apiservice;
    }
    protected override async void OnAppearing()
    {

        base.OnAppearing();
        _compra = BindingContext as Compra;
        int idcompra = _compra.idCompra;
        List<DetalleCompra> listaDescripciones = await _ApiService.GetDetalleCompra(idcompra);
        var products = new ObservableCollection<DetalleCompra>(listaDescripciones);
        detalleCarrito.ItemsSource = products;
        var totalprecio = await _ApiService.GetPrecioTotalCompra(idcompra);
        PrecioTotalCompra.Text = totalprecio.ToString();


    }

    private async void OnClickMostrarDetalleCompra(object sender, SelectedItemChangedEventArgs e)
    {

        DetalleCompra detalleCarrito = e.SelectedItem as DetalleCompra;
        await Navigation.PushAsync(new DetalleCompraPage(_ApiService)
        {
            BindingContext = detalleCarrito,
        });
    }


    private async void OnClickSalir(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }


}