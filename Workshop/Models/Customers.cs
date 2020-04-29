using System;
using System.Collections.Generic;

namespace Workshop.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string Address { get; set; }
    }
}
