using Assignment2Hint.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2Hint.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            // To get this to work you will need to add a few people to the Volunteer table.
            // Try to add some people manually in SQL from SQL Server Management studio.
            VolunteerSchedulerEntities db = new VolunteerSchedulerEntities();
            ViewBag.Schedules  = db.Schedules;
            ViewBag.Volunteers = db.Volunteers; 
            return View();
        }

        [HttpPost]
        public ActionResult Index(TaskAssignmentListVM taVM) { 
            // Set a breakpoint here to observe the selected values when the user
            // submits the form.
            Volunteer volunteer = new Volunteer();
            return RedirectToAction("Index", "Home");
        }
    }
}