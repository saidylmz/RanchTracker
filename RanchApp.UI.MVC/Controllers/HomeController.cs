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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new BLL.CattleController().AllCattleMilksByRanchID((int)Session["Id"]));
        }

        public JsonResult GetCattleData()
        {
            if (new BLL.CattleTypeController().GetAll((int)Session["Id"]).Count > 0)
            {
                List<Data> datas = new List<Data>()
                {
                    new Data{ Name = "CattleType",Count = 0 }
                };

                bool isHave = false;

                foreach (var item in new BLL.CattleTypeController().GetAll((int)Session["Id"]))
                {
                    if (item.Cattles.Count > 0)
                    {
                        isHave = true;
                        datas.Add(new Data { Name = item.Name, Count = item.Cattles.Count() });
                    }
                }
                if (!isHave)
                    datas.Add(new Data { Name = "Yok", Count = 1 });
                return Json(datas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Data> datas = new List<Data>()
                {
                    new Data{ Name = "Yok",Count = 1 }
                };
                return Json(datas, JsonRequestBehavior.AllowGet);
            }

        }

        public class Data
        {
            public string Name;
            public int Count;
        }

        public JsonResult GetInseminationData()
        {
            List<Data> datas = new List<Data>()
            {
                new Data{ Name = "Insemination",Count = 0 }
            };
            List<Insemination> inseminations = new BLL.InseminationController().GetAllInseminationByRanchID((int)Session["Id"]);
            datas.Add(new Data { Name = "45 Gün", Count = inseminations.Where(x => (DateTime.Now - x.Date).Days <= 45).Count() });
            datas.Add(new Data { Name = "210 Gün", Count = inseminations.Where(x => (DateTime.Now - x.Date).Days <= 270 && (DateTime.Now - x.Date).Days > 45).Count() });

            if (datas[1].Count > 0 || datas[2].Count > 0)
                return Json(datas, JsonRequestBehavior.AllowGet);
            else
            {
                datas.Add(new Data { Name = "Yok", Count = 1 });
                return Json(datas, JsonRequestBehavior.AllowGet);
            }
        }
    }
}