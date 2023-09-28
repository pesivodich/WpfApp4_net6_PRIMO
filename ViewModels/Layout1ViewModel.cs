using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4_net6.Models;
using WpfApp4_net6.Repository;
using WpfApp4_net6.Services.IServices;
using WpfApp4_net6.Views;
using WpfApp4_net6.Models.WorkModels;
using WpfApp4_net6.Models.WorkModels.CalendarWorkModel;
using System.Globalization;
using WpfApp4_net6.Services;
using System.Windows.Markup;

namespace WpfApp4_net6.ViewModels
{
    public class Layout1ViewModel : ViewModelBase
    {

        private ObservableCollection<DayTeach> dateTeaching;

        public ObservableCollection<DayTeach> DateTeaching 
        {
            get
            {
                return dateTeaching;
            }
            set
            {
                dateTeaching = value;
                OnPropertyChanged(nameof(DateTeaching));    
            }
        }


        private ObservableCollection<CalendarDashboard> calendarDashboards;

        public ObservableCollection<CalendarDashboard> CalendarDashboards {
            get
            {
                return calendarDashboards;
            }
            set 
            {
                calendarDashboards = value;
                OnPropertyChanged(nameof(CalendarDashboards));
            } 
        }
        private ObservableCollection<CalendarWorkModel> dataGridMonday;

        public ObservableCollection<CalendarWorkModel> DataGridMonday 
        {
            get
            {
                return dataGridMonday;
            }
            set 
            {
                dataGridMonday = value;
                OnPropertyChanged(nameof(DataGridMonday));
            }
        }

        private ObservableCollection<CalendarWorkModel> dataGridTuesday;

        public ObservableCollection<CalendarWorkModel> DataGridTuesday
        {
            get
            {
                return dataGridTuesday;
            }
            set
            {
                dataGridTuesday = value;
                OnPropertyChanged(nameof(dataGridTuesday));
            }
        }

        private ObservableCollection<CalendarWorkModel> dataGridWednesday;

        public ObservableCollection<CalendarWorkModel> DataGridWednesday
        {
            get
            {
                return dataGridWednesday;
            }
            set
            {
                dataGridWednesday = value;
                OnPropertyChanged(nameof(DataGridWednesday));
            }
        }

        private ObservableCollection<CalendarWorkModel> dataGridThursday;

        public ObservableCollection<CalendarWorkModel> DataGridThursday
        {
            get
            {
                return dataGridThursday;
            }
            set
            {
                dataGridThursday = value;
                OnPropertyChanged(nameof(DataGridThursday));
            }
        }

        private ObservableCollection<CalendarWorkModel> dataGridFriday;

        public ObservableCollection<CalendarWorkModel> DataGridFriday
        {
            get
            {
                return dataGridFriday;
            }
            set
            {
                dataGridFriday = value;
                OnPropertyChanged(nameof(DataGridFriday));
            }
        }

        private ObservableCollection<CalendarWorkModel> dataGridSaturday;

        public ObservableCollection<CalendarWorkModel> DataGridSaturday
        {
            get
            {
                return dataGridSaturday;
            }
            set
            {
                dataGridSaturday = value;
                OnPropertyChanged(nameof(DataGridSaturday));
            }
        }
        private ObservableCollection<CalendarWorkModel> dataGridSunday;

        public ObservableCollection<CalendarWorkModel> DataGridSunday
        {
            get
            {
                return dataGridSunday;
            }
            set
            {
                dataGridSunday = value;
                OnPropertyChanged(nameof(DataGridSunday));
            }
        }

        private ObservableCollection<CalendarTimeWorkModel> calendarTimes;

        public ObservableCollection<CalendarTimeWorkModel> CalendarTimes 
        {
            get
            {
                return calendarTimes;
            }
            set
            {
                calendarTimes = value;
                OnPropertyChanged(nameof(CalendarTimes));
            }
        }

        private CalendarTimeWorkModel selectedItem;

