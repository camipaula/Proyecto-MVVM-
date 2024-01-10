using MVVMTiendaa.Models;
using MVVMTiendaa.Services;

namespace MVVMTiendaa;

public partial class UsuarioPage : ContentPage
{
    private Usuario _usuario;
    private readonly APIService _ApiService;
    public UsuarioPage(APIService apiservice)
    {
        InitializeComponent();
        _ApiService = apiservice;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _usuario = BindingContext as Usuario;
       
    }



    public async void OnClickcomprasRealizadas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ComprasRealizadas(_ApiService));
    }

    public async void OnClickVerPerfil(object sender, EventArgs e)
    {
        var intusuario= Preferences.Get("idUsuario", 0);
        var usuario = await _ApiService.GetUsuarioPorCodigo(intusuario);
        await Navigation.PushAsync(new DetallePerfilUsuario(_ApiService)
        {
            BindingContext = usuario,
        });
    }

    public async void OnClickCerrarSesion(object sender, EventArgs e)
    {
        await DisplayAlert("Acción", "Cerrar Sesión", "OK");
        Preferences.Set("idUsuario", 0);
        Preferences.Set("idCarrito", 0);
        await Navigation.PopToRootAsync();

        //await Navigation.PushAsync(new LoginPage(_ApiService));
    }

   


}