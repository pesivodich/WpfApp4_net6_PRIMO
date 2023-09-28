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

namespace WpfApp4_net6.ViewModels
{
    public class Layout1ViewModel : ViewModelBase
    {

        private string PickDate { get; set; }
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

        private ObservableCollection<CalendarTime> calendarTimes;

        public ObservableCollection<CalendarTime> CalendarTimes 
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

        private CalendarTime selectedItem;

        public CalendarTime SelectedItem
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
        public Layout1ViewModel (ICalendarServices calendarServices)
        {
            _calendarServices = calendarServices;
           
            List<ListOfCalendar> getData = _calendarServices.GetList();

            CalendarTimes = new ObservableCollection<CalendarTime>();

            CalendarTimes.Add(new CalendarTime() { Name = "Son", BeginWeek= "11/09/2023", EndWeek="" });
            CalendarTimes.Add(new CalendarTime() { Name = "Son 1", BeginWeek= "12/09/2023", EndWeek="" });
            CalendarTimes.Add(new CalendarTime() { Name = "Son 2", BeginWeek= "13/09/2023", EndWeek="" });
            CalendarTimes.Add(new CalendarTime() { Name = "Son 3", BeginWeek= "14/09/2023", EndWeek="" });

            //   string[] OnWeek = getData.Select(x => x.DayTeching.Substring(0, 5)).Take(7).ToArray();
            //string[] OnWeek = getData.Select(x => x.DayTeching).Take(7).ToArray();
            //DateTime Today = ConvertToDateTime("20/09/2023", "dd/MM/yyyy");

            //if (SelectedItem != null)
            //{
            //     Today = ConvertToDateTime(SelectedItem.BeginWeek, "dd/MM/yyyy");

            //}
            //List<ListOfCalendar> getData7Days = getData.Where(x=> ConvertToDateTime(x.DayTeching, "dd/MM/yyyy") >= Today && ConvertToDateTime(x.DayTeching, "dd/MM/yyyy") <= Today.AddDays(6)).ToList();
            ////string[] OnWeek = { "20/09/2023", "21/09/2023", "22/09/2023", "23/09/2023", "24/09/2023", "25/09/2023", "27/09/2023" };
            //string[] OnWeek = getData7Days.Select(x => x.DayTeching).ToArray();

            //DateTeaching = new ObservableCollection<DayTeach>() { new DayTeach() 
            //{
            //    Monday = OnWeek[0],
            //    Tuesday = OnWeek[1],
            //    Wednesday = OnWeek[2],
            //    Thursday = OnWeek[3],
            //    Friday = OnWeek[4],
            //    Saturday = OnWeek[5],
            //    Sunday = OnWeek[6],
            //} };

            //CalendarDashboards = new ObservableCollection<CalendarDashboard>() { new CalendarDashboard() 
            //    {
            //     DataMonday = new ListOfCalendar () 
            //     {
            //       DayTeching = OnWeek[0]
            //     , Data = getData.Where( x=> x.DayTeching == OnWeek[0]).Select( x=> x.Data).FirstOrDefault()
            //     } ,
            //    DataTuesday = new ListOfCalendar () 
            //     {
            //       DayTeching = OnWeek[1]
            //     , Data = getData.Where( x=> x.DayTeching ==  OnWeek[1]).Select( x=> x.Data).FirstOrDefault()
            //     } ,
            //     DataWednesday = new ListOfCalendar ()
            //     {
            //       DayTeching = OnWeek[2]
            //     , Data = getData.Where( x=> x.DayTeching ==  OnWeek[2]).Select( x=> x.Data).FirstOrDefault()
            //     } ,
            //      DataThursday = new ListOfCalendar ()
            //     {
            //       DayTeching = OnWeek[3]
            //     , Data = getData.Where( x=> x.DayTeching ==  OnWeek[3]).Select( x=> x.Data).FirstOrDefault()
            //     } ,
            //       DataFriday = new ListOfCalendar ()
            //     {
            //       DayTeching = OnWeek[4]
            //     , Data = getData.Where( x=> x.DayTeching ==  OnWeek[4]).Select( x=> x.Data).FirstOrDefault()
            //     } ,
            //    DataSaturday = new ListOfCalendar ()
            //     {
            //       DayTeching = OnWeek[5]
            //     , Data = getData.Where( x=> x.DayTeching ==  OnWeek[5]).Select( x=> x.Data).FirstOrDefault()
            //     },
            //    DataSunday = new ListOfCalendar ()
            //     {
            //       DayTeching = OnWeek[6]
            //     , Data = getData.Where( x=> x.DayTeching ==  OnWeek[6]).Select( x=> x.Data).FirstOrDefault()
            //     },
            //    } 
            //};

            //DataGridMonday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataMonday.Data);
            //DataGridTuesday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataTuesday.Data);
            //DataGridWednesday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataWednesday.Data);
            //DataGridThursday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataThursday.Data);
            //DataGridFriday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataFriday.Data);
            //DataGridSaturday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataSaturday.Data);
            //DataGridSunday = new ObservableCollection<CalendarWorkModel>(CalendarDashboards.FirstOrDefault().DataSunday.Data);
            InitData();
        }


