using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Models;

namespace Workshop.ViewModels
{
    public class RegisterCarViewModel
    {
        public Customers Customers { get; set; }
        public Cars Cars { get; set; }
        public List<Customers> CustomerList { get; set; }

        public RegisterCarViewModel()
        {
            CustomerList = new List<Customers>();
        }
    }
}
