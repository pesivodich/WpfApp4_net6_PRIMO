using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models.WorkModels;
using tblCalendarDetail = WpfApp4_net6.Models.CalendarDetail;


namespace WpfApp4_net6.Repository.IRepository
{
    public interface ICalendarRepository
    {
        public List<tblCalendarDetail> GetList();
        public CalendarDetailWorkModel GetFirst();
        public int AddNewProduct();
        string GetTitle();
    }
}
