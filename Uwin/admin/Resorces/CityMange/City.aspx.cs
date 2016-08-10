using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace Uwin.admin.Resorces.CityMange
{
    public partial class City : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        
        static string condi = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["code"] != null)
            {
                condi = Request.QueryString["code"].ToString();
            }
            if (!IsPostBack)
            {
                CityList();
                

            }
        }
        private void CityList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("ExCity", "*", " provinceId = " + condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, CityRepeter, 9);
           
            CityRepeter.DataBind();
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CityRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)CityRepeter.Items[i].FindControl("CityCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)CityRepeter.Items[i].FindControl("id");

                    sqlcmd.CommonDeleteColumns("dbo.ExCity", "where id= " + lb.Text);


                }
            }
            CityList();
        }
    }
}