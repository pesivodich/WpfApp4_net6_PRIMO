using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Repository;

namespace WpfApp4_net6.ViewModels
{
    public class Layout2ViewModel
    {
        private readonly IWeatherModel _weatherModel;
        
        public string Description_2 { get; set; }
        public Layout2ViewModel(IWeatherModel weatherModel) 
        {
            _weatherModel = weatherModel;

            Description_2 =  _weatherModel.GetWeatherDetail();

        }
    }
}
