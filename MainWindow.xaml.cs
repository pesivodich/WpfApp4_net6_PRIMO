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
using WpfApp4_net6.Services.IServices;

namespace WpfApp4_net6
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalendarServices _calendarServices;
        private readonly ICalendarTimeServices _calendarTimeServices;
        public MainWindow(
            IUnitOfWork unitOfWork
            , ICalendarServices calendarServices
            , ICalendarTimeServices calendarTimeServices

            )
        {
            _calendarServices = calendarServices;
            _unitOfWork = unitOfWork;
            InitializeComponent();
            DataContext = new MainViewModel(_unitOfWork);
            _calendarTimeServices = calendarTimeServices;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Layout1 layout = new Layout1(_calendarServices, _calendarTimeServices);
            layout.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Layout2 layout2 = new Layout2(_unitOfWork);
            layout2.Show();
        }
      
    }
}
