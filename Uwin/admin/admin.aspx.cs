using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Data.SqlClient;

namespace Uwin.admin
{
    public partial class admin : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();

        string colums = "substring(CONVERT(char(10),orderCreatTime,120),1,10)";

        protected int RowsCount;
        protected string OrdersNum;


        protected string RowsDay;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable CountName = new DataTable(); ;
                GetRepeterData(ArticleRepeter, "Article", " top 10 NewsId,Title,TypeId,Author,Click ", "NewsId", CountName, ArticleCount);
                GetRepeterData(UserRepeter, "Memeber", " top 10 userID,userName,nickName,userEmail ", "userID", CountName, UserCount);
                GetRepeterData(ItemsRepeter, "Items", " top 10 itemsID,itemName,itemSalePrice,itemStock,itemSaleNum ", "itemsID", CountName, ItemsCount);
                GetRepeterData(MerchantRepeter, "Merchant", " top 10 MerchantID,MerchantName,AffliStation,MerchantAddress ", "MerchantID", CountName, OrderCount);

                getOrdersCount();
                
                this.IpAddress.Text = "当前登录IP："+System.Web.HttpContext.Current.Request.UserHostAddress;
                this.serverName.Text = "主域名："+"http://" + Request.Url.Host;

                this.serverNet.Text = ".NET解释引擎版本：" + ".NET CLR" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;
                this.serverSession.Text = "虚拟目录Session总数：" + Session.Contents.Count.ToString();


                this.serverIIS.Text = "IIS 版本：" + Request.ServerVariables["SERVER_SOFTWARE"].ToString();
              
               
            }
        }

        private void GetRepeterData(Repeater RepeterName,string table,string columns,string condition,DataTable CountName,Label LableName)
        {
            DataTable dt = sqlcmd.getCommonData(table, columns, " 1=1 order by " + condition + " desc");
            RepeterName.DataSource = dt.DefaultView;
            RepeterName.DataBind();
            if (table == "Merchant")
                table = "Orders";
            CountName = sqlcmd.getCommonData(table, " COUNT(*) count ", " 1=1 ");
            if (CountName.Rows.Count > 0)
                LableName.Text = CountName.Rows[0]["count"].ToString();
        }

        private void getOrdersCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Orders", colums, "1=1");
            if (dt.Rows.Count > 0)
            {
                
                RowsCount = dt.Rows.Count;
                if (RowsCount > 15)
                    RowsCount = 15;
                for (int i = RowsCount - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();


                        if (i < dt.Rows.Count - 1)
                            OrdersNum += ", " + daynum;
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
       
        
       
        
    }
}