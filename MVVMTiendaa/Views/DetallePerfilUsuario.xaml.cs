using CommunityToolkit.Maui.Core;
using MVVMTiendaa.Models;
using MVVMTiendaa.Services;

namespace MVVMTiendaa;

public partial class DetallePerfilUsuario : ContentPage
{
    private Usuario _usuario;
    private readonly APIService _ApiService;

    public DetallePerfilUsuario(APIService apiservice)
    {

        InitializeComponent();
        _ApiService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _usuario = BindingContext as Usuario;
        usuario.Text = _usuario.usuario;
        correo.Text= _usuario.correo;
        telefono.Text = _usuario.telefono;
        direccion.Text = _usuario.direccion;
    }

    private async void OnClickEditar(object sender, EventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make(_usuario.usuario, ToastDuration.Short, 14);

        await toast.Show();
        await Navigation.PushAsync(new UsuarioModificado(_ApiService));
    }

    private async void OnClickSalir(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }
}