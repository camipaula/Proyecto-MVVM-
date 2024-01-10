using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using MVVMTiendaa.ViewModels;
using System.Collections.ObjectModel;

namespace MVVMTiendaa;

public partial class AccesoriosPage : ContentPage
{
    private readonly APIService _ApiService;
    private readonly AccesoriosPageViewModel _viewModel;

    public AccesoriosPage(APIService apiservice)
    {

        InitializeComponent();
        _ApiService = apiservice;
        _viewModel = new AccesoriosPageViewModel();
        _viewModel.SetAPIService(apiservice);
        BindingContext = _viewModel;
    }





    private async void OnClickBuscar(object sender, EventArgs e)
    {
        Accesorio a = await _viewModel.OnClickBuscar();
        if (a != null)
        {
            await Navigation.PushAsync(new DetalleAccesorioPage(_ApiService, a.idAccesorio));

        }
        else
        {
            // Mostrar mensaje de advertencia si la búsqueda no tuvo éxito
            DisplayAlert("UPS!", "Ingresa un código válido.", "OK");
        }


    }


    private void CargarAccesorios()
    {
        _viewModel.CargarAccesoriosAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CargarAccesorios();
    }


    private async void OnClickMostrarDetalles(object sender, SelectedItemChangedEventArgs e)
    {

        Accesorio accesorio = e.SelectedItem as Accesorio;
        await Navigation.PushAsync(new DetalleAccesorioPage(_ApiService, accesorio.idAccesorio));

    }
}