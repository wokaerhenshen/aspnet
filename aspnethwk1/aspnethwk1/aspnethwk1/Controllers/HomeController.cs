using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspnethwk1.Repositories;
using aspnethwk1.ViewModels;

namespace aspnethwk1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            return View();

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Choice(string accountType)
        {
            AccountSummary acSum = new AccountSummary();
            IEnumerable<ClientBankAccountVM> cba = acSum.GetSummary(accountType);
            return View(cba);
        }

        [HttpGet]
        public ActionResult Details(int accountID, int clientID)
        {
            AccountSummary asy = new AccountSummary();
            ClientBankAccountVM result = asy.GetDetail(accountID, clientID);
            return View(result);
        }

        [HttpGet]
        public ActionResult Edit(int accountID, int clientID)
        {
            AccountSummary asy = new AccountSummary();
            ClientBankAccountVM result = asy.GetDetail(accountID, clientID);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(ClientBankAccountVM cba)
        {
            AccountSummary asm = new AccountSummary();
            asm.Update(cba);
            return RedirectToAction("Index","Home");
        }

    }
}