using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

namespace Uwin.admin.Statistics
{
    public partial class MerchantInfo : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected int RowsCount;
        protected string MerchantNum;

        protected int MerchantCount;
        protected string RowsDay;
        string colums = "AffliStation";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMerchantCount();
            }
        }

        private void getMerchantCount()
        {
            DataTable dt = sqlcmd.getCommonCountDayData("Merchant", colums, "1=1");
            this.Repeater1.DataSource = dt.DefaultView;
            this.Repeater1.DataBind();
           

        }
        public string StationName(String stationID)
        {
            DataTable sdt = sqlcmd.getCommonData("uwinStation", "*", " staid = " + stationID);
            if (sdt.Rows.Count > 0)
            {
                return sdt.Rows[0]["station"].ToString();
            }
            else
                return null;
        }




    }
}