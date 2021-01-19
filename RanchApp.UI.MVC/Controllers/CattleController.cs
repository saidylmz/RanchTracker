using RanchApp.DAL.App_Classes;
using RanchApp.UI.MVC.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RanchApp.UI.MVC.Controllers
{
    [SessionController]
    public class CattleController : Controller
    {
        // GET: Cattle
        public ActionResult Index(int CattleTypeID)
        {
            if (Session["Id"] == null)
                return RedirectToAction("Logout", "Login");
            return View(new BLL.CattleController().GetCattlesByCattleTypeID(CattleTypeID,(int)Session["Id"]));
        }

        public ActionResult AddCattle()
        {
            return View(new BLL.CattleTypeController().GetAll((int)Session["Id"]));
        }

        [HttpPost]
        public bool AddControl(string EarringNumber)
        {
            return !new BLL.CattleController().AnyEarringNumber(EarringNumber);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddCattle(Cattle cattle)
        {
            if (!new BLL.CattleController().AddCattle(cattle))
                return View("AddCattle", new BLL.CattleTypeController().GetAll(cattle.RanchID));
            return RedirectToAction("Index", new { CattleTypeID = cattle.CattleTypeID });
        }

        public ActionResult UpdateCattle(string EarringNumber)
        {
            return View(new BLL.CattleController().GetCattleByEarringNumber(EarringNumber));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateCattle(Cattle cattle)
        {
            if (!new BLL.CattleController().UpdateCattle(cattle))
                return HttpNotFound();
            return RedirectToAction("Index", new { cattle.CattleTypeID });
        }
       
        [HttpPost]
        public ActionResult DeleteCattle(string EarringNumber,int CattleTypeID)
        {
            if (!new BLL.CattleController().DeleteCattle(EarringNumber))
                return HttpNotFound();
            return RedirectToAction("Index", new { CattleTypeID });
        }
    }
}