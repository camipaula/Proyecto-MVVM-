using MVVMTiendaa.Models;
using MVVMTiendaa.Services;

namespace MVVMTiendaa;

public partial class DetalleAccesorioPage : ContentPage
{
    private Accesorio _accesorio;
    private readonly APIService _ApiService;
    public List<string> num { get; set; }
    private int cantidadMaximaProductos;

    public DetalleAccesorioPage(APIService apiservice, int idAccesorio)
    {

        InitializeComponent();
        _ApiService = apiservice;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        _accesorio = BindingContext as Accesorio;
        Nombre.Text = _accesorio.nombre;
        Cantidad.Text = _accesorio.cantidad.ToString();
        cantidadMaximaProductos = _accesorio.cantidad;
        Descripcion.Text = _accesorio.descripcion;
        Marca.Text = _accesorio.marca;
        Precio.Text = _accesorio.precio.ToString();
        //CargarStock();

    }

    private async void OnClickSalir(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }


    //private void CargarStock()
    //{
    //    // Crear una lista de números
    //    num = new List<string>();
    //    for (int i = 1; i <= cantidadMaximaProductos; i++)
    //    {
    //        num.Add(i.ToString());
    //    }

    //    // Asignar la lista al Picker
    //    cantidad.ItemsSource = num;
    //}

}