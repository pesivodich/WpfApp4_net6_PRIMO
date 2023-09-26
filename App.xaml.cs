using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp4_net6.DataModel;
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;
using WpfApp4_net6.Services;

namespace WpfApp4_net6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Khởi tạo AppHost để đăng ký các dịch vụ và thực hiện DI
        /// <para>Created at: 19/09/2023</para>
        /// <para>Created by: SonNC</para>
        /// </summary> 
        string connectionString = "server=localhost;port=3306;database=netcore_4;user=root;password=;";
        public static IHost? AppHost { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddDbContext<AppDbContext>(options =>
                         options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                         , ServiceLifetime.Transient);
                })
                .Build();
        }
    
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            base.OnStartup(e);

            var builder = new ContainerBuilder();

            builder.RegisterModule(new DI.AppModule());

            // Add the MainWindow class and later resolve
            builder.RegisterType<MainWindow>().AsSelf();
           
            //builder.RegisterType<MainWindow>().AsSelf();
            var container = builder.Build();

            var scope = container.BeginLifetimeScope();

            var window = scope.Resolve<MainWindow>();

            window.Show();


        }
    }
}
