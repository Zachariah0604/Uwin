using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uwin.common
{
    public partial class UserState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            
                if (Session["User_Name"] == null)
                {
                    //Response.Write("document.write('<input type=\"image\" src=\"../images/head_u_login.png\" onclick=\"showdiv()\">')");
                   // Response.Write("document.write('<a class=\"theme-login\" href=\"javascript:;\">点击查看效果</a>')");
                    Response.Write("document.write('<input type=\"image\" name=\"btn_login\" class=\"theme-login\" href=\"javascript:;\" id=\"btn_login\" src=\"../images/head_u_login.png\" />')");
                    
                    Response.End();

                }
                else
                {
                    string uname = Session["User_Name"].ToString();
                    Response.Write("document.write('<div><a href=\"../User/UserCenter.aspx\" target=\"_blank\" style=\"float:left\">" + uname + "</a>" + "  &nbsp;&nbsp;</div>')");
                    Response.End();
                }

        }
    }
}