using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
namespace Uwin.admin.SinglePage
{
    public partial class HelpCenter : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt= sqlcmd.getCommonData("SinglePage", " HelpCenter ", " id =1");
                if (dt.Rows.Count > 0)
                {
                    this.Content.Text = dt.Rows[0]["HelpCenter"].ToString();
                }
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string Content = this.Content.Text;
            int result = sqlcmd.CommonUpdate("SinglePage", " HelpCenter =" + Content," id =1");
            if (result != 0)
            {
                Response.Write("<scritp>alert('成功添加（更新）帮助中心页')</Script>");
            }
            else { Response.Write("<scritp>alert('未知错误')</Script>"); }

        }
    }
}