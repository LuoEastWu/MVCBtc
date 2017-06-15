using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBtc.Controllers
{
    public class WebTemplateController : Controller
    {
        //
        // GET: /WebTemplate/
    
        public ActionResult Top()
        {
            return PartialView();
        }
        public ActionResult Left()
        {
            return View();
        }


        public ActionResult Foot()
        {
            return View();
        }

        public ActionResult MemberCenter_Top()
        {
            return View();
        }

        public ActionResult MemberCenter_Left()
        {
            return View();
        }

        public ActionResult MemberCenter_Foot()
        {
            return View();
        }

     


    }
}
