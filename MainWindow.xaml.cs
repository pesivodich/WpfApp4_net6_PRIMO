using Microsoft.EntityFrameworkCore;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;
using WpfApp4_net6.Views;
using WpfApp4_net6.Models.WorkModels;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WpfApp4_net6.ViewModels;
using WpfApp4_net6.Services;
using WpfApp4_net6.DataModel;

namespace WpfApp4_net6
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IUnitOfWork _unitOfWork;
      
        public MainWindow(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
            DataContext = new MainViewModel(_unitOfWork);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Layout1 layout = new Layout1();
            layout.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Layout2 layout2 = new Layout2(_unitOfWork);
            layout2.Show();
        }
      
    }
}
