using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BLL;
using Model;

namespace Html
{
    public class ArticleHtml
    {

        public static void MakeArticleIndex()
        {
            Sqlcmd sqlcd = new Sqlcmd();
            string ModelPath = "Model\\PC\\Article\\ArtileList.html";

            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            string savePath = "Article\\";
            string Artilelist = null;
            string typelist = null;
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
             DataTable dt = sqlcd.getCommonData("ArticleType"," * "," 1=1 ");
             if (dt.Rows.Count > 0)
             {

                 for (int type = 0; type < dt.Rows.Count; type++)
                 {
                     string listid = dt.Rows[type]["Typeid"].ToString();

                     string TypeName = dt.Rows[type]["TypeName"].ToString();
                     DataTable dtpagecount = sqlcd.getCommonData("Article", " * ", " TypeId= " + listid);
                     string listLink = "";
                     if (dtpagecount.Rows.Count <= 7)
                     {
                         listLink = "'List_" + listid + ".html'";
                     }
                     else { listLink = "'List_" + listid + "_1.html'"; }
                     int result = sqlcd.CommonUpdate("ArticleType", " TypeLink = " + listLink, " Typeid =" + listid);
                     if (result != 0)
                     {
                         string TypeLink = dt.Rows[type]["TypeLink"].ToString();
                         typelist += "<div class=\"containerLeftBoxOth\"><a href=" + TypeLink + " target=\"_top\">" + TypeName + "</a></div>";
                     }
                 }
                 
             }
             tempcontent = tempcontent.Replace("{$CurrentTypeLink}", "index.html");
             tempcontent = tempcontent.Replace("{$DetailTitle}", "");
             tempcontent = tempcontent.Replace("{$ColumnTitle}", "新闻中心-");
             tempcontent = tempcontent.Replace("{$TypeNameTitle}", "");
             tempcontent = tempcontent.Replace("{$CurrentTypeName}", "所有文章");
             tempcontent = tempcontent.Replace("{$Pagelink}", null);
             tempcontent = tempcontent.Replace("{$Typelist}", typelist);
             DataTable dt2 = sqlcd.getCommonData("Article", " * ", " 1 = 1");
             if (dt2.Rows.Count > 0)
             {
                 for (int j = dt2.Rows.Count - 1; j >= 0; j--)
                 {
                     string TypeId = dt2.Rows[j]["TypeId"].ToString();
                     string NewsLink = dt2.Rows[j]["NewsLink"].ToString();
                     string NewsTitle = dt2.Rows[j]["Title"].ToString();
                     string PicUrl = dt2.Rows[j]["PicUrl"].ToString();
                     string CreateTime = dt2.Rows[j]["CreateTime"].ToString();
                     string click = dt2.Rows[j]["Click"].ToString();
                     string Url = dt2.Rows[j]["Url"].ToString();
                     string Content = dt2.Rows[j]["Content"].ToString();
                     string TypeName="";
                     DataTable dt3 = sqlcd.getCommonData("ArticleType", " * ", " Typeid= " + TypeId);
                     if (dt3.Rows.Count > 0)
                     {
                         TypeName = dt3.Rows[0]["TypeName"].ToString();
                     }
                     Artilelist += "<div class=\"containerRightOthList\"><div class=\"conListpic\"><a href='" + NewsLink + "' class=\"preview\"><img src='../FileUpload/Images/NewsImages/" + PicUrl + "' width=\"80px\" height=\"80px\"/></a></div><div class=\"conListRight\"><div class=\"conListRightTitle\">[<b>" + TypeName + "</b>]<a href='" + NewsLink + "'>" + NewsTitle + "</a></div><div class=\"conListRightCenter\"><span class=\"info\"> <small>日期：</small>" + CreateTime + "<small>&nbsp;&nbsp;&nbsp;&nbsp;点击：</small>" + click + " <small>&nbsp;&nbsp;&nbsp;&nbsp;来源：</small>" + Url + "</span></div><div class=\"conListRightConten\">" + Content.Substring(0, 70) + "...</div></div></div>";
                 }
                 
                 tempcontent = tempcontent.Replace("{$Artilelist}", Artilelist);
                 tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);

                 Html.DirFile.CreateFile(savePath + "index.html", tempcontent);
                 Artilelist = null;

             }
        }

