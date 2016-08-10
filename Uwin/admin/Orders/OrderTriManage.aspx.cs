using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Uwin.admin.Orders
{
    public partial class OrderTriManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string condi = " Orders.IsTrial = 1  order by orderID desc";

        protected void Page_Load(object sender, EventArgs e)
        {
            AffilMerchantBind();
            OrderListBind();
        }

        protected void OrderListBind()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("Orders", "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, OrderTriRepeter, 9);

            OrderTriRepeter.DataBind();
        }
        private void AffilMerchantBind()
        {
            this.orderAffilMerchant.DataSource = sqlcmd.getCommonData(" Merchant ", "*", null);
            this.orderAffilMerchant.DataTextField = "MerchantName";
            this.orderAffilMerchant.DataValueField = "MerchantID";
            this.orderAffilMerchant.DataBind();
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderTriRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)OrderTriRepeter.Items[i].FindControl("OrderTriCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)OrderTriRepeter.Items[i].FindControl("orderID");

                    sqlcmd.CommonDeleteColumns("dbo.Orders", "where orderID= " + lb.Text);


                }
            }
            OrderListBind();
        }

        protected void orderAffilMerchant_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = " Orders.orderAffilMerchant = " + this.orderAffilMerchant.SelectedValue.ToString();
            OrderListBind();
        }

        protected void orderState_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = " Orders.orderState = " + this.orderAffilMerchant.SelectedValue.ToString();
            OrderListBind();
        }
    }
}