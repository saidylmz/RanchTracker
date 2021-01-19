using RanchTracker.DAL.App_Classes;
using RanchTracker.UI.MVC.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RanchTracker.UI.MVC.Controllers
{
    [SessionController]
    public class MilkController : Controller
    {
        // GET: Milk
        // Çiftliğe göre tüm sütler
        public ActionResult Index()
        {
            return View(new BLL.CattleController().AllCattleMilksByRanchID((int)Session["Id"]));
        }

        // Sadece belirtilen ineğin sütleri
        public ActionResult GetMilkByCattleEarringNumber(string EarringNumber)
        {
            return View(new BLL.CattleController().GetCattleByEarringNumber(EarringNumber));
        }

        public ActionResult AddMilk(string EarringNumber)
        {
            return View(new BLL.CattleController().GetCattleByEarringNumber(EarringNumber));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddMilk(Milk milk)
        {
            if (!new BLL.MilkController().AddMilkByEarringNumber(milk))
                return HttpNotFound();
            return RedirectToAction("GetMilkByCattleEarringNumber", new { EarringNumber = milk.CattleID });
        }

        [HttpPost]
        public ActionResult DeleteMilk(int ID,string EarringNumber)
        {
            if (!new BLL.MilkController().DeleteMilkByMilkID(ID))
                return HttpNotFound();
            return RedirectToAction("GetMilkByCattleEarringNumber", new { EarringNumber });
        }

        public ActionResult UpdateMilk(int id)
        {
            return View(new BLL.MilkController().GetMilkForUpdate(id));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateMilk(Milk milk)
        {
            if (!new BLL.MilkController().UpdateMilk(milk))
                return HttpNotFound();
            return RedirectToAction("GetMilkByCattleEarringNumber", new { EarringNumber = milk.CattleID });
        }
    }
}