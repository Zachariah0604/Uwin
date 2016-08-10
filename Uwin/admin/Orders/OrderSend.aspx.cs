using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Uwin.admin.Orders
{
    public partial class OrderSend : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        BLL.OrderExpress OrderExpBLL = new BLL.OrderExpress();
        Model.ModelExp mExp = new Model.ModelExp();
        public static  int orderID;
        public  static int ExpressID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetExpData();
            }
        }
        private void GetExpData()
        {
            if (Request.QueryString["orderID"] != null)
                orderID = int.Parse(Request.QueryString["orderID"].ToString());
            mExp = OrderExpBLL.GetExpModel(orderID);
            this.AffliOrderID.Text = orderID.ToString();
            ExpressID = int.Parse(mExp.expressID.ToString());
            if (mExp.expCompany.ToString()!=null)
                this.expCompany.Text = mExp.expCompany;
            if (mExp.expressNum.ToString() != null)
                this.expressNum.Text = mExp.expressNum;
            if (mExp.expDeliveryTime.ToString() != null)
                this.expDeliveryTime.Text = mExp.expDeliveryTime.ToString("yyyyMMdd");
            if (mExp.expReceTime.ToString() != null)
                this.expReceTime.Text = mExp.expReceTime.ToString("yyyyMMdd");
            if (mExp.expAdress.ToString() != null)
                this.expAdress.Text = mExp.expAdress;
        }

        protected void SendBtn_Click(object sender, EventArgs e)
        {
            Model.ModelExp model=new Model.ModelExp()
            {
                expressID=ExpressID,
                AffliOrderID = int.Parse(this.AffliOrderID.Text.ToString()),
                expressNum = this.expressNum.Text.ToString(),
                expDeliveryTime = DateTime.Parse(this.expDeliveryTime.Text),
                //expReceTime = DateTime.Parse(this.expDeliveryTime.Text),
                expCompany = this.expCompany.Text.ToString(),
                expAdress = this.expAdress.Text.ToString(),
            };
           
            int count = OrderExpBLL.UpdateOrderExp(model);
            if (count != 0)
            {
                int count2 = sqlcmd.CommonUpdate("Orders", " orderState = 4 ", " orderID = " + orderID);
                if (count2!=0)
                    Response.Write("<script>alert('信息已更新，发货成功！')</script>");
            }
        }
    }
}