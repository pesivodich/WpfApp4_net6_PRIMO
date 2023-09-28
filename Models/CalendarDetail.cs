using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Models
{
    public class CalendarDetail : TableHaveIdInt, ITable
    {
        public string Subject { get; set; }
        public string LessonName { get; set; }
        public int Session { get; set; }
        public DateTimeOffset Schedule { get; set; }
        public DateTimeOffset CreatedAt { get; set; }   
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedIp { get; set; }
        public bool DelFlag { get; set; }
    }
}
