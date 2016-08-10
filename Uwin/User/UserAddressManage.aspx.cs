using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using BLL;


namespace Uwin.User
{
    public partial class UserAddressManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string condi;

        int UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Write("<script>alert('对不起，您还未登录');window.location='../index.shtml';</script>");
                }
                else
                {
                    string username = Session["User_Name"].ToString();
                    DataTable dt = sqlcmd.getCommonData("Memeber", " userID ", " userName ='" + username + "'");
                    if (dt.Rows.Count > 0)
                    {
                        UserId = int.Parse(dt.Rows[0]["userID"].ToString());
                    }

                    UserAddressList();
                }
                    
            }
        }
        private void UserAddressList()
        {
            condi = " AffliUserID=" + UserId;
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("UserAddress", " * ", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, UserAddressRepeter, 5);

            UserAddressRepeter.DataBind();
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UserAddressRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)UserAddressRepeter.Items[i].FindControl("UserAddressCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)UserAddressRepeter.Items[i].FindControl("id");

                    string condi = "where id=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.UserAddress", condi);


                }
            }
            UserAddressList();
        }
    }
}