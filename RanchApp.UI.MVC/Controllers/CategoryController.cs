using RanchApp.DAL.App_Classes;
using RanchApp.UI.MVC.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace RanchApp.UI.MVC.Controllers
{
    [SessionController]
    public class CategoryController : Controller
    {
        // GET: Home
        public ActionResult Index()
        { 
            return View(new BLL.CategoryController().GetCategories());
        }


        public void SendMail()
        {
            new BLL.CategoryController().Email();
        }
       
    }
}