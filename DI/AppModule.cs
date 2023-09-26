using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.DataModel;
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;
using WpfApp4_net6.ViewModels;

namespace WpfApp4_net6.DI
{
    /// <summary>
    /// Đăng ký các dịch vụ dùng cho việc tạo và xử lý sự kiện thông qua autofac
    /// <para>Created at: 19/09/2023</para>
    /// <para>Created by: SonNC</para>
    /// </summary>
    public class AppModule : Autofac.Module
    {
        /// <summary>
        /// Ghi đè phương thức load của autofac để đăng ký dịch vụ
        /// Đăng 
        /// <para>Created at: 19/09/2023</para>
        /// <para>Created by: SonNC</para>
        /// </summary>
        /// <param name="builder">builder dùng để đăng ký dịch vụ</param>


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<TestRepository>().As<ITestRepository>().InstancePerLifetimeScope();
        }
    }
}
