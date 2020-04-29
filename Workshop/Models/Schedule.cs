using System;
using System.Collections.Generic;

namespace Workshop.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int CarId { get; set; }
        public int DateId { get; set; }
        public DateTime Date { get; set; }
        public string RepairType { get; set; }

        public Schedule(int dateId, DateTime date)
        {
            DateId = dateId;
            Date = date;
        }
        
        public Schedule()
        {
        }
    }
}
