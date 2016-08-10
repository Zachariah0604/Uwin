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

namespace Uwin.admin.Orders
{
    public partial class OrderManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string condi = " 1 = 1 order by orderID desc";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AffilMerchantBind();
                OrderListBind();
            }
        }

        protected void OrderListBind()
        { 
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("Orders", "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, OrderRepeter, 9);

            OrderRepeter.DataBind();
        }
        private void AffilMerchantBind()
        {
            this.orderAffilMerchant.DataSource = sqlcmd.getCommonData(" Merchant ","*",null);
            this.orderAffilMerchant.DataTextField = "MerchantName";
            this.orderAffilMerchant.DataValueField = "MerchantID";
            this.orderAffilMerchant.DataBind();
        }
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)OrderRepeter.Items[i].FindControl("OrderCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)OrderRepeter.Items[i].FindControl("orderID");

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
            condi = " Orders.orderState = " + this.orderState.SelectedValue.ToString();
            OrderListBind();
        }
        protected string SetMerchantName(string orderAffilMerchant)
        {
            DataTable  dt = sqlcmd.getCommonData(" Merchant ", " MerchantName ", " MerchantID = " + orderAffilMerchant);
            if (dt.Rows.Count > 0)
            {
                string MerchantName = dt.Rows[0]["MerchantName"].ToString();
                return MerchantName;
            }
            else
                return null;
        }
        protected string SetStateName(string OrderStates)
        {
          
            if("1"==OrderStates)
                return "待支付";
            if ("2" == OrderStates)
                return "已支付";
            if ("3" == OrderStates)
                return "备货中";
            if ("4" == OrderStates)
                return "已发货";
            if ("5" == OrderStates)
                return "已收货";
            if ("6" == OrderStates)
                return "申请退款";
            if ("7" == OrderStates)
                return "退款受理";
            if ("8" == OrderStates)
                return "已退款";
            else
                return null;
           
           
        }
        

    }
}