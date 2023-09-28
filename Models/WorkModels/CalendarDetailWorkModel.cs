using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Models.WorkModels
{
    public class CalendarDetailWorkModel
    {
        public string Subject { get; set; }
        public string LessonName { get; set; }
        public int Session { get; set; }
        public DateTimeOffset Schedule { get; set; }
    }
}
