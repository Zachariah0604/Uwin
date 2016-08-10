using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace Uwin.admin.StationManage
{
    public partial class StationManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string table = "dbo.uwinStation";
        string condi = " 1=1 order by staid desc";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                StationList();
        }


        private void StationList()
        {
            this.stationRepeter.DataSource = sqlcmd.getCommonData(table, "*", condi);
            this.stationRepeter.DataBind();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < stationRepeter.Items.Count; i++)
            {
                CheckBox box = (CheckBox)stationRepeter.Items[i].FindControl("stationCheck");
                if (box.Checked)
                {
                    Label lb = (Label)stationRepeter.Items[i].FindControl("staid");
                    string condi = "where id=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.uwinStation", condi);
                }
            }
        }
    }
}