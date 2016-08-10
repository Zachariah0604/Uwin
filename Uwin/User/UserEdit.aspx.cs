using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;

namespace Uwin.User
{
    public partial class UserEdit : System.Web.UI.Page
    {
        string username = null;
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] != null && Session["User_Name"].ToString() != "")
                {
                    username = Session["User_Name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('对不起，您还未登录');window.location='../index.shtml';</script>");
                }
            }
            
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = sqlcmd.getCommonData("Memeber ", " userPassword ", " userName = '" + username + "'");
            if (dt.Rows.Count > 0)
            {
                string userpwd = dt.Rows[0]["userPassword"].ToString();
                if (this.OldPassword.Text.ToString() != userpwd)
                {
                    Response.Write("<script>alert('原密码不正确，请重新输入')</script>");
                }
                else {
                    int result = sqlcmd.CommonUpdate("Memeber ", " userPassword = " + this.userPassword.Text.ToString(), " userName = '" + username + "'");
                    if (result != 0)
                    {
                        Response.Write("<script>alert('密码修改成功，请牢记您的新密码')</script>");
                    }
                    else {
                        Response.Write("<script>alert('发生错误，请重试')</script>");
                    }
                }
            }
            
        }
    }
}