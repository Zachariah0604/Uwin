using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Uwin.admin.Statistics
{
    public partial class UserInfo : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected int RowsCount;
        protected string MemeberNum;

        protected int MemeberCount;
        protected string RowsDay;
        string colums = "substring(CONVERT(char(10),userCreatime,120),1,10)";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMemeberCount();
            }
        }

        private void getMemeberCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Memeber", colums, "1=1");
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["total"].ToString() != null)
                    {
                        MemeberCount += Convert.ToInt32(dt.Rows[j]["total"].ToString());
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
                            MemeberNum += "," + daynum;
                        else
                            MemeberNum += daynum;
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