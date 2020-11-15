using OpenWeatherAPI;
using System.Windows;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            ApiHelper.InitializeClient();

            ITemperatureService itmps = new OpenWeatherService(AppConfiguration.GetValue("OWApiKey"));

            TemperatureViewModel tmpvm = new TemperatureViewModel();
            tmpvm.SetTemperatureService(itmps);

            DataContext = tmpvm;
        }
    }
}
