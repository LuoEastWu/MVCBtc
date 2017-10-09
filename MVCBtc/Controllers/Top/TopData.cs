using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MVCBtc.Controllers.Top
{
    public static class TopData
    {
        /// <summary>
        /// 获取产品类型
        /// </summary>
        public static List<JY.Model.ProductType> getProductType()
        {
            JY.BLL.ProductType ptbll = new JY.BLL.ProductType();
            DataSet ds = ptbll.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 10);
            return HtmlHelper.DataToList.ToList<JY.Model.ProductType>(ds.Tables[0]);
        }

        /// <summary>
        /// 获取产品子类型
        /// </summary>
        public static List<JY.Model.ProductType> rptProductType(long typeId)
        {
            try
            {
                JY.BLL.ProductType bll = new JY.BLL.ProductType();

                DataSet ds = bll.GetListByPage(" IsDelete=0 and fid=" + typeId, " sort ", 0, 15);
                return HtmlHelper.DataToList.ToList<JY.Model.ProductType>(ds.Tables[0]);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取资讯类型
        /// </summary>
        public static List<JY.Model.InformationType> getInformationType()
        {
            JY.BLL.InformationType itbll = new JY.BLL.InformationType();
            DataSet ds = itbll.GetListByPage(" IsDelete=0 and fid=0", " sort ", 0, 10);
            return HtmlHelper.DataToList.ToList<JY.Model.InformationType>(ds.Tables[0]);
        }
        /// <summary>
        /// 获取资讯子类型
        /// </summary>
        public static List<JY.Model.InformationType> rptInformationType(long typeId)
        {
            try
            {
                JY.BLL.InformationType bll = new JY.BLL.InformationType();
                DataSet ds = bll.GetListByPage(" IsDelete=0 and fid=" + typeId, " sort ", 0, 15);
                return HtmlHelper.DataToList.ToList<JY.Model.InformationType>(ds.Tables[0]);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}