        public static void MakeArticleList()
        {
            Sqlcmd sqlcd = new Sqlcmd();
            string ModelPath = "Model\\PC\\Article\\ArtileList.html";
            
            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            string savePath = "Article\\"; 
            string Artilelist = null;
            string typelist=null;

            DataTable dt = sqlcd.getCommonData("ArticleType"," * "," 1=1 ");
            if (dt.Rows.Count > 0)
            {
                  
                    for (int type = 0; type < dt.Rows.Count; type++)
                    {
                        string listid = dt.Rows[type]["Typeid"].ToString();
                        
                        string TypeName = dt.Rows[type]["TypeName"].ToString();

                        DataTable dtpagecount = sqlcd.getCommonData("Article", " * ", " TypeId= " + listid);
                        string listLink = "";
                        if (dtpagecount.Rows.Count <= 7)
                        {
                            listLink = "'List_" + listid + ".html'";
                        }
                        else { listLink = "'List_" + listid + "_1.html'"; }
                        
                        int result = sqlcd.CommonUpdate("ArticleType", " TypeLink = " + listLink, " Typeid =" + listid);
                        if (result != 0)
                        {
                            string TypeLink = dt.Rows[type]["TypeLink"].ToString();
                            typelist += "<div class=\"containerLeftBoxOth\"><a href=" + TypeLink + " target=\"_top\">" + TypeName + "</a></div>";
                        }
                    }
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        string listid = dt.Rows[i]["Typeid"].ToString();
                        string listLink = "List_" + listid + ".html";


                        string TypeName = dt.Rows[i]["TypeName"].ToString();
                        DataTable dt2 = sqlcd.getCommonData("Article", " * ", " TypeId= " + listid);
                      
                        if (dt2.Rows.Count <= 7)
                        {
                            string tempcontent = Html.DirFile.ReadFile(ModelPath);
                            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
                            for (int j = dt2.Rows.Count - 1; j >= 0; j--)
                            {
                                string NewsLink = dt2.Rows[j]["NewsLink"].ToString();
                                string NewsTitle = dt2.Rows[j]["Title"].ToString();
                                string PicUrl = dt2.Rows[j]["PicUrl"].ToString();
                                string CreateTime = dt2.Rows[j]["CreateTime"].ToString();
                                string click = dt2.Rows[j]["Click"].ToString();
                                string Url = dt2.Rows[j]["Url"].ToString();
                                string Content = dt2.Rows[j]["Content"].ToString();

                                Artilelist += "<div class=\"containerRightOthList\"><div class=\"conListpic\"><a href='" + NewsLink + "' class=\"preview\"><img src='../FileUpload/Images/NewsImages/" + PicUrl + "' width=\"80px\" height=\"80px\"/></a></div><div class=\"conListRight\"><div class=\"conListRightTitle\">[<b>" + TypeName + "</b>]<a href='" + NewsLink + "'>" + NewsTitle + "</a></div><div class=\"conListRightCenter\"><span class=\"info\"> <small>日期：</small>" + CreateTime + "<small>&nbsp;&nbsp;&nbsp;&nbsp;点击：</small>" + click + " <small>&nbsp;&nbsp;&nbsp;&nbsp;来源：</small>" + Url + "</span></div><div class=\"conListRightConten\">" + Content.Substring(0, 70) + "...</div></div></div>";
                            }
                            tempcontent = tempcontent.Replace("{$CurrentTypeLink}", listLink);
                            tempcontent = tempcontent.Replace("{$DetailTitle}", "");
                            tempcontent = tempcontent.Replace("{$ColumnTitle}", "新闻中心-");
                            tempcontent = tempcontent.Replace("{$TypeNameTitle}", TypeName + "-");
                            tempcontent = tempcontent.Replace("{$CurrentTypeName}", TypeName);
                            tempcontent = tempcontent.Replace("{$Pagelink}", null);
                            tempcontent = tempcontent.Replace("{$Typelist}", typelist);
                            tempcontent = tempcontent.Replace("{$Artilelist}", Artilelist);
                            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);

                            Html.DirFile.CreateFile(savePath + listLink, tempcontent);
                            Artilelist = null;

                        }
                        else
                        {
                            int count = dt2.Rows.Count;
                            int page = count / 7;
                            int lastpagenum = count % 7;
                            string pagelink = null;
                            string pagetypelink ="'List_" + listid + "_1" + ".html'";
                            int result = sqlcd.CommonUpdate("ArticleType", " TypeLink = " + pagetypelink, " Typeid =" + listid);
                            pagelink = "<li class=\"previous-off\"><a href='" + "List_" + listid + "_1" + ".html" + "'>首页</a></li>";
                            for (int apge = 1; apge <= page; apge++)
                            {
                                pagelink += "<li><a href='" + "List_" + listid + "_" + apge + ".html" + "'>" + apge + "</a></li>";
                            }
                            int last = page + 1;
                            pagelink += "<li><a href='" + "List_" + listid + "_last" + ".html" + "'>" + last + "</a></li><li class=\"next\"><a href='" + "List_" + listid + "_last" + ".html" + "'>尾页</a></li>";
                            if (result != 0)
                            {
                                for (int m = 1; m <= page; m++)
                                {
                                    string tempcontent = Html.DirFile.ReadFile(ModelPath);
                                    tempcontent = tempcontent.Replace("{$header$}", Headercontent);
                                    string PageListLink = "List_" + listid + "_" + m + ".html";

                                    for (int n = count - 1; n >= count - 7; n--)
                                    {
                                        string NewsLink = dt2.Rows[n]["NewsLink"].ToString();

                                        string NewsTitle = dt2.Rows[n]["Title"].ToString();
                                        string PicUrl = dt2.Rows[n]["PicUrl"].ToString();
                                        string CreateTime = dt2.Rows[n]["CreateTime"].ToString();
                                        string click = dt2.Rows[n]["Click"].ToString();
                                        string Url = dt2.Rows[n]["Url"].ToString();
                                        string Content = dt2.Rows[n]["Content"].ToString();

                                        Artilelist += "<div class=\"containerRightOthList\"><div class=\"conListpic\"><a href='" + NewsLink + "' class=\"preview\"><img src='../FileUpload/Images/NewsImages/" + PicUrl + "' width=\"80px\" height=\"80px\"/></a></div><div class=\"conListRight\"><div class=\"conListRightTitle\">[<b>" + TypeName + "</b>]<a href='" + NewsLink + "'>" + NewsTitle + "</a></div><div class=\"conListRightCenter\"><span class=\"info\"> <small>日期：</small>" + CreateTime + "<small>&nbsp;&nbsp;&nbsp;&nbsp;点击：</small>" + click + " <small>&nbsp;&nbsp;&nbsp;&nbsp;来源：</small>" + Url + "</span></div><div class=\"conListRightConten\">" + Content.Substring(0, 70) + "...</div></div></div>";
                                    }

                                    count -= 7;
                                    tempcontent = tempcontent.Replace("{$CurrentTypeLink}", listLink);
                                    tempcontent = tempcontent.Replace("{$DetailTitle}", "");
                                    tempcontent = tempcontent.Replace("{$ColumnTitle}", "新闻中心-");
                                    tempcontent = tempcontent.Replace("{$TypeNameTitle}", TypeName+"-");
                                    tempcontent = tempcontent.Replace("{$CurrentTypeName}", TypeName);
                                    tempcontent = tempcontent.Replace("{$Pagelink}", pagelink);
                                    tempcontent = tempcontent.Replace("{$Typelist}", typelist);
                                    tempcontent = tempcontent.Replace("{$Artilelist}", Artilelist);
                                    tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
                                    Artilelist = null;
                                    Html.DirFile.CreateFile(savePath + PageListLink, tempcontent);

                                    // return savePath + PageListLink;
                                }
                            }
                            if (lastpagenum > 0)
                            {
                                string tempcontent = Html.DirFile.ReadFile(ModelPath);
                                tempcontent = tempcontent.Replace("{$header$}", Headercontent);
                                string PageListLink = "List_" + listid + "_last" + ".html";
                                for (int k = count - 1; k >= 0; k--)
                                {
                                    string NewsLink = dt2.Rows[k]["NewsLink"].ToString();
                                    string NewsTitle = dt2.Rows[k]["Title"].ToString();
                                    string PicUrl = dt2.Rows[k]["PicUrl"].ToString();
                                    string CreateTime = dt2.Rows[k]["CreateTime"].ToString();
                                    string click = dt2.Rows[k]["Click"].ToString();
                                    string Url = dt2.Rows[k]["Url"].ToString();
                                    string Content = dt2.Rows[k]["Content"].ToString();

                                    Artilelist += "<div class=\"containerRightOthList\"><div class=\"conListpic\"><a href='" + NewsLink + "' class=\"preview\"><img src='../FileUpload/Images/NewsImages/" + PicUrl + "' width=\"80px\" height=\"80px\"/></a></div><div class=\"conListRight\"><div class=\"conListRightTitle\">[<b>" + TypeName + "</b>]<a href='" + NewsLink + "'>" + NewsTitle + "</a></div><div class=\"conListRightCenter\"><span class=\"info\"> <small>日期：</small>" + CreateTime + "<small>&nbsp;&nbsp;&nbsp;&nbsp;点击：</small>" + click + " <small>&nbsp;&nbsp;&nbsp;&nbsp;来源：</small>" + Url + "</span></div><div class=\"conListRightConten\">" + Content.Substring(0, 70) + "...</div></div></div>";
                                }
                                tempcontent = tempcontent.Replace("{$CurrentTypeLink}", listLink);
                                tempcontent = tempcontent.Replace("{$DetailTitle}", "");
                                tempcontent = tempcontent.Replace("{$ColumnTitle}", "新闻中心-");
                                tempcontent = tempcontent.Replace("{$TypeNameTitle}", TypeName + "-");
                                tempcontent = tempcontent.Replace("{$CurrentTypeName}", TypeName);
                                tempcontent = tempcontent.Replace("{$Typelist}", typelist);
                                tempcontent = tempcontent.Replace("{$Pagelink}", pagelink);
                                tempcontent = tempcontent.Replace("{$Artilelist}", Artilelist);
                                tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
                                Artilelist = null;
                                Html.DirFile.CreateFile(savePath + PageListLink, tempcontent);

                                //  return savePath + PageListLink;
                            }
                        }

                    }
            }


        }

        public static string MakeArticleContentByID(int NewsID)
        {
            string ModelPath = "Model\\PC\\Article\\Detail.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            string htmlfilename = "Article_" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(DateTime.Now.ToString("yyyyMMdd"), "MD5").ToLower().Substring(8, 16) + "_" + Guid.NewGuid().ToString().Replace("-", "_") + ".html";
            string savePath = "Article\\"; ;
            BLL.Article ArticleBll = new BLL.Article();

            Model.ModelArtice mArticle = new Model.ModelArtice();
            mArticle = ArticleBll.GetModel(NewsID);
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);

            tempcontent = tempcontent.Replace("{$ArticleTitle}", mArticle.Title);
            tempcontent = tempcontent.Replace("{$ArticleAuthor}", mArticle.Author);
            tempcontent = tempcontent.Replace("{$ArticleUrl}", mArticle.Url);
            tempcontent = tempcontent.Replace("{$ArticleTypeName}", mArticle.TypeName);
            tempcontent = tempcontent.Replace("{$DetailTitle}", mArticle.Title+"-");
            tempcontent = tempcontent.Replace("{$ColumnTitle}", "新闻中心-");
            tempcontent = tempcontent.Replace("{$TypeNameTitle}", mArticle.TypeName + "-");
            tempcontent = tempcontent.Replace("{$ArticleTypeLink}", mArticle.TypeLink);
            tempcontent = tempcontent.Replace("{$ArticleKeyword}", mArticle.Keyword);
            tempcontent = tempcontent.Replace("{$ArticleClick}", mArticle.Click);
            tempcontent = tempcontent.Replace("{$ArticleContent}", mArticle.Content);
            tempcontent = tempcontent.Replace("{$ArticleCreatime}", mArticle.Creatime.ToString());

            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);

            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);

            return htmlfilename;
        }

       
    }
}
