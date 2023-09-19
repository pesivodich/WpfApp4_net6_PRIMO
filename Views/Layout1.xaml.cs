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
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.Views
{
    /// <summary>
    /// Interaction logic for Layout1.xaml
    /// </summary>
    public partial class Layout1 : Window
    {

        private readonly IDataAccess _weatherModel;
        public Layout1(IDataAccess weatherModel)
        {

            _weatherModel = weatherModel;
            InitializeComponent();

            Title_1.Text = _weatherModel.GetTitle();
        }
    }
}
