using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace Uwin.admin.StationManage
{
    public partial class StationAndMananer : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string jointable = "dbo.uwinAdmin ,dbo.uwinStation,dbo.uwinRole";

        string condi = "dbo.uwinAdmin.stationId=dbo.uwinStation.staid and dbo.uwinAdmin.roleId=dbo.uwinRole.rolid order by dbo.uwinAdmin.id desc";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                StationAndManagerList();
        }


        private void StationAndManagerList()
        {
            this.adminRepeter.DataSource = sqlcmd.getCommonData(jointable, "*", condi);
            this.adminRepeter.DataBind();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < adminRepeter.Items.Count; i++)
            {
                CheckBox box = (CheckBox)adminRepeter.Items[i].FindControl("adminCheck");
                if (box.Checked)
                {
                    Label lb = (Label)adminRepeter.Items[i].FindControl("adminID");
                    string condi="where id=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.uwinAdmin", condi);
                }
            }
        }
    }

    
}