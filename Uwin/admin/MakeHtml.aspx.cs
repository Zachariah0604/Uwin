using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Html;
using BLL;
using System.Data;
using System.IO;
namespace Uwin.admin
{
    public partial class MakeHtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static void DeleteDirectory(string dir)
        {
            if (Directory.GetDirectories(dir).Length == 0 && Directory.GetFiles(dir).Length == 0)
            {
            //    Directory.Delete(dir);//删除文件夹
                return;
            }
            foreach (string var in Directory.GetDirectories(dir))
            {
                DeleteDirectory(var);
            }
            foreach (string var in Directory.GetFiles(dir))
            {
                File.Delete(var);
            }
          //  Directory.Delete(dir);//删除文件夹
        }
        protected void HeaderHtml_Click(object sender, EventArgs e)
        {
            CommonHtml.MakeHeaderHtml();
            CommonHtml.MakeHeader2Html();
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成header页');</script>");
            
            
        }

        protected void FooterHtml_Click(object sender, EventArgs e)
        {
            CommonHtml.MakeFooterHtml();
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成Footer页');</script>");
        }

        protected void IndexHtml_Click(object sender, EventArgs e)
        {
            IndexToHtml.MakeIndex();
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成首页');</script>");
        }

        protected void VedioHtml_Click(object sender, EventArgs e)
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            DataTable dt = sqlcmd.getCommonData("uwinStation", " staid ", " 1=1");
            int counts = 1;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VedioToHtml.MakeVedio(int.Parse(dt.Rows[i]["staid"].ToString()));
                    counts++;
                }
                Response.Write("<Script Language='JavaScript'>window.alert('成功生成" + counts + "张视频页面');</script>");
            }
        }

        protected void ArticleListHtml_Click(object sender, EventArgs e)
        {
            ArticleHtml.MakeArticleList();
            ArticleHtml.MakeArticleIndex();
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成所有列表页面');</script>");
        }

        protected void itemsHtml_Click(object sender, EventArgs e)
        {
            ItemsToHtml.MakeItemList();
            ItemsToHtml.MakeTriItemList();
            ItemsToHtml.MakeSecItemList();
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成所有列表页面');</script>");
        }

        protected void SinglePageHtml_Click(object sender, EventArgs e)
        {
            SinglePageToHtml.MakeHelpCenterHtml();
            SinglePageToHtml.MakeAboutMarketHtml();
            SinglePageToHtml.MakeJoinUsHtml();
            SinglePageToHtml.MakeAboutUsHtml();
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成所有单页');</script>");
        }

        protected void AllToHtml_Click(object sender, EventArgs e)
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string ArticleDir = HttpContext.Current.Server.MapPath("../Article/");
            DeleteDirectory(ArticleDir);
            string ItemsDir = HttpContext.Current.Server.MapPath("../Items/");
            DeleteDirectory(ItemsDir);

            DataTable Articledt = sqlcmd.getCommonData("Article", " NewsId ", " 1=1");
            if (Articledt.Rows.Count > 0)
            {
                for (int i = 0; i < Articledt.Rows.Count; i++)
                {
                    int NewID = int.Parse(Articledt.Rows[i]["NewsId"].ToString());
                    string ArticleLink = ArticleHtml.MakeArticleContentByID(NewID);
                    
                    sqlcmd.CommonUpdate(" Article ", " NewsLink = " + "'" + ArticleLink + "'", " NewsId = " + NewID);
                }
            }

            DataTable Itmesdt = sqlcmd.getCommonData("Items", " itemsID ", " 1=1");
            if (Itmesdt.Rows.Count > 0)
            {
                for (int i = 0; i < Itmesdt.Rows.Count; i++)
                {
                    int itemsID = int.Parse(Itmesdt.Rows[i]["itemsID"].ToString());
                    string itemLink = ItemsToHtml.MakeItemsDatilByItemsID(itemsID);

                    sqlcmd.CommonUpdate(" Items ", " itemLink = " + "'" + itemLink + "'", " itemsID = " + itemsID);
                }
            }

            CommonHtml.MakeHeaderHtml();
            CommonHtml.MakeHeader2Html();
            CommonHtml.MakeFooterHtml();
            IndexToHtml.MakeIndex();
            
            DataTable dt = sqlcmd.getCommonData("uwinStation", " staid ", " 1=1");
            int counts = 1;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VedioToHtml.MakeVedio(int.Parse(dt.Rows[i]["staid"].ToString()));
                    counts++;
                }
               
            }
            ArticleHtml.MakeArticleList();
            ArticleHtml.MakeArticleIndex();
            ItemsToHtml.MakeItemList();
            ItemsToHtml.MakeTriItemList();
            ItemsToHtml.MakeSecItemList();
            SinglePageToHtml.MakeHelpCenterHtml();
            SinglePageToHtml.MakeAboutMarketHtml();
            SinglePageToHtml.MakeJoinUsHtml();
            SinglePageToHtml.MakeAboutUsHtml();
            Response.Write("<Script Language='JavaScript'>window.alert('生成成功');</script>");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string ArticleDir = HttpContext.Current.Server.MapPath("../Article/");
            DeleteDirectory(ArticleDir);
            string ItemsDir = HttpContext.Current.Server.MapPath("../Items/");
            DeleteDirectory(ItemsDir);
            Response.Write("<script>alert('清除成功!')</script>");
        }
    }
}