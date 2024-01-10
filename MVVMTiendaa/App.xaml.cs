using MVVMTiendaa.Services;

namespace MVVMTiendaa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService ApiService = new APIService();
            MainPage = new NavigationPage(new ProductosPage(ApiService));
        }
    }
}