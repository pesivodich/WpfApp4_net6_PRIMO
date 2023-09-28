using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Models.WorkModels.CalendarWorkModel
{
    public class ListOfCalendar
    {
        public string DayTeching { get; set; }

        public List<CalendarWorkModel> Data { get; set; }
    }
}
