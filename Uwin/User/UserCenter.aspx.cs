using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Uwin.User
{
    public partial class UserCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.ContentEncoding = System.Text.Encoding.Default;
                    Response.Write("<script>alert('对不起，您没有登录！');window.location.href='../index.shtml';</script>");
                   
                }
            }
        }
    }
}