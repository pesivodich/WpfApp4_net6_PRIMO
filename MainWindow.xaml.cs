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
using WpfApp4_net6.ViewModels;
using WpfApp4_net6.Views;
using tblProduct = WpfApp4_net6.Repository.Product;

namespace WpfApp4_net6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        string connectionString = "server=localhost;port=3306;database=netcore_2;user=root;password=;";
        private readonly AppDbContext _context;

        private readonly IWeatherModel _weatherModel;
        private readonly IDataAccess _dataAccess;

        
        public MainWindow(IWeatherModel weatherModel)
        {
            InitializeComponent();
            _weatherModel = weatherModel;

            txtHoangMinh.Text = _weatherModel.GetWeatherDetail();


            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;

            _context = new AppDbContext(dbContextOptions);
        
          var test =  _context.Products.FirstOrDefault();

            //var newProduct = new tblProduct()
            //{
            //    ProductId = 2,
            //    Name = "TEst Product ",
            //    Price = 22,
            //    Des = "Toi test Data",
            //    HoangMinh = "pepsivodich"
            //};

            //_context.Products.Add(newProduct);
            
            //_context.SaveChanges();




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Layout1 layout1 = new Layout1(_dataAccess);
            layout1.Show();
        }
    }
}
