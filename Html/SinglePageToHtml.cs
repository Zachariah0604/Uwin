using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace Html
{
    public class SinglePageToHtml
    {
        public static void MakeHelpCenterHtml()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string ModelPath = "Model\\PC\\SinglePage.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
            string htmlfilename = "HelpCenter.html";
            string savePath = "About\\";
            tempcontent = tempcontent.Replace("{$SinglePageName}", "帮助中心");
            tempcontent = tempcontent.Replace("{$SinglePageLink}", "HelpCenter.html");
            tempcontent = tempcontent.Replace("{$ColumnTitle}", "帮助中心-");
            tempcontent = tempcontent.Replace("{$TypeNameTitle}", "");
            tempcontent = tempcontent.Replace("{$DetailTitle}", "");
            DataTable dt = sqlcmd.getCommonData("SinglePage", " HelpCenter ", " id=1");
            if (dt.Rows.Count > 0)
            {
                tempcontent = tempcontent.Replace("{$PageContent}", dt.Rows[0]["HelpCenter"].ToString());
            }
            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);
        }
        public static void MakeAboutMarketHtml()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string ModelPath = "Model\\PC\\SinglePage.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
            string htmlfilename = "AboutMarket.html";
            string savePath = "About\\";
            tempcontent = tempcontent.Replace("{$SinglePageName}", "关于市场");
            tempcontent = tempcontent.Replace("{$ColumnTitle}", "关于市场-");
            tempcontent = tempcontent.Replace("{$TypeNameTitle}", "");
            tempcontent = tempcontent.Replace("{$DetailTitle}", "");
            tempcontent = tempcontent.Replace("{$SinglePageLink}", "AboutMarket.html");
            DataTable dt = sqlcmd.getCommonData("SinglePage", " AboutMarket ", " id=1");
            if (dt.Rows.Count > 0)
            {
                tempcontent = tempcontent.Replace("{$PageContent}", dt.Rows[0]["AboutMarket"].ToString());
            }
            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);
        }
        public static void MakeJoinUsHtml()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string ModelPath = "Model\\PC\\SinglePage.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
            string htmlfilename = "JoinUs.html";
            string savePath = "About\\";
            tempcontent = tempcontent.Replace("{$SinglePageName}", "加入我们");
            tempcontent = tempcontent.Replace("{$ColumnTitle}", "加入我们-");
            tempcontent = tempcontent.Replace("{$TypeNameTitle}", "");
            tempcontent = tempcontent.Replace("{$DetailTitle}", "");
            tempcontent = tempcontent.Replace("{$SinglePageLink}", "JoinUs.html");
            DataTable dt = sqlcmd.getCommonData("SinglePage", " JoinUs ", " id=1");
            if (dt.Rows.Count > 0)
            {
                tempcontent = tempcontent.Replace("{$PageContent}", dt.Rows[0]["JoinUs"].ToString());
            }
            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);
        }
        public static void MakeAboutUsHtml()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string ModelPath = "Model\\PC\\SinglePage.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
            string htmlfilename = "AboutUs.html";
            string savePath = "About\\";
            tempcontent = tempcontent.Replace("{$SinglePageName}", "关于公司");
            tempcontent = tempcontent.Replace("{$ColumnTitle}", "关于公司-");
            tempcontent = tempcontent.Replace("{$TypeNameTitle}", "");
            tempcontent = tempcontent.Replace("{$DetailTitle}", "");
            tempcontent = tempcontent.Replace("{$SinglePageLink}", "AboutUs.html");
            DataTable dt = sqlcmd.getCommonData("SinglePage", " AboutUs ", " id=1");
            if (dt.Rows.Count > 0)
            {
                tempcontent = tempcontent.Replace("{$PageContent}", dt.Rows[0]["AboutUs"].ToString());
            }
            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);
        }
    }
}
