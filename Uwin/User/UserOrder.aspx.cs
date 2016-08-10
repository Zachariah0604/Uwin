using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using BLL;


namespace Uwin.User
{
    public partial class UserOrder : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        static string condi;
        string condition;

        public static int  UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["User_Name"] == null)
                    {
                        Response.Write("<script>alert('对不起，您还未登录');window.location='../index.shtml';</script>");
                    }
                    else
                    {
                        string username = Session["User_Name"].ToString();
                        DataTable dt = sqlcmd.getCommonData("Memeber", " userID ", " userName ='" + username + "'");
                        if (dt.Rows.Count > 0)
                        {
                            UserId = int.Parse(dt.Rows[0]["userID"].ToString());
                        }
                        condi = "Orders.orderItemID=Items.itemsID where orderAffiUser=" + UserId + " and Orders.orderState";
                        condition = condi + "!=0";
                        UseOrderList();
                    }
                }
            }
        }
        private void UseOrderList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.JoinPageIndex("Orders left join Items ", " * ", condition);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, UserOrderRepeter, 5);

            UserOrderRepeter.DataBind();
        }
        protected string SetMerchantName(string orderAffilMerchant)
        {
            string MerchantName=null;
            DataTable dt = sqlcmd.getCommonData("Merchant ", " MerchantName ", " MerchantID=" + orderAffilMerchant);
            if (dt.Rows.Count > 0)
            {
                MerchantName= dt.Rows[0]["MerchantName"].ToString();
            }
            return MerchantName;
        }
        protected string SetSubTypeName(string itemAffiliSubType)
        {
            string sTypeName = null;
            DataTable dt = sqlcmd.getCommonData("ItmesSubType ", " sTypeName ", " SubTypeID=" + itemAffiliSubType);
            if (dt.Rows.Count > 0)
            {
                sTypeName = dt.Rows[0]["sTypeName"].ToString();
            }
            return sTypeName;
        }
        protected string SetStateName(string OrderStates)
        {

            if ("1" == OrderStates)
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

        protected void orderStateAll_Click(object sender, EventArgs e)
        {
            condition = condi + "!=0";
            UseOrderList();
        }

        protected void orderState1_Click(object sender, EventArgs e)
        {
            condition = condi + "=1";
            UseOrderList();
        }

        protected void orderState2_Click(object sender, EventArgs e)
        {
            condition = condi + "=2";
            UseOrderList();
        }

        protected void orderState3_Click(object sender, EventArgs e)
        {
            condition = condi + "=3";
            UseOrderList();
        }

        protected void orderState4_Click(object sender, EventArgs e)
        {
            condition = condi + "=4";
            UseOrderList();
        }

        protected void orderState5_Click(object sender, EventArgs e)
        {
            condition = condi + "=5";
            UseOrderList();

        }

        protected void orderState6_Click(object sender, EventArgs e)
        {
            condition = condi + "=0";
            UseOrderList();
        }

        protected void orderState8_Click(object sender, EventArgs e)
        {
            condition = condi + "=8";
            UseOrderList();
        }
    }
}