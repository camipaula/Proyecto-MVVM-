using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using MVVMTiendaa.ViewModels;
using System.Collections.ObjectModel;

namespace MVVMTiendaa;

public partial class PromocionesPage : ContentPage
{
    private readonly APIService _ApiService;
    private readonly PromocionesPageViewModel _viewModel;

    public PromocionesPage(APIService apiservice)
    {
        InitializeComponent();
        _ApiService = apiservice;
        _viewModel = new PromocionesPageViewModel();
        _viewModel.SetAPIService(apiservice);
        BindingContext = _viewModel;
    }
    private async void OnClickBuscar(object sender, EventArgs e)
    {
        Promocion p = await _viewModel.OnClickBuscar();
        if (p != null)
        {
            await Navigation.PushAsync(new DetallePromocionPage(_ApiService, p.idPromocion));

        }
        else
        {
            // Mostrar mensaje de advertencia si la búsqueda no tuvo éxito
            DisplayAlert("UPS!", "Ingresa un código válido.", "OK");
        }


    }


    private void CargarPromociones()
    {
        _viewModel.CargarPromocionesAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CargarPromociones();
    }


    private async void OnClickMostrarDetalles(object sender, SelectedItemChangedEventArgs e)
    {

        Promocion p = e.SelectedItem as Promocion;
        await Navigation.PushAsync(new DetallePromocionPage(_ApiService, p.idPromocion));

    }
}