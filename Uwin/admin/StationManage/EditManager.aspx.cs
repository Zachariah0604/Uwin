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
    public partial class EditManager : System.Web.UI.Page
    {
        public static int roleId = 1;
        public static int stationid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                    Response.Redirect("StationAndMananer.aspx");
                else
                {
                    show();

                    Admin admin = new Admin();
                    SqlCommand sqlcmd = admin.station();
                    sqlcmd.Connection.Open();
                    SqlDataReader dr = sqlcmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Station.Items.Add(new ListItem(dr["station"].ToString(), dr["staid"].ToString()));

                        AdminRole.Items.Add(new ListItem(dr["RoleName"].ToString(), dr["rolid"].ToString()));
                        //Station.Items.Add( new ListItem( dr[1].ToString(),dr[0].ToString() ) );

                    }
                    dr.Close();
                }
            }
        }

        Admin adminbll = new Admin();
        ModelAdmin madmin = new ModelAdmin();
        private void show()
        {
            if (Request.QueryString["id"] != null)
            {
                string id=Request.QueryString["id"].ToString();
                madmin = adminbll.GetModel(int.Parse(id));
                Name.Text = madmin.name;
                Telephone.Text = madmin.tele;
                email.Text = madmin.email;
                AdminRole.SelectedValue = madmin.roleId.ToString();
                Station.SelectedValue = madmin.stationId.ToString();
                
            }
        }
        protected void AdminRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            roleId = Convert.ToInt32(this.AdminRole.SelectedValue.ToString());
        }

        protected void Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            stationid = Convert.ToInt32(this.Station.SelectedValue.ToString());
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            madmin.id = int.Parse(Request.QueryString["id"].ToString());
            madmin.name = "'" + Name.Text+ "'";
            madmin.pwd = "'" + Password.Text + "'";
            madmin.tele = "'" + Telephone.Text + "'";
            madmin.email = "'" + email.Text + "'";
            madmin.roleId = roleId;
            madmin.stationId = stationid;

            if (adminbll.Update(madmin) != 0)
            {
                Response.Write("修改成功");
                //Response.Redirect("StationAndMananer.aspx");
            }
            else
            {
                Response.Write("修改失败");
            }
        }
    }
}