        private void InitData()
        {
            DateTime Today = ConvertToDateTime("21/09/2023", "dd/MM/yyyy");
            List<ListOfCalendar> getData = _calendarServices.GetList();

            if (SelectedItem != null)
            {
                Today = ConvertToDateTime(SelectedItem.BeginWeek, "dd/MM/yyyy");

            }
            List<ListOfCalendar> getData7Days = getData.Where(x => ConvertToDateTime(x.DayTeching, "dd/MM/yyyy") >= Today && ConvertToDateTime(x.DayTeching, "dd/MM/yyyy") <= Today.AddDays(6)).ToList();
            //string[] OnWeek = { "20/09/2023", "21/09/2023", "22/09/2023", "23/09/2023", "24/09/2023", "25/09/2023", "27/09/2023" };
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

            CalendarDashboards = new ObservableCollection<CalendarDashboard>() { new CalendarDashboard()
                {
                 DataMonday = new ListOfCalendar ()
                 {
                   DayTeching = OnWeek[0]
                 , Data = getData.Where( x=> x.DayTeching == OnWeek[0]).Select( x=> x.Data).FirstOrDefault()
                 } ,
                DataTuesday = new ListOfCalendar ()
                 {
                   DayTeching = OnWeek[1]
                 , Data = getData.Where( x=> x.DayTeching ==  OnWeek[1]).Select( x=> x.Data).FirstOrDefault()
                 } ,
                 DataWednesday = new ListOfCalendar ()
                 {
                   DayTeching = OnWeek[2]
                 , Data = getData.Where( x=> x.DayTeching ==  OnWeek[2]).Select( x=> x.Data).FirstOrDefault()
                 } ,
                  DataThursday = new ListOfCalendar ()
                 {
                   DayTeching = OnWeek[3]
                 , Data = getData.Where( x=> x.DayTeching ==  OnWeek[3]).Select( x=> x.Data).FirstOrDefault()
                 } ,
                   DataFriday = new ListOfCalendar ()
                 {
                   DayTeching = OnWeek[4]
                 , Data = getData.Where( x=> x.DayTeching ==  OnWeek[4]).Select( x=> x.Data).FirstOrDefault()
                 } ,
                DataSaturday = new ListOfCalendar ()
                 {
                   DayTeching = OnWeek[5]
                 , Data = getData.Where( x=> x.DayTeching ==  OnWeek[5]).Select( x=> x.Data).FirstOrDefault()
                 },
                DataSunday = new ListOfCalendar ()
                 {
                   DayTeching = OnWeek[6]
                 , Data = getData.Where( x=> x.DayTeching ==  OnWeek[6]).Select( x=> x.Data).FirstOrDefault()
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
