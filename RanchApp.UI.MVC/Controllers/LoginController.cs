using RanchTracker.DAL.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RanchTracker.UI.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.UserName = GetCookie("UserName");
            ViewBag.Password = GetCookie("UserPassword");
            return View();
        }

        [HttpPost]
        public bool Login(string UserName, string UserPassword, bool RememberMe, string token)
        {
            BLL.LoginController loginController = new BLL.LoginController();
            Ranch rn = loginController.Login(UserName, UserPassword);
            if (rn == null)
                return false;
            else
            {
                if (RememberMe)
                {
                    FormsAuthentication.SetAuthCookie(UserName, true);
                    CreateCookie("UserName", rn.UserName);
                    CreateCookie("UserPassword", rn.UserPassword);
                     
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(UserName, false);
                    DeleteCookie("UserName");
                    DeleteCookie("UserPassword");
                }

                Session.Add("Username", rn.UserName);
                Session.Add("Id", rn.ID);
                Session.Add("Name", rn.Name);
                Session.Add("Logo", rn.Logo);
                Session.Add("Role", rn.Role);
                if (token != null)
                {
                    new BLL.LoginController().RegisterToken(token, rn.ID);
                }
                return true;
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        private void CreateCookie(string name, string value)
        {
            HttpCookie cookieVisitor = new HttpCookie(name, value);
            Response.Cookies.Add(cookieVisitor);
            Response.Cookies[name].Expires = DateTime.Now.AddMonths(1);
        }

        private string GetCookie(string name)
        {
            if (Request.Cookies.AllKeys.Contains(name))
            {
                return Request.Cookies[name].Value;
            }
            return null;
        }
        private void DeleteCookie(string name)
        {
            if (GetCookie(name) != null)
            { 
                Response.Cookies.Remove(name); 
                Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            }
        }

    }
}