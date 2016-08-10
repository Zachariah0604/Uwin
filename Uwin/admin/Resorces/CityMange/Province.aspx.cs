using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Model;

namespace Uwin.admin.Resorces.CityMange
{
    public partial class Province : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string condi = "1=1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProvinceList();
               
            }
        }
        private void ProvinceList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("ExProvince", "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ProvinceRepeter, 9);

            ProvinceRepeter.DataBind();
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProvinceRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ProvinceRepeter.Items[i].FindControl("ProvinceCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ProvinceRepeter.Items[i].FindControl("id");

                    sqlcmd.CommonDeleteColumns("dbo.ExProvince", "where id= " + lb.Text);


                }
            }
            ProvinceList();
        }
    }
}