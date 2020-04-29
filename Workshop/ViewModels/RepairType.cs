using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.ViewModels
{
    public class RepairType
    {
        public int RepairTypeID { get; set; }
        public string RepairTypeName { get; set; }

        public RepairType(int id, string name)
        {
            RepairTypeID = id;
            RepairTypeName = name;
        }

        public RepairType()
        {
        }
    }
}
