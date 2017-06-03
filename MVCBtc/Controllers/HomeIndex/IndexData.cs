using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBtc.Controllers.HomeIndex
{
    public static class IndexData
    {
        /// <summary>
        /// 首页大图
        /// </summary>
        public static List<JY.Model.Advert> BindAd()
        {
            try
            {
                JY.BLL.Advert bll = new JY.BLL.Advert();
               return  HtmlHelper.DataToList.ToList<JY.Model.Advert>(bll.GetList(4, " isdelete=0 and AdvertTypeID=3 ", " sort asc,id desc").Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}