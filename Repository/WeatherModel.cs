using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.DataModel;

/// <summary>
/// Đăng ký các dịch vụ dùng cho việc tạo và xử lý sự kiện thông qua autofac
/// <para>Created at: 19/09/2023</para>
/// <para>Created by: Sonnc</para>
/// </summary>
namespace WpfApp4_net6.Repository
{


    public interface IWeatherModel
    {
      string GetWeatherDetail();
    }
    public class WeatherModel :BaseRepository, IWeatherModel
    {
       
        public WeatherModel()
        {
           
        }
   
        public string GetWeatherDetail()
        {
          
            var product = _context.Products.FirstOrDefault(x=> x.ProductId == 2)?.Des;

            if (product == null)
            {
                return "Khong co data";
            }

            return product;
        }

    }
}
