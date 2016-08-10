using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
namespace Uwin.User
{
    public partial class UserAddressAdd : System.Web.UI.Page
    {


        Sqlcmd sqlcmd = new Sqlcmd();
        UserAddress address = new UserAddress();
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
                     DataTable dt= sqlcmd.getCommonData("Memeber", " userID ", " userName ='" + username+"'");
                     if (dt.Rows.Count > 0)
                     {
                         UserId = int.Parse(dt.Rows[0]["userID"].ToString());
                     }
                }
            }
        }

        

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string  provice = this.ddlProvince.SelectedItem.Text.ToString();
            string city = this.ddlCity.SelectedItem.ToString();
            string Villiage = this.ddlVilliage.SelectedItem.Text.ToString();
            ModelUserAddress model = new ModelUserAddress()
            {
                AffliUserID = UserId,
                AffliExpress=0,
                ReceUser = this.ReceUser.Text,
                ReceTele = this.ReceTele.Text,
                ReceArea = provice + "  " + city + "  " + Villiage,
                ReceAddress = this.ReceAddress.Text
            };
            int count = address.AddUserAddress(model);
            if (count != 0)
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
            else { Response.Write("<script>alert('发生未知错误')</script>"); }
        }
    }
}