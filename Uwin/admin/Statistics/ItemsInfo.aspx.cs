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

namespace Uwin.admin.Statistics
{
    public partial class ItemsInfo : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected int RowsCount;
        protected  string ItemsNum;
        protected  string ItemsSecNum;
        protected  string ItemsTriNum;

        protected int ItemsCount;
        protected int ItemsTriCount;
        protected int ItemsSecCount;
        protected int ItemsCommCount;
        protected  string RowsDay;
        string colums = "substring(CONVERT(char(10),itemTime,120),1,10)";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                getItemsCount();
                getItemsTriCount();
                getItemsSecCount();
            }
        }

        private void getItemsCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Items", colums, "1=1");
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["total"].ToString() != null)
                    {
                        ItemsCount += Convert.ToInt32(dt.Rows[j]["total"].ToString());
                        ItemsCommCount = ItemsCount;
                    }
                }
                    RowsCount = dt.Rows.Count;
                if (RowsCount > 20)
                    RowsCount = 20;
                for (int i = RowsCount-1; i>=0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();
                        
                        
                        if (i < dt.Rows.Count - 1)
                            ItemsNum += "," + daynum ;
                        else
                            ItemsNum += daynum;
                    }
                    if (dt.Rows[i]["Dates"].ToString() != null)
                    {
                        string day = dt.Rows[i]["Dates"].ToString();
                        if (i < dt.Rows.Count - 1)
                            RowsDay += "," +day.Replace("-", "");
                        else
                            RowsDay +=  day.Replace("-", "")  ;
                    }
                }
            }

        }


        private void getItemsTriCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Items", colums, " IsTrial = 'True' ");
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["total"].ToString() != null)
                    {
                        ItemsTriCount += Convert.ToInt32(dt.Rows[j]["total"].ToString());
                    }
                }
                for (int i = RowsCount - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();
                        
                        if (i < dt.Rows.Count - 1)
                            ItemsTriNum += "," + daynum;
                        else
                            ItemsTriNum += daynum ;
                    }
                   
                }
                ItemsCommCount -= ItemsTriCount;
            }

        }

        private void getItemsSecCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Items", colums, " IsSeckill = 'True' ");
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["total"].ToString() != null)
                    {
                        ItemsSecCount += Convert.ToInt32(dt.Rows[j]["total"].ToString());
                    }
                }
                for (int i = RowsCount - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();
                        
                        if (i < dt.Rows.Count - 1)
                            ItemsSecNum += "," + daynum;
                        else
                            ItemsSecNum += daynum;
                    }
                   
                }
                ItemsCommCount -= ItemsSecCount;
            }

        }
    }
}