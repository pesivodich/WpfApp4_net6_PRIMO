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
using WpfApp4_net6.Repository;



/// <summary>
/// Đăng ký các dịch vụ dùng cho việc tạo và xử lý sự kiện thông qua autofac
/// <para>Created at: 19/09/2023</para>
/// <para>Created by: Sonnc</para>
/// </summary>
namespace WpfApp4_net6.Models
{


    public interface IWeatherModel
    {
      string GetWeatherDetail();
    }
    public class WeatherModel :BaseModel, IWeatherModel
    {
       
        public WeatherModel()
        {
           
        }
   
        public string GetWeatherDetail()
        {
          
            return _context.Products.FirstOrDefault()?.Name;

        }

    }
}
