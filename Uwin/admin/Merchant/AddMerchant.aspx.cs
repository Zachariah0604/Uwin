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

namespace Uwin.admin.Merchant
{
    public partial class AddMerchant : System.Web.UI.Page
    {
        
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StationBind();
            }
        }

        
        private void StationBind()
        {
            this.AffiliStation.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
            this.AffiliStation.DataTextField = "station";
            this.AffiliStation.DataValueField = "staid";
            this.AffiliStation.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string MerchantName = "'" + this.MerchantName.Text + "'";
            string AffiliStation = this.AffiliStation.SelectedValue.ToString();
            string MerchantState = this.MerchantState.SelectedValue.ToString();
            string MerchantAddress = "'" + this.MerchantAddress.Text + "'";
            string MerchantTele = "'" + this.MerchantTele.Text + "'";
            string MerchantFax = "'" + this.MerchantFax.Text + "'";
            string MerchantEmial = "'" + this.MerchantEmial.Text + "'";
            string values = MerchantName + "," + AffiliStation + "," + MerchantState+ "," +MerchantAddress+ "," +MerchantTele+ "," +MerchantFax+ "," +MerchantEmial;

            int result = sqlcmd.CommonInsert("Merchant", " MerchantName , AffliStation , MerchantState,MerchantAddress , MerchantTele,MerchantFax ,MerchantEmial", values);
            if (result != 0)
                Response.Write("添加成功");
            else
                Response.Write("添加失败");
        }
    }
}