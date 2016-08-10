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
    public class CommonHtml
    {
        public static void MakeHeaderHtml()
        {
            Sqlcmd sqlcd = new Sqlcmd();
            string ModelPath = "Model\\PC\\HeaderFirst.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);

            string htmlfilename = "HeaderFirst.html";
            string savePath = ""; 
            BLL.SystemInfo SystemInfoBll = new BLL.SystemInfo();

            Model.ModelSysinfo mSystemInfo = new Model.ModelSysinfo();
            mSystemInfo = SystemInfoBll.GetSystemInfoModel(1);

            tempcontent = tempcontent.Replace("{$WebName}", mSystemInfo.WebName);
            tempcontent = tempcontent.Replace("{$WebTitle}", mSystemInfo.WebTitle);
            tempcontent = tempcontent.Replace("{$MetaKeywords}", mSystemInfo.MetaKeywords);
            tempcontent = tempcontent.Replace("{$MetaDescription}", mSystemInfo.MetaDescription);
            tempcontent = tempcontent.Replace("{$WebHttp}", mSystemInfo.WebHttp);

            DataTable dt = sqlcd.getCommonData(" ItemsParType ", " * ", " 1=1");
            if (dt.Rows.Count > 0)
            {
                string itemsType = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ParTypeID = dt.Rows[i]["ParTypeID"].ToString();
                    string RepTypeLink = "'items_" + ParTypeID + ".html'";
                    int linkResult = sqlcd.CommonUpdate("ItemsParType", " pTypeLink =" + RepTypeLink, " ParTypeID =" + ParTypeID);
                    string pTypeLink = null;

                    if (linkResult != 0)
                    {
                        pTypeLink = dt.Rows[i]["pTypeLink"].ToString();
                    }

                    string pTypeThumb = dt.Rows[i]["pTypeThumb"].ToString();
                    string pTypeName = dt.Rows[i]["pTypeName"].ToString();
                    itemsType += "<li><A href='../Items/" + pTypeLink + "'><FIGURE><SPAN class=\"photo\"><IMG alt='" + pTypeName + "' src='../FileUpload/Images/ItemsThumb/menu/" + pTypeThumb + "'></SPAN><FIGCAPTION><P>" + pTypeName + "</P></FIGCAPTION></FIGURE></A></li>";

                }
                tempcontent = tempcontent.Replace("{$itemsType}", itemsType);
            }
            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);

        }

        public static void MakeHeader2Html()
        {
            Sqlcmd sqlcd = new Sqlcmd();
            string ModelPath = "Model\\PC\\HeaderSecond.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);

            string htmlfilename = "HeaderSecond.html";
            string savePath = ""; ;
            BLL.SystemInfo SystemInfoBll = new BLL.SystemInfo();

            Model.ModelSysinfo mSystemInfo = new Model.ModelSysinfo();
            mSystemInfo = SystemInfoBll.GetSystemInfoModel(1);

            tempcontent = tempcontent.Replace("{$WebName}", mSystemInfo.WebName);
            tempcontent = tempcontent.Replace("{$WebTitle}", mSystemInfo.WebTitle);
            
            tempcontent = tempcontent.Replace("{$MetaKeywords}", mSystemInfo.MetaKeywords);
            tempcontent = tempcontent.Replace("{$MetaDescription}", mSystemInfo.MetaDescription);
            tempcontent = tempcontent.Replace("{$WebHttp}", mSystemInfo.WebHttp);

            DataTable dt = sqlcd.getCommonData(" ItemsParType "," * "," 1=1");
            if (dt.Rows.Count > 0)
            {
                string itemsType = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ParTypeID = dt.Rows[i]["ParTypeID"].ToString();
                    string RepTypeLink = "'items_" + ParTypeID + ".html'";
                    int linkResult = sqlcd.CommonUpdate("ItemsParType", " pTypeLink =" + RepTypeLink, " ParTypeID =" + ParTypeID);
                    string pTypeLink = null;

                    if (linkResult != 0)
                    {
                        pTypeLink = dt.Rows[i]["pTypeLink"].ToString();
                    }
                    
                    string pTypeThumb=dt.Rows[i]["pTypeThumb"].ToString();
                    string pTypeName=dt.Rows[i]["pTypeName"].ToString();
                    itemsType += "<li><A href='../Items/" + pTypeLink + "'><FIGURE><SPAN class=\"photo\"><IMG alt='" + pTypeName + "' src='../FileUpload/Images/ItemsThumb/menu/" + pTypeThumb + "'></SPAN><FIGCAPTION><P>" + pTypeName + "</P></FIGCAPTION></FIGURE></A></li>";
                    
                }
                tempcontent = tempcontent.Replace("{$itemsType}", itemsType);
            }
            

            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);

        }

        public static void MakeFooterHtml()
        {
            Sqlcmd sqlcmd = new Sqlcmd();
            string ModelPath = "Model\\PC\\Footer.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);

            string htmlfilename = "Footer.html";
            string savePath = ""; 
            BLL.SystemInfo SystemInfoBll = new BLL.SystemInfo();

            Model.ModelSysinfo mSystemInfo = new Model.ModelSysinfo();
            mSystemInfo = SystemInfoBll.GetSystemInfoModel(1);

            DataTable dt=sqlcmd.getCommonData("ArticleType"," top 4 * "," 1=1");
            string FooterTypeList = "";
            if(dt.Rows.Count>0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string TypeName=dt.Rows[i]["TypeName"].ToString();
                    string TypeLink=dt.Rows[i]["TypeLink"].ToString();
                    FooterTypeList += " <li><a href='Article\\" + TypeLink + "' >+" + TypeName + "</a></li>";
                }
            }
            tempcontent = tempcontent.Replace("{$FooterTypeList}", FooterTypeList);
            tempcontent = tempcontent.Replace("{$CopyRight}", mSystemInfo.CopyRight);
            tempcontent = tempcontent.Replace("{$Beian}", mSystemInfo.Beian);
            tempcontent = tempcontent.Replace("{$ComAddress}", mSystemInfo.ComAddress);


            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);

        }
    }
}
