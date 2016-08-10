using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Html;


namespace Uwin.admin.ArticleManage
{
    public partial class ActicleList : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();


        string condi = "1=1 order by NewsId desc";
        int pagesize = 9;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ArticleTypebind();
                ArticleList();
            }
        }

        private void ArticleList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("Article left join ArticleType on Article.TypeId=ArticleType.Typeid", "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ArticleRepeter, pagesize);
          
            ArticleRepeter.DataBind();
        }
        private void ArticleTypebind()
        {
            this.Type.DataSource = sqlcmd.getCommonData("ArticleType", "*", null);
            this.Type.DataTextField = "TypeName";
            this.Type.DataValueField = "TypeId";
            this.Type.DataBind();
        }
       
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ArticleRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ArticleRepeter.Items[i].FindControl("ArticleCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ArticleRepeter.Items[i].FindControl("NewsId");

                    string condi = "where NewsId=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.Article", condi);
                

                }
            }
            ArticleList();
        }
       

        protected void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = "ArticleType.TypeId =" + this.Type.SelectedValue.ToString();
            ArticleList();
        }
      
        protected void ToHtml_Click(object sender, EventArgs e)
        {
            int htmlCount = 0;
            for (int i = 0; i < ArticleRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ArticleRepeter.Items[i].FindControl("ArticleCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ArticleRepeter.Items[i].FindControl("NewsId");
                    string ArticleLink=ArticleHtml.MakeArticleContentByID(int.Parse(lb.Text));
                    htmlCount++;
                    sqlcmd.CommonUpdate(" Article ", " NewsLink = " + "'" + ArticleLink + "'", " NewsId = " + lb.Text);
                }
            }
            
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成" + htmlCount + "张静态页');</script>");
        }

        protected void AllToHtml_Click(object sender, EventArgs e)
        {
            int htmlCount = 0;
            DataTable dt = sqlcmd.getCommonData("Article", " NewsId "," 1=1");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int NewID = int.Parse(dt.Rows[i]["NewsId"].ToString());
                    string ArticleLink = ArticleHtml.MakeArticleContentByID(NewID);
                    htmlCount++;
                    sqlcmd.CommonUpdate(" Article ", " NewsLink = " + "'" + ArticleLink + "'", " NewsId = " + NewID);
                }
            }
          Response.Write("<Script Language='JavaScript'>window.alert('成功生成" + htmlCount + "张静态页');</script>");
        }
    }
}