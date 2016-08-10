using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BLL;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using System.Collections.Specialized; 
namespace Uwin
{
    public partial class EmailActivate : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sUserID = string.Empty;
            string UserIDMd2 = string.Empty;
            string sID = Request.QueryString["code"].Trim();

            string ToUserEmail = Server.UrlDecode(Request.QueryString["RegEmail"]).Trim();
            
            
            string sUserName = Request.QueryString["UN"].ToString().Trim();
            
           

            try
            {
                sUserID = BLL.Memeber.EmailCheck(sUserName, ToUserEmail).ToString();
                string UserIDMd = FormsAuthentication.HashPasswordForStoringInConfigFile(sUserID, "MD5").ToLower().Substring(8, 16);
                UserIDMd2 = FormsAuthentication.HashPasswordForStoringInConfigFile(UserIDMd, "MD5").ToLower().Substring(8, 16);
            }
            catch (Exception ex)
            {
               
            }
            if (String.Compare(sID, UserIDMd2) == 0)
            {
                sqlcmd.CommonUpdate("Memeber", " userState = 1", " userID =" + sUserID);
                DataTable dt = sqlcmd.getCommonData("Memeber", "*", " userID =" + sUserID + " and userState = 1");
                if (dt.Rows.Count > 0)
                {
                    Session["User_Name"] = dt.Rows[0]["userName"].ToString();
                    Session["RegisterState"] = "success";
                    Response.Redirect("../User/Register.html");
                }
                
            }
            else
            {
                Response.Write("<script>alert('激活失败，请重试，或者联系淄博悦赢')</script>");
               
            }
        }
       
    }
}