using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_net_homework_1.Repositories;
using asp_net_homework_1.ViewModels;

namespace asp_net_homework_3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List(string accountType)
        {
            ViewBag.AccountType = accountType;
            ClientAccountRepo caRepo = new ClientAccountRepo();
            IEnumerable<ClientAccountVM> list = caRepo.GetList(accountType);
            return View(list);
        }
        [HttpGet]
        public ActionResult Detail(int clientId, int accountNum)
        {
            ClientAccountRepo caRepo = new ClientAccountRepo();
            ClientAccountVM clientAccount = caRepo.Get(clientId, accountNum);
            return View(clientAccount);
        }
        [HttpGet]
        public ActionResult Edit(int clientId, int accountNum)
        {
            ClientAccountRepo caRepo = new ClientAccountRepo();
            ClientAccountVM clientAccount = caRepo.Get(clientId, accountNum);
            return View(clientAccount);
        }
        [HttpPost]
        public ActionResult Edit(ClientAccountVM ca)
        {
            // Only save on server is model is valid.
            if(ModelState.IsValid) {
                ClientAccountRepo caRepo = new ClientAccountRepo();
                caRepo.Edit(ca);
            }
            return RedirectToAction("Detail", "Home", new { clientId = ca.clientID, accountNum = ca.accountNum });
        }
    }
}