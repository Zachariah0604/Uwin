using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Uwin.admin.ArticleManage
{
    public partial class EditType : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Typeid"] != null)
            {
                string Typeid = Request.QueryString["Typeid"].ToString();
                string TypeName = this.TypeName.Text;

                string colums = "TypeName='" + TypeName + "'";

                string condi="Typeid ="+Typeid;
                int result= sqlcmd.CommonUpdate("dbo.ArticleType", colums, condi);
                if (result != 0)
                {
                    Response.Write("修改成功");
                }
                else
                    Response.Write("修改失败");
            }
        }
    }
}