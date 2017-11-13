using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspnetinclass4b.BusinessLogic;

namespace aspnetinclass4b.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpPost]
        public ActionResult SetUser(string txtName)
        {
            CookieHelper cookieHelper = new CookieHelper();
            cookieHelper.SetCookie(CookieHelper.USER_NAME, txtName);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SetColor(string color)
        {
            CookieHelper cookieHelper = new CookieHelper();
            cookieHelper.SetCookie(CookieHelper.COLOR, color);
            Content("body");
            return RedirectToAction("Index");
        }

        public ActionResult ClearCookie()
        {
            CookieHelper cookieHelper = new CookieHelper();
            cookieHelper.ClearCookie(CookieHelper.USER_NAME);
            return RedirectToAction("Index");
        }

        public ActionResult ClearCookieColor()
        {
            CookieHelper cookieHelper = new CookieHelper();
            cookieHelper.ClearCookie(CookieHelper.COLOR);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            CookieHelper cookieHelper = new CookieHelper();
            ViewBag.UserName = cookieHelper.GetCookie(CookieHelper.USER_NAME);
            ViewBag.Color = cookieHelper.GetCookie(CookieHelper.COLOR);
            return View();
        }

        public ActionResult jsShowCookie()
        {
            return View();
        }

    }
}