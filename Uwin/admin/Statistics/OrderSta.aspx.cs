using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace Uwin.admin.Statistics
{
    public partial class OrderSta : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();

        string colums = "substring(CONVERT(char(10),orderCreatTime,120),1,10)";

        protected int RowsCount;

        protected string OrdersNum;
        protected string OrderTriNum;

        protected int OrderCount;
        protected int OrderCommCount;
        protected int OrderTriCount;

        protected string RowsDay;



        protected int PaidCount;
        protected int NotPaidCount;

        protected int DeliveredCount;
        protected int NotDeliverCount;

        protected int ApplyForRefundCount;
        protected int AcceptForRefundCount;
        protected int BeRefundCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getOrdersCount();
                PaidCount = getCountData(" orderState = 1");
                NotPaidCount = getCountData(" orderState = 2");

                DeliveredCount = getCountData(" orderState = 4");
                NotDeliverCount = getCountData(" orderState = 3");

                ApplyForRefundCount = getCountData(" orderState = 6");
                AcceptForRefundCount = getCountData(" orderState = 7");
                BeRefundCount = getCountData(" orderState = 8");
            }
        }

        private void getOrdersCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Orders", colums, "1=1");
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["total"].ToString() != null)
                    {
                        OrderCount += Convert.ToInt32(dt.Rows[j]["total"].ToString());
                        OrderCommCount = OrderCount;
                    }
                }
                RowsCount = dt.Rows.Count;
                if (RowsCount > 20)
                    RowsCount = 20;
                for (int i = RowsCount - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();


                        if (i < dt.Rows.Count - 1)
                            OrdersNum += "," + daynum;
                        else
                            OrdersNum += daynum;
                    }
                    if (dt.Rows[i]["Dates"].ToString() != null)
                    {
                        string day = dt.Rows[i]["Dates"].ToString();
                        if (i < dt.Rows.Count - 1)
                            RowsDay += "," + day.Replace("-", "");
                        else
                            RowsDay += day.Replace("-", "");
                    }
                }
            }

        }


        private void getOrdersTriCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Orders", colums, " IsTrial = 'True' ");
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["total"].ToString() != null)
                    {
                        OrderTriCount += Convert.ToInt32(dt.Rows[j]["total"].ToString());
                    }
                }
                for (int i = RowsCount - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();

                        if (i < dt.Rows.Count - 1)
                            OrderTriNum += "," + daynum;
                        else
                            OrderTriNum += daynum;
                    }

                }
                OrderCommCount -= OrderTriCount;
            }

        }

        private int getCountData(string condition)
        {
            int CountNumByCondi=0;
            DataTable CountName = sqlcmd.getCommonData("Orders", " COUNT(*) count ", condition);
            if (CountName.Rows.Count > 0)
                CountNumByCondi = Convert.ToInt32(CountName.Rows[0]["count"].ToString());
            return CountNumByCondi;
        }
    }
}