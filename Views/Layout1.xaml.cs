using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp4_net6.ViewModels;

namespace WpfApp4_net6.Views
{
    /// <summary>
    /// Interaction logic for Layout1.xaml
    /// </summary>
    public partial class Layout1 : Window
    {
        public Layout1()
        {

            InitializeComponent();

            IProductModel productModel = new ProductModel();

            Layout1ViewModel layout1ViewModel = new Layout1ViewModel(productModel);

            DataContext = layout1ViewModel;
            
        }

       
    }
}
