using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models.WorkModels;
using WpfApp4_net6.Models.WorkModels.CalendarWorkModel;

namespace WpfApp4_net6.Services.IServices
{
    public interface ICalendarServices
    {
        string GetDemo();

        int AddNewDemo();

        List<ListOfCalendar> GetList();
        List<CalendarWorkModel> GetAllData();
    }
}
