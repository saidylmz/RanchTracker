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
    public class InseminationController : Controller
    {
        // Çiftlikteki Çiftleşmiş İnekler
        public ActionResult Index()
        {
            return View(new BLL.InseminationController().GetAllInseminationByRanchID((int)Session["Id"]));
        }

        public ActionResult AddInsemination(string EarringNumber)
        {
            return View(new BLL.CattleController().GetCattleByEarringNumber(EarringNumber));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddInsemination(Insemination insemination)
        {
            if (!new BLL.InseminationController().AddInseminationForCattle(insemination))
                return HttpNotFound();
            return RedirectToAction("Index", "Cattle", new { new BLL.CattleController().GetCattleByEarringNumber(insemination.CattleID).CattleTypeID });
        }

        [HttpPost]
        public ActionResult CancelInsemination(int id)
        {
            if (!new BLL.InseminationController().CancelInsemination(id))
                return HttpNotFound();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void UpdateInsemination(int id, string date)
        {
            new BLL.InseminationController().UpdateInsemination(id, date);
        }

        public ActionResult DeleteAllInsemination(string EarringNumber)
        {
            new BLL.InseminationController().DeleteAllInsemination(EarringNumber);
            return RedirectToAction("Index");
        }
    }
}