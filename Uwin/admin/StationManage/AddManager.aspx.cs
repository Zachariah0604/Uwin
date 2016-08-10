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
using System.Web.Security;

namespace Uwin.admin.StationManage
{
    public partial class AddManager : System.Web.UI.Page
    {
        public static int roleId = 1;
        public static int stationid = 1;
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
                    Station.Items.Add(new ListItem(dr["station"].ToString(), dr["staid"].ToString()));

                    AdminRole.Items.Add(new ListItem(dr["RoleName"].ToString(),dr["rolid"].ToString()));

                }
                dr.Close();
            }
        }

        Admin adminbll = new Admin();
        ModelAdmin madmin = new ModelAdmin();
        protected void AdminRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleId = Convert.ToInt32(this.AdminRole.SelectedValue.ToString());
        }

        protected void Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            stationid = Convert.ToInt32(this.Station.SelectedValue.ToString());
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            madmin.name = Name.Text;

            string pwdmd51 = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");
            string pwdmd52 = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdmd51, "MD5");
            madmin.pwd = pwdmd52;
            madmin.tele = telephone.Text;
            madmin.email = email.Text;
            madmin.roleId=roleId;
            madmin.stationId=stationid;
            if (adminbll.Add(madmin) != 0)
            {
                Response.Redirect("StationAndMananer.aspx");
            }
        }

        
    }
}