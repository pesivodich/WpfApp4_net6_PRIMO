using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp4_net6.Repository;


namespace WpfApp4_net6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // kho9i tao cst su dung host de cai dat DI
        // Ihost con co tac dung ghi log...
        // tao cac services cua ung dung
        public static IHost? AppHost { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) => 
                {
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<IDataAccess, DataAccess>();
                })
                .Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {

            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }

            base.OnStartup(e);

        }

    }
}
