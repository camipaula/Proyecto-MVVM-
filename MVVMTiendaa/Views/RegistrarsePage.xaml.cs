using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using MVVMTiendaa.ViewModels;

namespace MVVMTiendaa;

public partial class RegistrarsePage : ContentPage
{
    Label errorLabel;
    private readonly APIService _ApiService;
    private readonly RegistrarsePageViewModel _viewModel;

    public RegistrarsePage(APIService apiservice)
    {
        InitializeComponent();
        _ApiService = apiservice;
        _viewModel = new RegistrarsePageViewModel();
        _viewModel.SetAPIService(apiservice);
        BindingContext = _viewModel;
    }

    private async void OnClickRegistrarNuevoUsuario(object sender, EventArgs e)
    {

        int respuesta = await _viewModel.OnClickRegistrarNuevoUsuario();
        if (respuesta == -1)
        {
            await DisplayAlert("Campos incompletos", "Ingrese todos los datos", "OK");
        }
        else
        {
            await DisplayAlert("Éxito", "El usuario ha sido creado exitosamente", "OK");
            await Navigation.PopAsync();
        }
    }

    private async void OnClickCancelar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        
    }
}