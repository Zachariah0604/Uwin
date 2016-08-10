using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using BLL;
using Model;


namespace Uwin.admin.ArticleManage
{
    public partial class AddType : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string table = "dbo.ArticleType";
            string TypeName = "'" + this.TypeName.Text + "'";

            int count = sqlcmd.CommonInsert(table, "TypeName", TypeName);
            if (count != 0)
            {
                Response.Write("添加成功");
            }
            else
                Response.Write("添加失败");

        }
    }
}