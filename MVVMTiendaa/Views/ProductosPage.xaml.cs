using MVVMTiendaa.Services;

namespace MVVMTiendaa;

public partial class ProductosPage : ContentPage
{
    private readonly APIService _ApiService;
    public ProductosPage(APIService apiservice)
    {
        InitializeComponent();
        _ApiService = apiservice;

        int usuarioid = Preferences.Get("idUsuario", 0);
        if (usuarioid == 0)
        {
            Preferences.Set("idUsuario", 0);
            Preferences.Set("idCarrito", 0);

        }
    }
    public async void OnClickPrendas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PrendasPage(_ApiService));
    }

    public async void OnClickAccesorios(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccesoriosPage(_ApiService));
    }

    public async void OnClickPromociones(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PromocionesPage(_ApiService));
    }

    private async void OnCarritoImageTapped(object sender, EventArgs e)
    {
        int usuarioid = Preferences.Get("idUsuario", 0);
        if (usuarioid == 0)
        {
            await Navigation.PushAsync(new LoginPage(_ApiService));
        }
        else 
        {
            await Navigation.PushAsync(new CarritoPage(_ApiService));
        }
            
    }

    private async void OnUsuarioClicked(object sender, EventArgs e)
    {
        int usuarioid = Preferences.Get("idUsuario", 0);
        if (usuarioid == 0)
        {
            await Navigation.PushAsync(new LoginPage(_ApiService));
        }
        else 
        {
            await Navigation.PushAsync(new UsuarioPage(_ApiService));
        }
            
    }


}