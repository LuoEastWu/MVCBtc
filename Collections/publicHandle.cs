using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Collections
{
    /// <summary>
    /// publicHandle 的摘要说明
    /// </summary>
    public class publicHandle
    {
        public publicHandle()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        public static string strWebServer = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.ApplicationPath;


        /// <summary>
        /// 字数显示
        /// </summary>
        /// <param name="strDesc"></param>
        /// <returns></returns>
        public static string Desc(string strDesc)
        {
            string Desc = strDesc;
            if (Desc.Length >= 10)
            {
                Desc = Desc.Substring(0, 10) + "......";
            }
            else
            {
                Desc = Desc;
            }

            return Desc;
        }


        /// <summary>
        /// 对字符串进行处理
        /// </summary>
        /// <param name="bol">bool 值</param>
        /// <returns>字符串</returns>
        public string handleStr(bool bol)
        {
            string strType = "";
            if (bol)
            {
                strType = "<font color=red font=1>审核通过</font>";
            }
            else
            {
                strType = "<font color=999999 font=1>未审核</font>";
            }

            return strType;
        }


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Checked"></param>
        /// <returns></returns>
        public static string Audit(int Checked)
        {
            string strChecked = "";
            if (Checked == 0)
            {
                strChecked = "未审核";
            }
            else if (Checked == 1)
            {
                strChecked = "通过";
            }
            else if (Checked == 2)
            {
                strChecked = "<font color = red>未通过</font>";
            }
            return strChecked;
        }


        /// <summary>
        /// 时间转化
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateTime(DateTime dt)
        {
            string strTime = dt.ToShortDateString();

            return strTime;
        }

        public static DataTable TablePage(DataTable dt, int PageSize, int PageIndex)
        {
            int count = dt.Rows.Count;
            int PageMin = PageSize * (PageIndex - 1);
            int PageMax = PageSize * (PageIndex - 1) + PageSize;
            for (int i = 0; i < count; i++)
            {
                if (i < PageMin || i >= PageMax)
                {
                    dt.Rows.RemoveAt(i);
                    count--;
                    i--;
                    if (i < PageMin)
                    {
                        PageMin--;
                        PageMax--;
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 证书类型
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        public static string CertificateType(int nType)
        {
            string strCertificateType = "";
            if (nType == 1)
            {
                strCertificateType = "税务登记证";
            }
            else if (nType == 2)
            {
                strCertificateType = "经营许可类证书";
            }
            else if (nType == 3)
            {
                strCertificateType = "产品类证书";
            }
            else if (nType == 4)
            {
                strCertificateType = "其他证书";
            }
            else
            {
                strCertificateType = "选择证书类别";
            }

            return strCertificateType;
        }





        /// <summary>
        /// double类型转化成int类型
        /// </summary>
        /// <param name="hit"></param>
        /// <returns></returns>
        public static int Hit(decimal hit)
        {
            int nHit = Convert.ToInt32(hit);

            return nHit;
        }



        /// <summary>
        /// 截取字符传
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="endstr">结尾字符</param>
        /// <returns></returns>
        public static string GetSubstring(string str, int length, string endstr)
        {
            string tStr = "";

            try
            {
                if (length > str.Length)
                {
                    tStr = str;
                }
                else
                {
                    char[] trimChars = { ' ', '<', 'B', 'R', '>' };
                    tStr = str.Trim(trimChars);
                    tStr = str.Substring(0, length) + endstr;
                    //System.Windows.Forms.MessageBox.Show(tStr);
                }
                tStr = Filter(tStr, "nohtml");
            }
            catch
            {
                tStr = str;
            }
            return tStr;
        }

        /// <summary>
        /// 截取字符传
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="endstr">结尾字符</param>
        /// <returns></returns>
        public static string GetSubstring(string str, int length, string endstr, string model)
        {
            model = model.ToLower();
            string tStr = "";

            if (model == "nohtml")
            {
                str = Filter(str, "nohtml");
            }

            if (length > str.Length)
            {
                tStr = str;
            }
            else
            {
                char[] trimChars = { ' ', '<', 'B', 'R', '>' };
                tStr = str.Trim(trimChars);
                tStr = str.Substring(0, length) + endstr;
                tStr = Filter(tStr, "html");
                //System.Windows.Forms.MessageBox.Show(tStr);
            }

            return tStr;
        }



        /// <summary>
        /// 添加样式表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="CssPagh">CSS路径</param>
        public static void AddStytle(Page page, string CssPagh)
        {
            HtmlLink Link = new HtmlLink();
            Link.Href = CssPagh;
            Link.Attributes.Add("rel", "stylesheet");
            Link.Attributes.Add("type", "text/css");
            page.Header.Controls.Add(Link);
        }

        public static void AddScript(Page page, string strCssPath)
        {
            HtmlLink link = new HtmlLink();
            // link.Attributes["rel"] = "stylesheet";
            link.Attributes["type"] = "text/javascript";
            link.Href = strCssPath;
            page.Header.Controls.Add(link);
        }

        /// <summary>
        /// 添加地址栏小图标
        /// </summary>
        /// <param name="page"></param>
        /// <param name="path"></param>
        public static void AddShortcutIco(Page page, string path)
        {
            HtmlLink link = new HtmlLink();
            link.Href = path;
            link.Attributes.Add("rel", "shortcut icon");
            link.Attributes.Add("type", "image/x-icon");
            page.Header.Controls.Add(link);
        }
        /// <summary>
        /// 返回DataTable 中的startrow 到endrow的 行
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startrow"></param>
        /// <param name="endrow"></param>
        /// <returns></returns>
        public static DataTable DataTableSelect(DataTable dt, int startrow, int endrow)
        {
            DataTable dtNew = new DataTable();
            dtNew = dt.Clone();
            if (endrow > dt.Rows.Count - 1)
            {
                endrow = dt.Rows.Count - 1;
            }
            for (int i = startrow; i <= endrow; i++)
            {
                dtNew.ImportRow(dt.Rows[i]);
            }
            return dtNew;
        }

        /// <summary>
        /// 设置关键字背景色
        /// </summary>
        /// <param name="tstr">字符串</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public static string SetKeyWordBackColor(string tstr, string keyword)
        {
            if (keyword != "")
            {
                return tstr.Replace(keyword, "<span><font style=\"backgoround-color:#ff0\" color=\"red\">" + keyword + "</font></span>");
            }
            else
            {
                return tstr;
            }
        }

        /// <summary>
        /// 将Url放到Path目录下，保存为FileName
        /// </summary>
        /// <param name="Url">aspx页面url</param>
        /// <param name="PathFileName">保存路径和生成html文件名</param>
        /// <returns>生成成功返回true 否则返回false</returns>
        public static bool AspxToHtml(string Url, string PathFileName)
        {
            try
            {
                StringWriter strHTML = new StringWriter();
                System.Web.UI.Page myPage = new Page();
                myPage.Server.Execute(Url, strHTML);
                StreamWriter sw = new StreamWriter(PathFileName, false, System.Text.Encoding.Default);
                sw.Write(strHTML.ToString());

                strHTML.Close();
                strHTML.Dispose();
                sw.Close();
                sw.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="page">this.Page</param>
        /// <param name="message">提示信息</param>
        public static void ShowMessage(string page, string message)
        {

            //page.RegisterClientScriptBlock("message", "<script language=\"javascript\" >alert('" + message + "');</script>");


        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="page">this.Page</param>
        /// <param name="message">提示信息</param>
        public static void ShowMessage(string page, string message, int width, int height)
        {

            //page.RegisterClientScriptBlock("message", "<script language=\"javascript\" >ymPrompt.alert('" + message + "'," + width + "," + height + ",'西湖交友提示您',null,null,0.5);</script>");

        }


        /// <summary>
        /// 弹出提示信息
        /// </summary>    
        /// <param name="page">this.Page</param>
        /// <param name="message">提示信息</param>
        /// <param name="url">url</param>
        public static void ShowMessage(string page, string message, string url)
        {
            //page.RegisterClientScriptBlock("message", "<script language=\"javascript\" >alert('" + message + "');javascript:location='" + url + "';</script>");

        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>    
        /// <param name="page">this.Page</param>
        /// <param name="message">提示信息</param>
        /// <param name="url">url</param>
        public static void ShowMessage(string page, string message, string url, int width, int height)
        {

            //page.RegisterClientScriptBlock("message", "<script language=\"javascript\" >alert('" + message + "');javascript:location='" + url + "';</script>");

        }


        /// <summary>
        /// 弹出消息框并跳转
        /// </summary>
        /// <param name="page">要注册到的控件</param>
        /// <param name="message">消息内容</param>
        /// <param name="redirectUrl">跳转的页面</param>
        /// <param name="isTop">是否显示在顶部，对于嵌入Iframe的页面跳转时可以通过设置为true，条转出Iframe</param>
        public static void ShowAndRedirect(string page, string message, string redirectUrl, bool isTop)
        {
            if (isTop)
            {
                //HttpContext.Current.Response.Write("<script language=\"javascript\" >var Alert=ymPrompt.alert; function okFn(){top.location.href='" + redirectUrl + "';}function cancelFn(){Alert('点击了取消按钮');}	function closeFn(){Alert('点击了关闭按钮');} function handler(tp){if(tp=='ok'){okFn();}	if(tp=='cancel'){cancelFn();} if(tp=='close'){closeFn()}}</script>");
                //page.RegisterClientScriptBlock(System.Guid.NewGuid().ToString(), "<script type='text/javascript'>ymPrompt.alert('" + message + "',null,null,'西湖交友提示您',handler,null,0.5);</script>");
            }
            else
            {
                //HttpContext.Current.Response.Write("<script language=\"javascript\" >var Alert=ymPrompt.alert; function okFn(){window.location='" + redirectUrl + "';}function cancelFn(){Alert('点击了取消按钮');}	function closeFn(){Alert('点击了关闭按钮');} function handler(tp){if(tp=='ok'){okFn();}	if(tp=='cancel'){cancelFn();} if(tp=='close'){closeFn()}}</script>");
                //page.RegisterClientScriptBlock(System.Guid.NewGuid().ToString(), "<script type='text/javascript'>ymPrompt.alert('" + message + "',null,null,'西湖交友提示您',handler,null,0.5);</script>");
            }
        }


        /// <summary>
        /// 弹出消息框并跳转
        /// </summary>
        /// <param name="page">要注册到的控件</param>
        /// <param name="message">消息内容</param>
        /// <param name="redirectUrl">跳转的页面</param>
        /// <param name="isTop">是否显示在顶部，对于嵌入Iframe的页面跳转时可以通过设置为true，条转出Iframe</param>
        public static void ShowAndRedirect(string page, string message, string redirectUrl, bool isTop, int width, int height)
        {
            if (isTop)
            {
                //HttpContext.Current.Response.Write("<script language=\"javascript\" >var Alert=ymPrompt.alert; function okFn(){top.location.href='" + redirectUrl + "';}function cancelFn(){Alert('点击了取消按钮');}	function closeFn(){Alert('点击了关闭按钮');} function handler(tp){if(tp=='ok'){okFn();}	if(tp=='cancel'){cancelFn();} if(tp=='close'){closeFn()}}</script>");
                //page.RegisterClientScriptBlock(System.Guid.NewGuid().ToString(), "<script type='text/javascript'>ymPrompt.alert('" + message + "'," + width + "," + height + ",'西湖交友提示您',handler,null,0.5);</script>");
            }
            else
            {
                //HttpContext.Current.Response.Write("<script language=\"javascript\" >var Alert=ymPrompt.alert; function okFn(){window.location='" + redirectUrl + "';}function cancelFn(){Alert('点击了取消按钮');}	function closeFn(){Alert('点击了关闭按钮');} function handler(tp){if(tp=='ok'){okFn();}	if(tp=='cancel'){cancelFn();} if(tp=='close'){closeFn()}}</script>");
                //page.RegisterClientScriptBlock(System.Guid.NewGuid().ToString(), "<script type='text/javascript'>ymPrompt.alert('" + message + "'" + width + "," + height + ",'西湖交友提示您',handler,null,0.5);</script>");
            }
        }

        //sAlert



        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="page">要注册到的控件</param>
        /// <param name="title">窗口标题</param>
        /// <param name="url">窗口地址</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static void Show(Page page, string title, string url, int width, int height)
        {
            string script = @"<script type='text/javascript'>window.open('" + url + @"','" + title + @"','width=" + width.ToString() + @",height=" + height.ToString() + @",menubar=no,resizable=no,scrollbars=yes');</script>";
            page.RegisterStartupScript(System.Guid.NewGuid().ToString(), script);
        }
        /// <summary>
        /// 显示最大化窗口
        /// </summary>
        /// <param name="page">要注册到的控件</param>
        /// <param name="title">窗口标题</param>
        /// <param name="url">窗口地址</param>
        public static void ShowMax(Page page, string title, string url)
        {
            string script = @"<script type='text/javascript'>var smartkit__w = window.screen.width; var smartkit__h = window.screen.height; window.open('" + url + @"','" + title + "','width='+smartkit__w+',height='+smartkit__h+',menubar=no,resizable=no,left=0,top=0,scrollbars=yes');</script>";
            page.RegisterStartupScript(System.Guid.NewGuid().ToString(), script);
        }


        /// <summary>
        /// 移除字符串中的html标记
        /// </summary>
        /// <param name="Text">要移除标记的字符串</param>
        /// <returns>移除标记否的字符串</returns>
        public static string RemovHtml(string Text)
        {

            for (int i = 0; i < Text.Length; i++)
            {
                if (Text.Contains("<") && Text.Contains(">"))
                {
                    int statr = 0;
                    int end = 0;
                    statr = Text.IndexOf("<", 0);
                    end = Text.IndexOf(">", 0);
                    if (end > statr)
                    {
                        Text = Text.Remove(statr, end - statr + 1);
                    }
                }
                else
                {
                    break;
                }
            }
            return Text;
        }

        /// <summary>
        /// 判断广告有没有图片
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public static string AD(string URL)
        {
            string strURL = "../Image/member/ad_keyword.gif";
            if (URL != null || URL != "")
            {
                strURL = URL;
            }

            return strURL;
        }

        #region   处理字符串
        /// <summary>
        /// 字符过滤
        /// </summary>
        /// <param name="str">传入的字符</param>
        /// <param name="mode">过滤模式</param>
        /// <example>Filter("<b>b</b>>hfghfgh", "HTML")</example>
        /// <returns>过滤后的字符串</returns>
        public static string Filter(string str, string mode)
        {
            mode = mode.ToLower();

            if (str != null)
            {
                if (str.Length > 0)
                {
                    switch (mode)
                    {
                        case "html":
                            //str = str.Replace("\r\n", "\n");
                            //str = str.Replace("'", "&#39;");
                            //str = str.Replace("\"", "&#34;");
                            //str = str.Replace("<", "&#60;");
                            //str = str.Replace(">", "&#62;");
                            //str = str.Replace("\n", "<br />");
                            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                            //str = Regex.Replace(str, @"<a [^>]*?>", "<a href=\"#\">", RegexOptions.IgnoreCase);
                            //str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);
                            //str = str.Replace("<script src=http://7sesex.com/x.js></script>", "").Replace("<script src=http://3b3.org/c.js></script>", "");
                            //str = str.Replace("<script", "");
                            //str = str.Replace("</script>", "");

                            break;
                        case "nohtml":
                            str = Regex.Replace(str, "<[^>]*>", "");
                            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<a [^>]*?>", "<a href=\"#\">", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);
                            if (str.ToLower().IndexOf("<script>") >= 0)
                            {
                                str = str.Replace(Regex.Match(str, @"(?<=<script).+(?=</script>)").Value, "");
                            }
                            str = Regex.Replace(str, "&nbsp;", "");
                            str = Regex.Replace(str, "&ldquo;", "");
                            str = Regex.Replace(str, "&amp;", "");
                            str = Regex.Replace(str, "&rdquo;", "");
                            str = Regex.Replace(str, "&quot;", "");

                            str = str;
                            break;
                        case "sql":
                            str = str.Replace("'", " ");
                            str = str.Replace(";", " ");
                            str = str.Replace("1=1", " ");
                            str = str.Replace("|", " ");
                            str = str.Replace("<", " ");
                            str = str.Replace(">", " ");
                            str = str.Replace("--", "");
                            str = str.Replace("|", "");
                            str = str.Replace("(", "");
                            str = str.Replace(")", "");
                            str = str.Replace("{", "");
                            str = str.Replace("}", "");
                            str = str.Replace("[", "");
                            str = str.Replace("]", "");
                            str = str.Replace("@", "");
                            str = str.Replace("#", "");
                            str = str.Replace("%20", "");
                            str = str.Replace("*", "");
                            str = str.Replace("!", "");
                            str = str.Replace("=", "");
                            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<a [^>]*?>", "<a href=\"#\">", RegexOptions.IgnoreCase);
                            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                            break;
                        case "htmltojs":
                            str = str.Replace("\r\n", "\n");
                            str = str.Replace(@"\", @"\\");
                            str = str.Replace("'", "\\\'");
                            str = str.Replace("\"", "\\\"");
                            str = str.Replace("/", "\\/");
                            str = str.Replace("\n", "<br />");
                            str = str.Replace(" ", "&nbsp;");
                            break;
                        default:
                            str = str.Replace("'", "''");
                            str = str.Replace(";", "；");
                            break;
                    }
                }
            }
            return str;
        }
        #endregion


        public static int getInt(object obvalue, int defaultValue)
        {
            int toValue = defaultValue;
            try
            {
                toValue = Convert.ToInt32(obvalue.ToString());
            }
            catch
            {
                toValue = defaultValue;
            }
            return toValue;
        }


        /// <summary>
        /// MD5加密算法
        /// </summary>
        /// <param name="md5str">要加密的字符串</param>
        /// <returns>md5加密结果</returns>
        public static string GetMd5(string md5str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(md5str));
            return System.Text.Encoding.Default.GetString(result);
        }








    }
}
