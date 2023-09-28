using System.Collections.Generic;
using System.Linq;
using WpfApp4_net6.Repository.IRepository;

using tblCalendarTime = WpfApp4_net6.Models.CalendarTime;

namespace WpfApp4_net6.Repository
{
    public class CalendarTimeRepository : BaseRepository, ICalendarTimeRepository
    {
        public CalendarTimeRepository() { }


        public List<tblCalendarTime> GetList()
        {
            List<tblCalendarTime> restult = _context.CalendarTime.ToList();
            return restult;
        }

        public tblCalendarTime GetFirst()
        {
            tblCalendarTime restult = _context.CalendarTime.Select(x => new tblCalendarTime()

           ).First();

            return restult;
        }

     
        public int AddNew(tblCalendarTime newItem)
        {
            if (newItem == null)
            {
                return 500;
            }

            _context.CalendarTime.Add(newItem);
            _context.SaveChanges();

            return 200;
        }
    }
}
