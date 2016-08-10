using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Html;


namespace Uwin.admin.Items
{
    public partial class ItemsManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        int pagesize = 9;
        string condi = "1=1 order by itemsID desc";
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
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ItemsRepeter, pagesize);

            ItemsRepeter.DataBind();
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
            condi = "Items.itemAffiliStation =" + this.Station.SelectedValue.ToString();
            ItemsList();
        }

        protected void itemState_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = "Items.itemState =" + this.itemState.SelectedValue.ToString();
            ItemsList();
        }

        protected void itemBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = "Items.itemAffiliBrand =" + this.itemBrand.SelectedValue.ToString();
            ItemsList();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ItemsRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ItemsRepeter.Items[i].FindControl("ItemsCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ItemsRepeter.Items[i].FindControl("itemsID");

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


            int result= sqlcmd.CommonUpdate("Items", "itemState = " + NowState, " itemsID = " + itemsID);
            if (result != 0)
            {
                if ("1" == StateCondi)
                {
                    Response.Write("<script>alert('成功下架一键商品')</script>");
                    ItemsList();
                }
                else
                {
                    Response.Write("<script>alert('成功上架一键商品')</script>");
                    ItemsList();
                }
            }
            else 
            {
               
                Response.Write("<script>alert('发生错误')</script>");
                ItemsList();
                
            }
        }
        protected void ToHtml_Click(object sender, EventArgs e)
        {
            int htmlCount = 0;
            for (int i = 0; i < ItemsRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ItemsRepeter.Items[i].FindControl("ItemsCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ItemsRepeter.Items[i].FindControl("itemsID");
                    string itemLink = ItemsToHtml.MakeItemsDatilByItemsID(int.Parse(lb.Text));
                    htmlCount++;
                    sqlcmd.CommonUpdate(" Items ", " itemLink = " + "'" + itemLink + "'", " itemsID = " + lb.Text);
                }
            }

            Response.Write("<Script Language='JavaScript'>window.alert('成功生成" + htmlCount + "张商品详情页');</script>");
        }

        protected void AllToHtml_Click(object sender, EventArgs e)
        {
            int htmlCount = 0;
            DataTable Itmesdt = sqlcmd.getCommonData("Items", " itemsID ", " 1=1");
            if (Itmesdt.Rows.Count > 0)
            {
                for (int i = 0; i < Itmesdt.Rows.Count; i++)
                {
                    int itemsID = int.Parse(Itmesdt.Rows[i]["itemsID"].ToString());
                    string itemLink = ItemsToHtml.MakeItemsDatilByItemsID(itemsID);
                    htmlCount++;
                    sqlcmd.CommonUpdate(" Items ", " itemLink = " + "'" + itemLink + "'", " itemsID = " + itemsID);
                }
            }
            Response.Write("<Script Language='JavaScript'>window.alert('成功生成" + htmlCount + "张商品详情页');</script>");
        }

        
       
    }
}