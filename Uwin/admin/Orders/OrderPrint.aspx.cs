using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data.Sql;
using System.Data;
using Model;

namespace Uwin.admin.Orders
{
	public partial class OrderPrint : System.Web.UI.Page
	{

        Sqlcmd sqlcmd = new Sqlcmd();
        BLL.Order orderbll = new BLL.Order();
        BLL.Memeber userbll = new BLL.Memeber();
        BLL.Item itembll = new BLL.Item();
        Model.ModelOrder mOrder = new Model.ModelOrder();
        Model.ModelUser mUser = new Model.ModelUser();
        Model.ModelItems mItem = new Model.ModelItems();
        public string orderID;

        public decimal num;

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Request.QueryString["orderID"] == null)
                    Response.Write("ERROR");
                
                getOrderInfo();
                GetUserInfo();
                GetMerchantInfo();
                GetExpressInfo();
                CartRepeterBind();
                
                this.Upletter.Text = UpLetter(num);
            }
		}

        private void getOrderInfo()
        {
            if (Request.QueryString["orderID"]!=null)
                orderID=Request.QueryString["orderID"].ToString();
            mOrder = orderbll.getOrderModel(int.Parse(orderID));
            this.orderNum.Text = mOrder.orderNum.ToString();
            this.orderCreatTime.Text = mOrder.orderCreatTime.ToString();
            this.orderNum.Text = mOrder.orderNum.ToString();
            this.orderCost.Text = mOrder.orderCost.ToString();
            this.orderState.Text = mOrder.orderState.ToString();
            this.orderCountSum.Text = mOrder.orderCount.ToString();
            this.orderSumSum.Text = mOrder.orderCost.ToString();
            num = decimal.Parse(mOrder.orderCost.ToString());
        }

        private void GetUserInfo()
        {
            mUser = userbll.getUserModel(int.Parse(mOrder.orderAffiUser));
           
            this.userName.Text = mUser.userName.ToString();
            this.userCreatime.Text = mUser.userCreatime.ToString();
            this.userLevel.Text = mUser.userLevel.ToString();
            this.userEmail.Text = mUser.userEmail.ToString();
            this.userTele.Text = mUser.userTele.ToString();
            this.userSex.Text = mUser.userSex.ToString();
        }

        private void GetItemsInfo()
        {
            
        }
        private void GetMerchantInfo()
        {
            DataTable dt = sqlcmd.getCommonData("Merchant", "*", " MerchantID = " + mOrder.orderAffilMerchant);
            if (dt.Rows.Count > 0)
            
            {
                if (dt.Rows[0]["MerchantAddress"].ToString() != null)
                    this.MerchantAddress.Text = dt.Rows[0]["MerchantAddress"].ToString();
                if (dt.Rows[0]["MerchantTele"].ToString() != null)
                    this.MerchantTele.Text = dt.Rows[0]["MerchantTele"].ToString();
                if (dt.Rows[0]["MerchantFax"].ToString() != null)
                    this.MerchantFax.Text = dt.Rows[0]["MerchantFax"].ToString();
                if (dt.Rows[0]["MerchantEmial"].ToString() != null)
                    this.MerchantEmial.Text = dt.Rows[0]["MerchantEmial"].ToString();
                if (dt.Rows[0]["MerchantName"].ToString() != null)
                    this.MerchantName.Text = dt.Rows[0]["MerchantName"].ToString();
                if (dt.Rows[0]["AffliStation"].ToString() != null)
                {
                    DataTable dt2 = sqlcmd.getCommonData("uwinStation", "*", " staid = " + dt.Rows[0]["AffliStation"].ToString());
                    if (dt2.Rows.Count > 0)
                    {
                        if (dt2.Rows[0]["station"].ToString() != null)
                            this.station.Text = dt2.Rows[0]["station"].ToString();
                    }
                }

            }
        }
        private void GetExpressInfo()
        {
            DataTable dt = new DataTable();
            dt = sqlcmd.getCommonData("OrderExpress", "*", " AffliOrderID = " + int.Parse(mOrder.orderExpress.ToString()));
            if (dt.Rows.Count > 0)
            {
                this.expCompany.Text = dt.Rows[0]["expCompany"].ToString();
                this.expressNum.Text = dt.Rows[0]["expressNum"].ToString();
                this.expAdress.Text = dt.Rows[0]["expAdress"].ToString();
            }
        }

        private void CartRepeterBind()
        {
            DataTable dt = new DataTable();
            dt = sqlcmd.getCommonData("ShoppingCart", "*", " cartAffiUser = " + mUser.userID.ToString());
            if (dt.Rows.Count > 0)
            {
                CartRepeter.DataSource = dt.DefaultView;
                CartRepeter.DataBind();
            }
        }
      
        public static string UpLetter(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";           
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分";
            string str3 = "";    
            string str4 = "";    
            string str5 = ""; 
            int i;   
            int j;   
            string ch1 = "";    
            string ch2 = "";   
            int nzero = 0;  
            int temp;          

            num = Math.Round(Math.Abs(num), 2);    
            str4 = ((long)(num * 100)).ToString();      
            j = str4.Length;     
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   

            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);         
                temp = Convert.ToInt32(str3);     
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                   
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                   
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                   
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                   
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }
	}
}