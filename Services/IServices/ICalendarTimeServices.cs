using System.Collections.Generic;
using WpfApp4_net6.Models.WorkModels.CalendarWorkModel;
using tblCalendarTime = WpfApp4_net6.Models.CalendarTime;

namespace WpfApp4_net6.Services.IServices
{
    public interface ICalendarTimeServices
    {
        public List<CalendarTimeWorkModel> GetAllData();
        public int AddNewItem(CalendarTimeWorkModel input);

    }
}