        public CalendarTimeWorkModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                if(SelectedItem != null)
                {
                    InitData();
                }
             }
        }



        private readonly ICalendarServices _calendarServices;
        private readonly ICalendarTimeServices _calendarTimeServices;
        public Layout1ViewModel (ICalendarServices calendarServices
            , ICalendarTimeServices calendarTimeServices)
        {
            _calendarServices = calendarServices;
            _calendarTimeServices = calendarTimeServices;
           
            List<ListOfCalendar> getData = _calendarServices.GetList();

            CalendarTimes = new ObservableCollection<CalendarTimeWorkModel>(_calendarTimeServices.GetAllData());
       
            InitData();
        }


        private void InitData()
        {
           
            DateTime Today = ConvertToDateTime(DateTime.Now.ToString("d"), "dd/MM/yyyy");
            List<ListOfCalendar> getData = _calendarServices.GetList();

            if(getData.Count == 0)
            {
                return;
            }

            if (SelectedItem != null)
            {
                Today = ConvertToDateTime(SelectedItem.BeginWeek, "dd/MM/yyyy");

            }
            int CountDay = 7;
            List<ListOfCalendar> getData7Days = getData.Where(x => ConvertToDateTime(x.DayTeching, "dd/MM/yyyy") >= Today && ConvertToDateTime(x.DayTeching, "dd/MM/yyyy") <= Today.AddDays(6)).ToList();

            int j = CountDay - getData7Days.Count;

            if (CountDay - getData7Days.Count != 0)
            {
                string LastDayInList = getData7Days.OrderByDescending(x => ConvertToDateTime(x.DayTeching, "dd/MM/yyyy")).FirstOrDefault().DayTeching;
                for (int i = 1; i<=j;  i++) 
                {
                    getData7Days.Add(new ListOfCalendar() 
                    { 
                        DayTeching = ConvertToDateTime(LastDayInList, "dd/MM/yyyy").AddDays(i).ToString("d"),
                        Data = new List<CalendarWorkModel> { new CalendarWorkModel() {LessonName = "",Subject="",Schedule = "" } }
                    });
                }
            }

            string[] OnWeek = getData7Days.Select(x => x.DayTeching).ToArray();

            DateTeaching = new ObservableCollection<DayTeach>() { new DayTeach()
            {
                Monday = OnWeek[0],
                Tuesday = OnWeek[1],
                Wednesday = OnWeek[2],
                Thursday = OnWeek[3],
                Friday = OnWeek[4],
                Saturday = OnWeek[5],
                Sunday = OnWeek[6],
            } };

            CalendarDashboards = new ObservableCollection<CalendarDashboard>()
            { 
                new CalendarDashboard()
                {
                    DataMonday = new ListOfCalendar ()
                    {
                    DayTeching = OnWeek[0]
                    , Data = getData.Where(x => x.DayTeching == OnWeek[0]).Select(x => x.Data).FirstOrDefault() ?? new List < CalendarWorkModel > { new CalendarWorkModel() { LessonName = "", Subject = "", Schedule = "" } } 
                    } ,
                    DataTuesday = new ListOfCalendar ()
                    {
                    DayTeching = OnWeek[1]
                    , Data = getData.Where( x=> x.DayTeching ==  OnWeek[1]).Select( x=> x.Data).FirstOrDefault() ?? new List<CalendarWorkModel> { new CalendarWorkModel() {LessonName = "",Subject="",Schedule = "" } }
                    } ,
                    DataWednesday = new ListOfCalendar ()
                    {
                    DayTeching = OnWeek[2]
                    ,  Data = getData.Where( x=> x.DayTeching ==  OnWeek[2]).Select( x=> x.Data).FirstOrDefault() ?? new List<CalendarWorkModel> { new CalendarWorkModel() {LessonName = "",Subject="",Schedule = "" } }
                    } ,
                    DataThursday = new ListOfCalendar ()
                    {
                    DayTeching = OnWeek[3]
                    ,  Data = getData.Where( x=> x.DayTeching ==  OnWeek[3]).Select( x=> x.Data).FirstOrDefault() ?? new List<CalendarWorkModel> { new CalendarWorkModel() {LessonName = "",Subject="",Schedule = "" } }
                    } ,
                    DataFriday = new ListOfCalendar ()
                    {
                        DayTeching = OnWeek[4]
                    ,  Data = getData.Where( x=> x.DayTeching ==  OnWeek[4]).Select( x=> x.Data).FirstOrDefault() ?? new List<CalendarWorkModel> { new CalendarWorkModel() {LessonName = "",Subject="",Schedule = "" } }
                    } ,
                    DataSaturday = new ListOfCalendar ()
                    {
                    DayTeching = OnWeek[5]
                    ,  Data = getData.Where( x=> x.DayTeching ==  OnWeek[5]).Select( x=> x.Data).FirstOrDefault() ?? new List<CalendarWorkModel> { new CalendarWorkModel() {LessonName = "",Subject="",Schedule = "" } }
                    },
                    DataSunday = new ListOfCalendar ()
                    {
                    DayTeching = OnWeek[6]
                    ,   Data = getData.Where( x=> x.DayTeching ==  OnWeek[6]).Select( x=> x.Data).FirstOrDefault() ?? new List<CalendarWorkModel> { new CalendarWorkModel() {LessonName = "",Subject="",Schedule = "" } }
                    },
                }
            };

            DataGridMonday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataMonday.Data);
            DataGridTuesday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataTuesday.Data);
            DataGridWednesday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataWednesday.Data);
            DataGridThursday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataThursday.Data);
            DataGridFriday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataFriday.Data);
            DataGridSaturday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataSaturday.Data);
            DataGridSunday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataSunday.Data);
        }
        public static DateTime ConvertToDateTime(string input, string format)
        {
            DateTime result;
            if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                // Trả về DateTime.MinValue nếu chuỗi không hợp lệ
                return DateTime.MinValue;
            }
        }

    }
}
