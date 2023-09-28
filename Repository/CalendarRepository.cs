using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models.WorkModels;
using WpfApp4_net6.Repository.IRepository;
using tblCalendarDetail = WpfApp4_net6.Models.CalendarDetail;
namespace WpfApp4_net6.Repository
{
    public class CalendarRepository : BaseRepository, ICalendarRepository
    {
        public CalendarRepository() { }


        public List<tblCalendarDetail> GetList()
        {
            List<tblCalendarDetail> restult = _context.CalendarDetail.ToList();
            return restult;
        }

        public CalendarDetailWorkModel GetFirst()
        {
            CalendarDetailWorkModel restult = _context.Products.Select(x => new CalendarDetailWorkModel()
           
           ).First();

            return restult;
        }

        public string GetTitle() 
        {
            var res = _context.CalendarDetail.First().LessonName;
            return res;
        }

        public int AddNewProduct()
        {
            CalendarDetailWorkModel newItem = new CalendarDetailWorkModel();
            newItem.Subject = "Subject 1";
            newItem.LessonName = "Lession Name";
            newItem.Session = 1;
            newItem.Schedule = DateTime.Now.AddDays(1);

            if (newItem == null)
            {
                return 500;
            }

            tblCalendarDetail newCalendar = new tblCalendarDetail()
            { 
                Subject = newItem.Subject,
                LessonName = newItem.LessonName,
                Session =   newItem.Session,
                Schedule = newItem.Schedule
            };


            _context.CalendarDetail.Add(newCalendar);
            _context.SaveChanges();

            return 200;
        }
    }
}
