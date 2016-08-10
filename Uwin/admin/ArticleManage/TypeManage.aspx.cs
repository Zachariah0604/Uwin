using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;
using Model;


namespace Uwin.admin.ArticleManage
{
    public partial class TypeManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string tableName = "dbo.ArticleType";
        string condi = "1=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                TypeList();
        }


        private void TypeList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex(tableName, "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ArticleTypeRepeter, 9);

            ArticleTypeRepeter.DataBind();

            //this.ArticleTypeRepeter.DataSource = sqlcmd.getCommonData(tableName,"*",condi);
            //this.ArticleTypeRepeter.DataBind();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ArticleTypeRepeter.Items.Count; i++)
            {
                CheckBox box = (CheckBox)ArticleTypeRepeter.Items[i].FindControl("ArticleTypeCheck");
                if (box.Checked)
                {
                    Label lb = (Label)ArticleTypeRepeter.Items[i].FindControl("Typeid");
                    string condi = "where Typeid=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.ArticleType", condi);
                }
            }
        }
    }
}