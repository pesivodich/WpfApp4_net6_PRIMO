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
        /// <para>Created by: Sonnc</para>
        /// </summary> 
        string connectionString = "server=localhost;port=3306;database=netcore_2;user=root;password=;";
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
                    services.AddScoped<IUnitOfWork, UnitOfWork>();


                })
                .Build();
        }
     

        //public void ConfigureContainer(ContainerBuilder containerBuilder)
        //{
        //    containerBuilder.RegisterModule(new DI.AppModule());
        //    //var builder = new ContainerBuilder();
        //    //builder.RegisterType<DataAccess>().As<IDataAccess>().InstancePerLifetimeScope();
        //}
        protected override async void OnStartup(StartupEventArgs e)
        {

            //var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            //    .Options;

            //using (var context = new AppDbContext(dbContextOptions))
            //{
            //    context.Database.EnsureCreated();
            //}

            base.OnStartup(e);

            var builder = new ContainerBuilder();

            builder.RegisterModule(new DI.AppModule());

            // Add the MainWindowclass and later resolve
            builder.RegisterType<MainWindow>().AsSelf();

            //builder.RegisterType<MainWindow>().AsSelf();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
              

                window.Show();
            }

        }
    }
}
