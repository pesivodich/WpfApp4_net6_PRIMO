using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Models.WorkModels.CalendarWorkModel
{
    public class CalendarDashboard
    {
        public ListOfCalendar DataMonday {  get; set; }
        public ListOfCalendar DataTuesday { get; set; }
        public ListOfCalendar DataWednesday { get; set; }
        public ListOfCalendar DataThursday { get; set; }
        public ListOfCalendar DataFriday { get; set; }
        public ListOfCalendar DataSaturday { get; set; }
        public ListOfCalendar DataSunday { get; set; }
    }
}
