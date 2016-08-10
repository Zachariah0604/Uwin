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

namespace Uwin.admin.Merchant
{
    public partial class MerchantManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;
        string condition = " Merchant.AffliStation = uwinStation.staid  order by Merchant.MerchantID desc";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MerchantList();
            }
        }


        protected void MerchantList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.JoinPageIndex("Merchant left join uwinStation", "*", condition);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, MerchantRepeter, pagesize);
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MerchantRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)MerchantRepeter.Items[i].FindControl("MerchantCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)MerchantRepeter.Items[i].FindControl("MerchantID");

                    sqlcmd.CommonDeleteColumns("dbo.Merchant", "where MerchantID= " + lb.Text);


                }
            }
            MerchantList();
        }

        protected void StateBtn_Command(object sender, CommandEventArgs e)
        {
            string StateCondi = e.CommandName.ToString().Trim();
            string MerchantState = e.CommandArgument.ToString().Trim();
            string NowState = "";
            if ("1" == StateCondi)
                NowState = "0";
            else
                NowState = "1";


            int result = sqlcmd.CommonUpdate(" Merchant ", " MerchantState = " + NowState, " MerchantID = " + MerchantState);
            if (result != 0)
            {
                if ("1" == StateCondi)
                {
                    Response.Write("<script>alert('成功禁用一个商户')</script>");
                    MerchantList();
                }
                else
                {
                    Response.Write("<script>alert('重新启用一个商户成功')</script>");
                    MerchantList();
                }
            }
            else
            {

                Response.Write("<script>alert('发生错误')</script>");
                MerchantList();

            }
        }


        protected void MerchantState_SelectedIndexChanged(object sender, EventArgs e)
        {
            condition = " Merchant.AffliStation = uwinStation.staid where Merchant.MerchantState =" + this.MerchantState.SelectedValue.ToString();
            MerchantList();
        }
    }
}