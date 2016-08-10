using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Uwin.admin.Resorces.CityMange
{
    public partial class Area : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();

        static string condi = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["code"] != null)
            {
                condi = Request.QueryString["code"].ToString();
            }
            if (!IsPostBack)
            {
                AreaList();


            }
        }
        private void AreaList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("ExArea", "*", " cityId = " + condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, AreaRepeter, 9);

            AreaRepeter.DataBind();
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AreaRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)AreaRepeter.Items[i].FindControl("AreaCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)AreaRepeter.Items[i].FindControl("id");

                    sqlcmd.CommonDeleteColumns("dbo.ExArea", "where id= " + lb.Text);


                }
            }
            AreaList();
        }
    }
}