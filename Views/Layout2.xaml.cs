using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp4_net6.Repository;
using WpfApp4_net6.ViewModels;
using WpfApp4_net6.UserControls;

namespace WpfApp4_net6.Views
{
    /// <summary>
    /// Interaction logic for Layout2.xaml
    /// </summary>
    public partial class Layout2 : Window
    {
        private readonly IWeatherModel _weatherModel;
        public Layout2(IWeatherModel weatherModel)
        {
            InitializeComponent();
            _weatherModel = weatherModel;

            //IWeatherModel _weatherModel = new WeatherModel();

            var layout2ViewModel = new Layout2ViewModel(_weatherModel);

            DataContext = layout2ViewModel;

        }
    }
}
