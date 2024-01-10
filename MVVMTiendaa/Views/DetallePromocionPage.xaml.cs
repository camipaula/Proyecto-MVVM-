using MVVMTiendaa.Models;
using MVVMTiendaa.Services;

namespace MVVMTiendaa;

public partial class DetallePromocionPage : ContentPage
{
    private Promocion _promocion;
    private readonly APIService _ApiService;
    public List<string> num { get; set; }
    private int cantidadMaximaProductos;

    public DetallePromocionPage(APIService apiservice, int idPromocion)
    {

        InitializeComponent();
        _ApiService = apiservice;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        _promocion = BindingContext as Promocion;
        Nombre.Text = _promocion.nombre;
        Cantidad.Text = _promocion.cantidad.ToString();
        cantidadMaximaProductos = _promocion.cantidad;
        Descripcion.Text = _promocion.descripcion;
        Marca.Text = _promocion.marca;
        Precio.Text= _promocion.precio.ToString();

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