using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Models;
using Workshop.ViewModels;

namespace Workshop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly WorkshopContext _context;

        public CustomerController(WorkshopContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterCustomerViewModel user)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customers
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    SocialSecurityNumber = user.SocialSecurityNumber,
                    Address = user.Address
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();
                TempData["Operation"] = "Customer Registration Successful.";
                return RedirectToAction("Index", "Home", TempData);
            }

            return View(user);
        }
    }
}
