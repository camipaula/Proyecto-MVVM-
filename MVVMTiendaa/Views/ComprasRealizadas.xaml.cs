using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using System.Collections.ObjectModel;

namespace MVVMTiendaa;

public partial class ComprasRealizadas : ContentPage
{
    private readonly APIService _ApiService;

    public ComprasRealizadas(APIService apiservice)
    {

        InitializeComponent();
        _ApiService = apiservice;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int idusuario = Preferences.Get("idUsuario", 0);
        List<Compra> listaCompras = await _ApiService.GetListaComprasCli(idusuario);
        var listadefacturas = new ObservableCollection<Compra>(listaCompras);
        ListaViewCompra.ItemsSource = listadefacturas;

    }

    private async void ListaViewCompras_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Compra selectedIntencion = ListaViewCompra.SelectedItem as Compra;

        if (selectedIntencion != null)
        {
            await Navigation.PushAsync(new DetalleCompraPage(_ApiService)
            {
                BindingContext = selectedIntencion,
            });
        }
    }
}