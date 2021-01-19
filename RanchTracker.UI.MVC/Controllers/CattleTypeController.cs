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
    public class CattleTypeController : Controller
    {
        // GET: CattleType
        public ActionResult Index(int CategoryID)
        { 
            return View(new BLL.CattleTypeController().GetCattleTypesByCategoryID(CategoryID,(int)Session["Id"]));
        }

        public ActionResult AddCattleType()
        {
            return View(new BLL.CategoryController().GetCategories());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddCattleType(CattleType cattleType)
        {
            if (!new BLL.CattleTypeController().AddCattleType(cattleType))
            {
                ViewBag.Message = "Aynı isimde tür mevcut !!";
                return View("AddCattleType", new BLL.CategoryController().GetCategories());
            }
                
            return RedirectToAction("Index",new {CategoryID = cattleType.CategoryID });
        }

        [HttpPost]
        public ActionResult DeleteCattleType(int CattleTypeID)
        {
            BLL.CattleTypeController cTContoller = new BLL.CattleTypeController();
            CattleType cattleType = cTContoller.GetAll((int)Session["Id"]).FirstOrDefault(x => x.ID == CattleTypeID);
            if (!cTContoller.DeleteCattleType(cattleType) || cattleType == null)
                return HttpNotFound();
            return RedirectToAction("Index", new { cattleType.CategoryID });
        }
    }
}