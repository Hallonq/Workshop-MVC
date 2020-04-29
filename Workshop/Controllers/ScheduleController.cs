using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Workshop.Models;
using Workshop.ViewModels;

namespace Workshop.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly WorkshopContext _context;

        public ScheduleController(WorkshopContext context)
        {
            _context = context;
        }

        public IActionResult Schedule()
        {
            //RepairViewModel model = new RepairViewModel();

            //string sql = $"SELECT * FROM Schedule";
            //DBManager dbm = new DBManager(sql);
            //DataTable tbl = dbm.ExecuteSQL();

            //List<DateTime> dateList = new List<DateTime>();
            //foreach (DataRow row in tbl.Rows)
            //{
            //    dateList.Add((DateTime)row["Date"]);
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    // Date 25 & under.
            //    if (DateTime.Now.Day <= 25)
            //    {
            //        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + i, 09, 00, 00);
            //        Schedule temp = new Schedule(i, date);
            //        if (!dateList.Contains(date))
            //        {
            //            model.ScheduleList.Add(temp);
            //        }
            //    }

            //    // Date over 25.
            //    else
            //    {
            //        // Current month contains 30 days.
            //        if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == 30)
            //        {
            //            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day - DateTime.Now.Day + 1 + i, 09, 00, 00);
            //            var temp = new Schedule(i, date);
            //            if (!dateList.Contains(date))
            //            {
            //                model.ScheduleList.Add(temp);
            //            }
            //        }

            //        // Current month contains 31 days.
            //        else if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == 31)
            //        {
            //            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 6, 09, 00, 00);
            //            var temp = new Schedule(i, date);
            //            if (!dateList.Contains(date))
            //            {
            //                model.ScheduleList.Add(temp);
            //            }
            //        }
            //    }
            //}

            RepairViewModel model = getScheduleList();

            model.CarList = _context.Cars.ToList();

            model.RepairTypeList.Add(new RepairType(1, "Service"));
            model.RepairTypeList.Add(new RepairType(2, "Repair"));
            model.RepairTypeList.Add(new RepairType(3, "Other"));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Schedule(RepairViewModel model)
        {
            if (ModelState.IsValid)
            {
                var schedule = new Schedule
                {
                    CarId = model.Cars.CarId,
                    DateId = model.Cars.CarId,
                    Date = model.Schedule.Date,
                    RepairType = model.RepairType.RepairTypeName
                };

                int tableLength = _context.Schedule.ToList().Count();
                if (tableLength < 5)
                {
                    _context.Schedule.Add(schedule);
                    _context.SaveChanges();
                    TempData["Operation"] = "Repair Registration Successful.";
                    return RedirectToAction("Index", "Home", TempData);
                }

                else
                {
                    TempData["Operation"] = "Workshop currently full, come back another day.";
                    return RedirectToAction("Index", "Home", TempData);
                }
            }

            return View(model);
        }

        public IActionResult Remove()
        {
            RepairViewModel model = new RepairViewModel();
            model.ScheduleList = _context.Schedule.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(RepairViewModel model)
        {
            string sql = $"Delete Schedule FROM Schedule WHERE Date = '{ model.Schedule.Date }'";
            DBManager dbm = new DBManager(sql);
            dbm.ExecuteSQLNoReturn();

            TempData["Operation"] = "Appointment Successfully Removed.";
            return RedirectToAction("Index", "Home", TempData);
        }

        // Metod för att hämta/skapa datum.
        public RepairViewModel getScheduleList()
        {
            RepairViewModel model = new RepairViewModel();

            string sql = $"SELECT * FROM Schedule";
            DBManager dbm = new DBManager(sql);
            DataTable tbl = dbm.ExecuteSQL();

            List<DateTime> dateList = new List<DateTime>();
            foreach (DataRow row in tbl.Rows)
            {
                dateList.Add((DateTime)row["Date"]);
            }

            for (int i = 0; i < 5; i++)
            {
                // Date 25 & under.
                if (DateTime.Now.Day <= 25)
                {
                    DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + i, 09, 00, 00);
                    Schedule temp = new Schedule(i, date);
                    if (!dateList.Contains(date))
                    {
                        model.ScheduleList.Add(temp);
                    }
                }

                // Date over 25.
                else
                {
                    // Current month contains 30 days.
                    if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == 30)
                    {
                        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day - DateTime.Now.Day + 1 + i, 09, 00, 00);
                        var temp = new Schedule(i, date);
                        if (!dateList.Contains(date))
                        {
                            model.ScheduleList.Add(temp);
                        }
                    }

                    // Current month contains 31 days.
                    else if (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == 31)
                    {
                        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 6, 09, 00, 00);
                        var temp = new Schedule(i, date);
                        if (!dateList.Contains(date))
                        {
                            model.ScheduleList.Add(temp);
                        }
                    }
                }
            }

            return model;
        }
    }
}
