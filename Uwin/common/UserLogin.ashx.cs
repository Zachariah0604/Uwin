using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.Security;
namespace Uwin.common
{
    /// <summary>
    /// Summary description for UserLogin
    /// </summary>
    public class UserLogin : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request.Form["username"] != null && context.Request.Form["password"] != null)
            {
                string name = context.Request.Form["username"];
                string pwd = context.Request.Form["password"];
                string pwdmd51 = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
                string pwdmd52 = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdmd51, "MD5");
                BLL.Memeber users = new BLL.Memeber();
                int count = users.UserLogin(name, pwdmd52);
                
                if (count != 0)
                {

                    context.Session["User_Name"] = name;
                    context.Response.Write("success");

                }
                else
                {

                    context.Response.Write("fail");

                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}