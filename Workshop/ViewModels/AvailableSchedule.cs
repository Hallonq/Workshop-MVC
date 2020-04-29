using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.ViewModels
{
    public class AvailableSchedule
    {
        public int ScheduleId { get; set; }
        public int CarId { get; set; }
        public int DateId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MMMMM-dd}")]
        public DateTime Date { get; set; }
        public int RepairTypeId { get; set; }

        public AvailableSchedule(int id, DateTime date)
        {
            DateId = id;
            Date = date;
        }

        public AvailableSchedule()
        {
        }
    }
}
