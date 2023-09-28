using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tblCalendarTime = WpfApp4_net6.Models.CalendarTime;
namespace WpfApp4_net6.Repository.IRepository
{
    public interface ICalendarTimeRepository
    {
        List<tblCalendarTime> GetList();
        tblCalendarTime GetFirst();
        public int AddNew(tblCalendarTime newItem);

    }
}
