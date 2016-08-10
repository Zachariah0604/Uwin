using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;

namespace Uwin.User
{
    public partial class UserInfo : System.Web.UI.Page
    {
        Memeber userbll = new Memeber();
        ModelUser model = new ModelUser();
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] != null)
                {
                    int userid;
                    DataTable dt = sqlcmd.getCommonData("Memeber ", " userID ", " userName ='" + Session["User_Name"].ToString() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        userid = int.Parse(dt.Rows[0]["userID"].ToString());
                        model = userbll.getUserModel(userid);
                        this.userName.Text = model.userName;
                        this.userSex.Text = model.userSex;
                        this.userEmail.Text = model.userEmail;
                        this.userTele.Text = model.userTele;
                        this.userLevel.Text = model.userLevel;
                        this.userVipLevel.Text = model.userVipLevel;
                        this.userCreatime.Text = model.userCreatime.ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('对不起，您还未登录');window.location='../index.shtml';</script>");
                }
                

            }

        }
    }
}