using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        /// <summary>
        /// 获取资讯子类型
        /// </summary>
        public static List<JY.Model.InformationType> rptInformationType(string ID)
        {
            try
            {
                JY.BLL.InformationType bll = new JY.BLL.InformationType();
                long typeId = Convert.ToInt32(ID);

                return Collections.DataToList.ToList<JY.Model.InformationType>(bll.GetListByPage(" IsDelete=0 and fid=" + typeId, " sort ", 0, 15).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public PartialViewResult Left()
        {
            JY.BLL.ProductType ptbll = new JY.BLL.ProductType();
            ViewData["ProductTypeList"] = Collections.DataToList.ToList<JY.Model.ProductType>(ptbll.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 6).Tables[0]);
            JY.BLL.Product prbll = new JY.BLL.Product();
            ViewData["ProductList"] = Collections.DataToList.ToList<JY.Model.Product>(prbll.GetListByPage(" IsDelete=0", " sort", 0, 4).Tables[0]);
            return PartialView();
        }
        /// <summary>
        /// 获取产品子类型
        /// </summary>
        public static List<JY.Model.ProductType> rptProductType_ItemDataBound(string id)
        {
            try
            {
                JY.BLL.ProductType bll = new JY.BLL.ProductType();
                long typeId = Convert.ToInt32(id);
                return Collections.DataToList.ToList<JY.Model.ProductType>(bll.GetListByPage(" IsDelete=0 and fid=" + typeId, " sort ", 0, 15).Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
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
