using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;


namespace Html
{
    public class ActivityHtml
    {

        Sqlcmd sqlcmd = new Sqlcmd();
        public static string MakeActivityContentByID(int NewsID)
        {
            string ModelPath = "Model\\PC\\Article\\Detail.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("html\\Desktop\\Header.html");
            string Footercontent = Html.DirFile.ReadFile("html\\Desktop\\Footer.html");
            string htmlfilename = "Article_" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(DateTime.Now.ToString("yyyyMMdd"), "MD5").ToLower().Substring(8, 16) + "_" + Guid.NewGuid().ToString().Replace("-", "_") + ".html";
            string savePath = "html\\Desktop\\Article\\"; ;
            BLL.Article ArticleBll = new BLL.Article();

            Model.ModelArtice mArticle = new Model.ModelArtice();
            mArticle = ArticleBll.GetModel(NewsID);
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);

            tempcontent = tempcontent.Replace("{$ArticleTitle}", mArticle.Title);
            tempcontent = tempcontent.Replace("{$ArticleAuthor}", mArticle.Author);
            tempcontent = tempcontent.Replace("{$ArticleUrl}", mArticle.Url);
            tempcontent = tempcontent.Replace("{$ArticleTypeName}", mArticle.TypeName);
            tempcontent = tempcontent.Replace("{$ArticleKeyword}", mArticle.Keyword);
            tempcontent = tempcontent.Replace("{$ArticleClick}", mArticle.Click);
            tempcontent = tempcontent.Replace("{$ArticleContent}", mArticle.Content);
            tempcontent = tempcontent.Replace("{$ArticleCreatime}", mArticle.Creatime.ToString());

            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);

            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);

            return savePath + htmlfilename;
        }
    }
}
