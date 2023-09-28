using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4_net6.Models
{
    public class CalendarTime : TableHaveIdInt, ITable
    {
        public string Name { get; set; }
        public string BeginWeek { get; set; }
        public string EndWeek { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedIp { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedIp { get; set; }
        public bool DelFlag { get; set; }
    }
}
