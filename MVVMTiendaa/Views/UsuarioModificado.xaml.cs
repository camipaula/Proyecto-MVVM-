using MVVMTiendaa.Models;
using MVVMTiendaa.Services;
using MVVMTiendaa.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVVMTiendaa;

public partial class UsuarioModificado : ContentPage
{
    private Usuario _usuario;
    private readonly APIService _ApiService;
    private readonly UsuarioModificadoViewModel _viewModel;
    public UsuarioModificado(APIService apiservice)
    {

        InitializeComponent();
        _ApiService = apiservice;
        _viewModel = new UsuarioModificadoViewModel();
        _viewModel.SetAPIService(apiservice);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int respuesta = await _viewModel.CargarClienteDatos();

    }

    private async void OnClickGuardarCambios(object sender, EventArgs e)
    {
        int respuesta = await _viewModel.Editar();
        if (respuesta == 1)
        {
            await DisplayAlert("Éxito", "Se han guardado los cambios correctamente", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Campos incompletos", "Llene los campos correctamente", "OK");
        }

    }
}