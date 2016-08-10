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

namespace Uwin.admin.Resorces
{
    public partial class ExpressManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string tableName = "dbo.Express";
        string condi = "1=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ExpressList();
        }
        private void ExpressList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex(tableName, "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ExpressRepeter, 9);

            ExpressRepeter.DataBind();
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ExpressRepeter.Items.Count; i++)
            {
                CheckBox box = (CheckBox)ExpressRepeter.Items[i].FindControl("ExpressCheck");
                if (box.Checked)
                {
                    Label lb = (Label)ExpressRepeter.Items[i].FindControl("ID");
                    string condi = "where ID=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.Express", condi);
                }
            }
            ExpressList();
        }
    }
}