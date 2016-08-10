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


namespace Uwin.admin.Items
{
    public partial class ItemsSecManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;
        string condi = " IsSeckill = 1 order by itemsID desc";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemsList();
                StationBind();
                ItemBrandBind();

            }
        }
        private void ItemsList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("Items", "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ItemsSecRepeter, pagesize);

            ItemsSecRepeter.DataBind();
        }
        private void StationBind()
        {
            this.Station.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
            this.Station.DataTextField = "station";
            this.Station.DataValueField = "staid";
            this.Station.DataBind();
        }

        private void ItemBrandBind()
        {
            this.itemBrand.DataSource = sqlcmd.getCommonData("ItemBrand", "*", null);
            this.itemBrand.DataTextField = "BrandName";
            this.itemBrand.DataValueField = "BrandID";
            this.itemBrand.DataBind();
        }

        protected void Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = " IsSeckill = 1 And Items.itemAffiliStation =" + this.Station.SelectedValue.ToString();
            ItemsList();
        }

        protected void itemState_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = "  IsSeckill = 1 And Items.itemSecState =" + this.itemState.SelectedValue.ToString();
            ItemsList();
        }

        protected void itemBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = "  IsSeckill = 1 And Items.itemAffiliBrand =" + this.itemBrand.SelectedValue.ToString();
            ItemsList();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ItemsSecRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ItemsSecRepeter.Items[i].FindControl("ItemsSecCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ItemsSecRepeter.Items[i].FindControl("itemsID");

                    sqlcmd.CommonDeleteColumns("dbo.Items", "where itemsID= " + lb.Text);


                }
            }
            ItemsList();
        }
        protected void StateBtn_Command(object sender, CommandEventArgs e)
        {
            string StateCondi = e.CommandName.ToString().Trim();
            string itemsID = e.CommandArgument.ToString().Trim();
            string NowState = "";
            if ("1" == StateCondi)
                NowState = "0";
            else
                NowState = "1";


            int result = sqlcmd.CommonUpdate("Items", "itemSecState = " + NowState, " itemsID = " + itemsID);
            if (result != 0)
            {
                if ("1" == StateCondi)
                {
                    Response.Write("<script>alert('成功下架一件秒杀商品')</script>");
                    ItemsList();
                }
                else
                {
                    Response.Write("<script>alert('成功上架一件秒杀商品')</script>");
                    ItemsList();
                }
            }
            else
            {

                Response.Write("<script>alert('发生错误')</script>");
                ItemsList();

            }
        }
    }
}