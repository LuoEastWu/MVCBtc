using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBtc.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Top()
        {
            return View();
        }

        public ActionResult Left()
        {
            return View();
        }

        public ActionResult Down()
        {
            return View();
        }
    }
}