using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBtc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            JY.BLL.Advert bll = new JY.BLL.Advert();
            ViewData["BindAd"] = Collections.DataToList.ToList < JY.Model.Advert>( bll.GetList(4, " isdelete=0 and AdvertTypeID=3 ", " sort asc,id desc").Tables[0]);
            JY.BLL.Product pdbll = new JY.BLL.Product();
            ViewData["getProductHot"] = Collections.DataToList.ToList<JY.Model.Product>(pdbll.GetListByPage(" IsDelete=0", " sort", 0, 6).Tables[0]); ;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
