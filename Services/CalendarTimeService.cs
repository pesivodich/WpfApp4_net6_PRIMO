using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models.WorkModels.CalendarWorkModel;
using WpfApp4_net6.Repository;
using WpfApp4_net6.Services.IServices;
using tblCalendarTime = WpfApp4_net6.Models.CalendarTime;

namespace WpfApp4_net6.Services
{
    public class CalendarTimeService : ICalendarTimeServices
    {
        IUnitOfWork _unitOfWork;
        public CalendarTimeService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public List<CalendarTimeWorkModel> GetAllData()
        {
            List<CalendarTimeWorkModel> res = new List<CalendarTimeWorkModel>();

            res = _unitOfWork.CalendarTimeRepo.GetList().Select(x => new CalendarTimeWorkModel()
            {
                Name = x.Name,
                BeginWeek = x.BeginWeek,
                EndWeek = x.EndWeek,
            })
            .ToList();

            return res;
        }

        public int AddNewItem (CalendarTimeWorkModel input) 
        {
            if (input == null)
            {
                return 500;
            }

            tblCalendarTime newItem = new tblCalendarTime()
            { 
                Name=input.Name,
                BeginWeek = input.BeginWeek,
                EndWeek = input.EndWeek,
            };
            _unitOfWork.CalendarTimeRepo.AddNew(newItem);

            return 200;
        }
    }
}
