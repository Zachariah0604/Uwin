using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;
using System.Data.SqlClient;
using System.Web.Security;

namespace Uwin.admin
{
     
    public partial class Login : System.Web.UI.Page
    {
        public static int roleId=1;
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

                }
                dr.Close();
            }
        }

        protected void Station_SelectedIndexChanged(object sender, EventArgs e)
        {

            roleId = Convert.ToInt32(this.Station.SelectedValue.ToString());
           
        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string vCode = Session["CheckCode"].ToString();
            if (ValidCode.Text.Trim().ToUpper() != vCode.ToUpper())
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('验证码不正确');", true);
            }
            else
            {
                string adminname = name.Text.Trim();
                string pwd = password.Text.Trim();
                string pwdmd51 = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
                string pwdmd52 = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdmd51, "MD5");
                Admin admin = new Admin();
                int count = admin.adminLogin(adminname, pwdmd52, roleId);
                if (count != 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(adminname, false);  
                   
                    Response.Redirect("index.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('请检查您的用户名或密码是否正确')", true);

                }
            }
        }

      
        

    }
}