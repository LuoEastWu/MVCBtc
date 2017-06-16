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
        public PartialViewResult Top()
        {
            JY.BLL.ProductType ptbll = new JY.BLL.ProductType();
            ViewData["ProductTypeList"] = Collections.DataToList.ToList<JY.Model.ProductType>(ptbll.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 10).Tables[0]);
            JY.BLL.InformationType itbll = new JY.BLL.InformationType();
            ViewData["InformationTypeList"] = Collections.DataToList.ToList<JY.Model.InformationType>(itbll.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 10).Tables[0]);
            return PartialView();
        }
        /// <summary>
        /// 获取产品子类型
        /// </summary>
        public static List<JY.Model.ProductType> rptProductType(long typeId)
        {
            try
            {
                JY.BLL.ProductType bll = new JY.BLL.ProductType();
                return Collections.DataToList.ToList<JY.Model.ProductType>(bll.GetListByPage(" IsDelete=0 and fid=" + typeId, " sort ", 0, 15).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PartialViewResult Left()
        {
            return PartialView();
        }


        public PartialViewResult Foot()
        {
            return PartialView();
        }

        public PartialViewResult MemberCenter_Top()
        {
            return PartialView();
        }

        public PartialViewResult MemberCenter_Left()
        {
            return PartialView();
        }

        public PartialViewResult MemberCenter_Foot()
        {
            return PartialView();
        }




    }
}
