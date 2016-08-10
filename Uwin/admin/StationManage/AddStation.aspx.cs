using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Model;

namespace Uwin.admin.StationManage
{
    public partial class AddStation : System.Web.UI.Page
    {
        public static int roleId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Admin admin = new Admin();
                SqlCommand sqlcmd = admin.station();
                sqlcmd.Connection.Open();
                SqlDataReader dr = sqlcmd.ExecuteReader();
                while (dr.Read())
                {
                   

                    AdminRole.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["rolid"].ToString()));

                }
                dr.Close();
            }
        }

        Admin adminbll = new Admin();
        ModelStation mstation = new ModelStation();
        protected void AdminRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleId = Convert.ToInt32(this.AdminRole.SelectedValue.ToString());
        }

       
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            mstation.station = stationName.Text;
            mstation.roleId = roleId;
            if (adminbll.StationAdd(mstation) != 0)
            {
                Response.Redirect("StationManage.aspx");
            }
        }
    }
}