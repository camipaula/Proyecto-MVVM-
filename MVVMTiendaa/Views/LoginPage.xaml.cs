using CommunityToolkit.Maui.Core;
using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using MVVMTiendaa.ViewModels;

namespace MVVMTiendaa;

public partial class LoginPage : ContentPage
{
    
    private readonly APIService _ApiService;
    private readonly LoginPageViewModel _viewModel;

    public LoginPage(APIService apiservice)
    {
        
        InitializeComponent();
        _ApiService = apiservice;
        _viewModel = new LoginPageViewModel();
        _viewModel.SetAPIService(apiservice);
        BindingContext = _viewModel;
    }

    private async void OnClickIniciarSesion(object sender, EventArgs e) {
        int resultado = await _viewModel.OnClickIniciarSesion();
        if (resultado == 1)
        {
            await Navigation.PushAsync(new ProductosPage(_ApiService));
            await DisplayAlert("Éxito", $"Bienvenida/o", "OK");
        }
        else
        {
            await DisplayAlert("Ooh! :(", "Campos incompletos o Usuario/Contraseña Incorrectas", "OK");
        } 
    }
        private async void OnClickRegistrarse(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarsePage(_ApiService));

        }
        private async void OnXLabelTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }




    
}