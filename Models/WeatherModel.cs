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

namespace WpfApp4_net6.Models
{
    public interface IWeatherModel
    {
      string GetWeatherDetail();
    }
    public class WeatherModel :  IWeatherModel
    {
        private readonly ILogger<WeatherModel> _logger;
        private string _className = "";
        public WeatherModel(
           
        ) 
        {
           

        }
    

        public string GetWeatherDetail()
        {
            return "Hoàng Minh đi ngủ đi";
        }


    }
}
