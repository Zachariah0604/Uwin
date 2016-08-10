using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Model;

namespace Uwin.admin.StationManage
{
    public partial class RoleManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string table = "dbo.uwinRole";
        string condi = "1=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RoleList();
        }


        private void RoleList()
        {
            this.RoleRepeter.DataSource = sqlcmd.getCommonData(table, "*", condi);
            this.RoleRepeter.DataBind();
        }
    }
}