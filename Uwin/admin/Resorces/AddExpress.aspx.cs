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
using Model;
namespace Uwin.admin.Resorces
{
    public partial class AddExpress : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string table = "dbo.Express";
            string ExpresssName = "'" + this.ExpresssName.Text + "'";
            string ExpresssTele = "'" + this.ExpresssTele.Text + "'";
            string ExpressAddress = "'" + this.ExpressAddress.Text + "'";
            string ExpressRemark = "'" + this.ExpressRemark.Text + "'";
            string values=ExpresssName + "," + ExpresssTele + "," + ExpressAddress + "," + ExpressRemark;
            int count = sqlcmd.CommonInsert(table, " ExpresssName,ExpresssTele,ExpressAddress,ExpressRemark ", values);
            if (count != 0)
            {
                Response.Write("添加成功");
            }
            else
                Response.Write("添加失败");

        }
    }
}