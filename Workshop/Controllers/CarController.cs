using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Workshop.Models;
using Workshop.ViewModels;

namespace Workshop.Controllers
{
    public class CarController : Controller
    {
        private readonly WorkshopContext _context;

        public CarController(WorkshopContext context)
        {
            _context = context;
        }

        public IActionResult ListofCustomers()
        {
            var model = new RegisterCarViewModel();
            model.CustomerList = _context.Customers.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCar(RegisterCarViewModel model)
        {
            if (ModelState.IsValid)
            {
                var car = new Cars
                {
                    CustomerId = model.Customers.CustomerId,
                    CarId = model.Cars.CarId
                };

                _context.Cars.Add(car);
                _context.SaveChanges();
                TempData["Operation"] = "Car Registration Successful.";
                return RedirectToAction("Index", "Home", TempData);
            }

            return View(model);
        }
    }
}
