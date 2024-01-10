//using AndroidX.Lifecycle;
using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using MVVMTiendaa.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVVMTiendaa;

public partial class DetallePrendaPage : ContentPage
{
    
    private readonly APIService _ApiService;
    private readonly int _idPren;
    private readonly DetallePrendaPageViewModel _viewModel;
    public DetallePrendaPage(APIService apiservice, int idprenda)
    {
        InitializeComponent();
        _ApiService = apiservice;
        _viewModel = new DetallePrendaPageViewModel();
        _viewModel.SetAPIService(apiservice);
        _idPren = idprenda;
        BindingContext = _viewModel;


        int usuarioid = Preferences.Get("idUsuario", 0);
        if (usuarioid == 0)
        {
            Preferences.Set("idUsuario", 0);
            Preferences.Set("idCarrito", 0);

        }
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<string> numeros = await _viewModel.CargarStock(_idPren);
        _viewModel.CargarDetallePrendaAsync(_idPren);
       CantidadP.ItemsSource = numeros;
    }


    private async void OnClickSalir(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }


    private async void OnClickAnadir(object sender, EventArgs e)
    {

        int respuesta = await _viewModel.OnClickAnadir();
        if (respuesta == -1)
        {
            await Navigation.PushAsync(new LoginPage(_ApiService));
        }
        else
        {
            if (respuesta == 0)
            {
                await DisplayAlert("Ay:(", "No tienes nada agregado en tu carrito", "OK");
            }
            else
            {
                await DisplayAlert("Exito!", "Agregaste el producto a tu carrito con éxito", "OK");
                await Navigation.PopAsync();
            }
        }



    }

}