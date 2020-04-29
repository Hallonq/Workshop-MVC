using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Models;

namespace Workshop.ViewModels
{
    public class RepairViewModel
    {
        public Schedule Schedule { get; set; }
        public RepairType RepairType { get; set; }
        public Cars Cars { get; set; }

        public List<Schedule> ScheduleList { get; set; }
        public List<RepairType> RepairTypeList { get; set; }
        public List<Cars> CarList { get; set; }

        public RepairViewModel()
        {
            RepairTypeList = new List<RepairType>();
            ScheduleList = new List<Schedule>();
            CarList = new List<Cars>();
        }
    }
}
