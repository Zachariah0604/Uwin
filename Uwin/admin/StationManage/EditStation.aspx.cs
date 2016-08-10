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

namespace Uwin.admin.StationManage
{
    public partial class EditStation : System.Web.UI.Page
    {
        public static int roleId = 1;
        Sqlcmd sqlcmd = new Sqlcmd();
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

        
        protected void AdminRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleId = Convert.ToInt32(this.AdminRole.SelectedValue.ToString());
        }
        
       
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["staid"] != null)
            {
                int staid = int.Parse(Request.QueryString["staid"].ToString());
                string station = stationName.Text;
                string columns = "station='" + station +"'"+ ",roleId =" + roleId;
                string condi = "staid=" + staid;
                int result=sqlcmd.CommonUpdate("dbo.uwinStation", columns, condi);

                if (result != 0)
                {
                    Response.Write("修改成功");
                }
                else { Response.Write("修改失败"); }
                //Response.Redirect("StationAndMananer.aspx");
            }
            
        }
    }
}