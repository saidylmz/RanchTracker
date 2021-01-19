using RanchTracker.DAL.App_Classes;
using RanchTracker.UI.MVC.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace RanchTracker.UI.MVC.Controllers
{
    [SessionController]
    public class AdminController : Controller
    {
        public ActionResult AddCategory()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddCategory(Category category, HttpPostedFileBase File)
        { 
            if (!new BLL.AdminController().AddCategory(category,new WebImage(File.InputStream).GetBytes()))
                return HttpNotFound();
            return RedirectToAction("Index","Home");
        }

        public ActionResult AddRanch()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddRanch(Ranch ranch,HttpPostedFileBase File)
        {
            if (!new BLL.AdminController().AddRanch(ranch, new WebImage(File.InputStream).GetBytes()))
                return HttpNotFound();
            return RedirectToAction("Index", "Home");
        }

        
    }
}