using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using BLL;
using Model;

namespace Html
{
    public class IndexToHtml
    {
       
        public static void MakeIndex()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string ModelPath = "Model\\PC\\index.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("HeaderFirst.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            string htmlfilename ="index.shtml";
            string savePath = "";

            string PCBannera = "";
            string PCBanneraLink = "";
            string PCBannerb = "";
            string PCBannerbLink = "";
            string PCBannerc = "";
            string PCBannercLink = "";
            string PCBannerd = "";
            string PCBannerdLink = "";

            

            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
            DataTable dt = sqlcmd.getCommonData("SystemInfo"," * "," id=1");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PCBannera"].ToString()!="")
                    PCBannera = dt.Rows[0]["PCBannera"].ToString();
                if (dt.Rows[0]["PCBanneraLink"].ToString() != "")
                    PCBanneraLink = dt.Rows[0]["PCBanneraLink"].ToString();
                if (dt.Rows[0]["PCBannerb"].ToString() != "")
                    PCBannerb = dt.Rows[0]["PCBannerb"].ToString();
                if (dt.Rows[0]["PCBannerbLink"].ToString() != "")
                    PCBannerbLink = dt.Rows[0]["PCBannerbLink"].ToString();
                if (dt.Rows[0]["PCBannerc"].ToString() != "")
                    PCBannerc = dt.Rows[0]["PCBannerc"].ToString();
                if (dt.Rows[0]["PCBannercLink"].ToString() != "")
                    PCBannercLink = dt.Rows[0]["PCBannercLink"].ToString();
                if (dt.Rows[0]["PCBannerd"].ToString() != "")
                    PCBannerd = dt.Rows[0]["PCBannerd"].ToString();
                if (dt.Rows[0]["PCBannerdLink"].ToString() != "")
                    PCBannerdLink = dt.Rows[0]["PCBannerdLink"].ToString();
            }

            tempcontent = tempcontent.Replace("{$PCBannera}", PCBannera);
            tempcontent = tempcontent.Replace("{$PCBanneraLink}", PCBanneraLink);
            tempcontent = tempcontent.Replace("{$PCBannerb}", PCBannerb);
            tempcontent = tempcontent.Replace("{$PCBannerbLink}", PCBannerbLink);
            tempcontent = tempcontent.Replace("{$PCBannerc}", PCBannerc);
            tempcontent = tempcontent.Replace("{$PCBannercLink}", PCBannercLink);
            tempcontent = tempcontent.Replace("{$PCBannerd}", PCBannerd);
            tempcontent = tempcontent.Replace("{$PCBannerdLink}", PCBannerdLink);

            DataTable dt2 = sqlcmd.getCommonData("Article", " top 5 Title,NewsLink ", " 1=1 order by NewsId desc");
            string NewsScroll = "";
            if (dt2.Rows.Count > 0)
            {
                
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    string NewsTitle = dt2.Rows[i]["Title"].ToString();
                    string NewsLink = dt2.Rows[i]["NewsLink"].ToString();
                    NewsScroll += "<a href='Article\\" + NewsLink + "' _fcksavedurl=\"javascript:\"  target=\"_blank\">" + NewsTitle + "</a>";
                }
            }
            tempcontent = tempcontent.Replace("{$NewsScroll}", NewsScroll);


            DataTable dt3 = sqlcmd.getCommonData("Items", " top 3 itemName,itemDescri,itemThumbnail,itemLink ", " IsSeckill=1 order by itemsID desc");

           
            string SeckScroll = "";
            if (dt3.Rows.Count > 0)
            {
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    string itemName = dt3.Rows[j]["itemName"].ToString();
                    string itemDescri = dt3.Rows[j]["itemDescri"].ToString();
                    string itemThumbnail = dt3.Rows[j]["itemThumbnail"].ToString();
                    string itemLink=dt3.Rows[j]["itemLink"].ToString();
                    int num=j+1;

                    string RefileName = "";
                    string NewName=MakeSeckScrollThumbnail(itemThumbnail, RefileName,328,188);

                    SeckScroll += "<li><div class=\"cpic effect-" + num + "\"><div class=\"image-box\"><img src=\"FileUpload/Images/ItemsThumb/" + NewName + "\" alt=\"Image-1\"></div><div class=\"text-desc\"><h3>" + itemName + "</h3><p>" + itemDescri.Substring(0, 65) + "</p><a href='Items/" + itemLink + "' target=\"_blank\" class=\"btnpic\">查看更多</a></div></div></li>";

                }
            }
            tempcontent = tempcontent.Replace("{$SeckScroll}", SeckScroll);

            DataTable dt4 = sqlcmd.getCommonData("Items", " top 10 itemName,itemThumbnail,itemLink ", "1=1 order by itemsID desc");

            string ItemsImageScroll = "";
            if (dt3.Rows.Count > 0)
            {
                for (int k = 0; k < dt4.Rows.Count; k++)
                {
                    if (dt4.Rows[k]["itemThumbnail"].ToString() != "")
                    {
                        string itemName = dt4.Rows[k]["itemName"].ToString();
                        string itemThumbnail = dt4.Rows[k]["itemThumbnail"].ToString();
                        string itemLink = dt4.Rows[k]["itemLink"].ToString();
                        string RefileName = "";
                        string NewName = MakeSeckScrollThumbnail(itemThumbnail, RefileName, 250, 250);

                        ItemsImageScroll += "<li><a href='Items\\" + itemLink + "' target=\"_blank\"><img src=\"FileUpload/Images/ItemsThumb/" + NewName + "\" width=\"250px\"></a></li>";
                    }

                }
            }
            tempcontent = tempcontent.Replace("{$ItemsImageScroll}", ItemsImageScroll);
            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);

           
        }

        public static string MakeSeckScrollThumbnail(string itemThumbnail, string RefileName,int width,int height)
        {
            string path1 = HttpContext.Current.Server.MapPath("../FileUpload/Images/ItemsThumb/") + itemThumbnail;
            string path2 = HttpContext.Current.Server.MapPath("../FileUpload/Images/ItemsThumb/");
            if (width == 250 && height == 250)
            {
                RefileName = "ItemsIamgesScroll_" + itemThumbnail;
            }
            else
            {
                RefileName = "SeckScroll_" + itemThumbnail;
            }
            UploadImage.MakeThumbnail(path1, path2 + RefileName, width, height, "Hw");
            return RefileName;
        }
    }
}
