using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Repository;
using WpfApp4_net6.Services.IServices;
using WpfApp4_net6.Models.WorkModels;
using WpfApp4_net6.Models.WorkModels.CalendarWorkModel;
using System.Windows.Markup;

namespace WpfApp4_net6.Services
{
    public class CalendarServices : ICalendarServices
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IIdentityService _identityService;
        public CalendarServices( IUnitOfWork unitOfWork, IIdentityService identityService)
        {
            _unitOfWork = unitOfWork;
            _identityService = identityService;
        }

        private static List<string> GetDaysInMonth(int year, int month)
        {
            List<string> daysInMonth = new List<string>();
            int daysCount = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysCount; day++)
            {
                DateTime date = new DateTime(year, month, day);
             
                daysInMonth.Add(date.ToString("d"));
            }
            
            return daysInMonth;
        }

        public List<ListOfCalendar> GetList()
        {

            DateTime currentDate = DateTime.Now;

            List<string> allDaysInMonth = GetDaysInMonth(currentDate.Year, currentDate.Month);


            List<ListOfCalendar> list = new List<ListOfCalendar>();

            List<CalendarWorkModel> LocalData = GetAllData();


            foreach (string day in allDaysInMonth) 
            {
                list.Add(new ListOfCalendar () 
                {
                    DayTeching = day,
                    Data = LocalData.OrderBy(x=> x.Session).Where( x => x.Schedule == day ).ToList(),
                });
            }

            return list;
        }

        public List<CalendarWorkModel> GetAllData()

        {
          var res =  _unitOfWork.CalendarRepository.GetList().Select( x=> new CalendarWorkModel() 
          {
            Subject = x.Subject,
            LessonName = x.LessonName,
            Session = x.Session,
            Schedule = x.Schedule.ToString("d"),
          } ).ToList();

            return res;
        }
        public string GetDemo ()
        {
          return   _unitOfWork.CalendarRepository.GetTitle();
        }

        public int AddNewDemo()
        {
            _unitOfWork.CalendarRepository.AddNewProduct();
            return 200;
        }
            

    }
}
