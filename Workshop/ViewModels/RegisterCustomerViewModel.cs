using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.ViewModels
{
    public class RegisterCustomerViewModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public int SocialSecurityNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
