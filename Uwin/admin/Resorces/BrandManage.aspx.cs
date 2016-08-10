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
    public partial class BrandManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string tableName = "dbo.ItemBrand";
        string condi = "1=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BrandList();
        }


        private void BrandList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex(tableName, "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, BrandRepeter, 9);

            BrandRepeter.DataBind();
            //this.BrandRepeter.DataSource = sqlcmd.getCommonData(tableName, "*", condi);
            //this.BrandRepeter.DataBind();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BrandRepeter.Items.Count; i++)
            {
                CheckBox box = (CheckBox)BrandRepeter.Items[i].FindControl("BrandCheck");
                if (box.Checked)
                {
                    Label lb = (Label)BrandRepeter.Items[i].FindControl("BrandID");
                    string condi = "where BrandID=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.ItemBrand", condi);
                }
            }
            BrandList();
        }
    }
}