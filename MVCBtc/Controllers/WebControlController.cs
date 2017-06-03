using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBtc.Controllers
{
    public class WebControlController : Controller
    {
        // GET: WebControl
        public ActionResult Top()
        {
           ViewData["ProductTypeList"]= MVCBtc.Controllers.Top.TopData.getProductType();
           ViewData["InformationTypeList"] =MVCBtc.Controllers.Top.TopData.getInformationType();
           
            return PartialView();
        }



        public ActionResult Foot()
        {
            return PartialView();
        }
    }
}