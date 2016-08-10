using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;
using Model;
using System.Data;

namespace Uwin.admin.Items
{
    public partial class EditItems : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        Item ItemBll = new Item();
        ModelItems mItems = new ModelItems();
        ModelItemsTrial mItemTri = new ModelItemsTrial();
        ModelItemsSeckill mItemSec = new ModelItemsSeckill();
        public static int ParTypeIDs = 1;
        public static int AffliStations = 1;
        static string ItemsID;

        static string RefileName = "";
        static string path1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindAffliStation();
                BindAffliBrand();
                BindAffliParType();
                BindAffliSubType();
                BindAffliMerchant();
                if (Request.QueryString["itemsID"] == null || Request.QueryString["itemsID"].ToString().Length == 0)
                {
                    Response.Redirect("ItemsManage.aspx");
                }
                else
                {
                    ItemsID = Request.QueryString["itemsID"].ToString();
                    DataTable dt = sqlcmd.getCommonData("Items", "*", "itemsID=" + ItemsID);
                    
                    if (dt.Rows.Count > 0)
                    {
                        mItems.itemsID = Convert.ToInt32(ItemsID);
                        mItems.itemName = dt.Rows[0]["itemName"].ToString();
                        mItems.itemDescri = dt.Rows[0]["itemDescri"].ToString();
                       // mItems.itemMarketPrice=dt.Rows[0].["itemMarketPrice"].ToString();
                        mItems.itemMarketPrice=dt.Rows[0]["itemMarketPrice"].ToString();
                        mItems.itemCost=dt.Rows[0]["itemCost"].ToString();
                        mItems.itemSalePrice=dt.Rows[0]["itemSalePrice"].ToString();
                        mItems.itemAffiliStation=dt.Rows[0]["itemAffiliStation"].ToString();
                        mItems.itemAffiliMerchant=dt.Rows[0]["itemAffiliMerchant"].ToString();
                        mItems.itemAffiliBrand=dt.Rows[0]["itemAffiliBrand"].ToString();
                        mItems.itemAffiliParType=dt.Rows[0]["itemAffiliParType"].ToString();
                        mItems.itemAffiliSubType=dt.Rows[0]["itemAffiliSubType"].ToString();
                        mItems.itemStock=dt.Rows[0]["itemStock"].ToString();
                        mItems.itemSaleNum=dt.Rows[0]["itemSaleNum"].ToString();
                        mItems.itemState=dt.Rows[0]["itemState"].ToString();
                       mItems.itemThumbnail=dt.Rows[0]["itemThumbnail"].ToString();
                        mItems.itemContent=dt.Rows[0]["itemContent"].ToString();

                        this.ItemThumbnailShow.ImageUrl = "../../FileUpload/Images/ItemsThumb/" + mItems.itemThumbnail;
                        RefileName = mItems.itemThumbnail;

                        if(dt.Rows[0]["IsTrial"].ToString()=="True")
                        {
                            bool IsTrial = Convert.ToBoolean(dt.Rows[0]["IsTrial"]);
                            mItemTri.IsTrial = IsTrial;
                            mItemTri.itemTriPrice=dt.Rows[0]["itemTriPrice"].ToString();
                            mItemTri.itemTriOnlStock=dt.Rows[0]["itemTriOnlStock"].ToString();
                            mItemTri.itemTriVideoStock=dt.Rows[0]["itemTriVideoStock"].ToString();
                            mItemTri.itemTriApply=dt.Rows[0]["itemTriApply"].ToString();
                            mItemTri.itemTriAgree=dt.Rows[0]["itemTriAgree"].ToString();
                            mItemTri.itemTriStime=dt.Rows[0]["itemTriStime"].ToString();
                            mItemTri.itemTriEtime=dt.Rows[0]["itemTriEtime"].ToString();
                            mItemTri.itemTriState=dt.Rows[0]["itemTriState"].ToString();
                           
                        }
                        else
                        {
                            this.itemTriPrice.Enabled = false;
                            this.itemTriOnlStock.Enabled = false;
                            this.itemTriVideoStock.Enabled = false;
                            this.itemTriApply.Enabled = false;
                            this.itemTriAgree.Enabled = false;
                            this.itemTriStime.Enabled = false;
                            this.itemTriEtime.Enabled = false;
                            this.itemTriState.Enabled = false;

                            this.itemTriPriceValidator.Enabled = false;
                            this.itemTriOnlStockValidator.Enabled = false;
                            this.itemTriVideoStockValidator.Enabled = false;
                            this.itemTriApplyValidator.Enabled = false;
                            this.itemTriAgreeValidator.Enabled = false;
                            this.itemTriStimeValidator.Enabled = false;
                            this.itemTriEtimeValidator.Enabled = false;
                        }
                        if (dt.Rows[0]["IsSeckill"].ToString() == "True")
                        {
                            bool IsSeckill = Convert.ToBoolean(dt.Rows[0]["IsSeckill"]);
                            mItemSec.IsSeckill = IsSeckill;
                            mItemSec.itemSecPrice=dt.Rows[0]["itemSecPrice"].ToString();
                            mItemSec.itemSecStock=dt.Rows[0]["itemSecStock"].ToString();
                            mItemSec.itemSecSaleNum=dt.Rows[0]["itemSecSaleNum"].ToString();
                            mItemSec.itemSecState=dt.Rows[0]["itemSecState"].ToString();
                            mItemSec.itemSecTime=dt.Rows[0]["itemSecTime"].ToString();
                           
                           
                        }
                        else
                        {
                            this.itemSecPrice.Enabled = false;
                            this.itemSecStock.Enabled = false;
                            this.itemSecSaleNum.Enabled = false;
                            this.itemSecTime.Enabled = false;
                            this.itemSecState.Enabled = false;

                            this.itemSecPriceValidator.Enabled = false;
                            this.itemSecStockValidator.Enabled = false;
                            this.itemSecSaleNumValidator.Enabled = false;
                            this.itemSecTimeValidator.Enabled = false;
                        }
                        EditItemsDataBind();
                    }
                }
            }
        }

        protected void BindAffliStation()
        {
            this.AffliStation.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
            this.AffliStation.DataTextField = "station";
            this.AffliStation.DataValueField = "staid";
            this.AffliStation.DataBind();
        }
        protected void BindAffliBrand()
        {
            this.AffliBrand.DataSource = sqlcmd.getCommonData("ItemBrand", "*", null);
            this.AffliBrand.DataTextField = "BrandName";
            this.AffliBrand.DataValueField = "BrandID";
            this.AffliBrand.DataBind();
        }
        protected void BindAffliParType()
        {
            this.AffliParType.DataSource = sqlcmd.getCommonData("ItemsParType", "*", null);
            this.AffliParType.DataTextField = "pTypeName";
            this.AffliParType.DataValueField = "ParTypeID";
            this.AffliParType.DataBind();
        }
        protected void BindAffliSubType()
        {
            this.AffliSubType.DataSource = sqlcmd.getCommonData("ItmesSubType", "*", null);
            this.AffliSubType.DataTextField = "sTypeName";
            this.AffliSubType.DataValueField = "SubTypeID";
            this.AffliSubType.DataBind();
        }
        protected void BindAffliMerchant()
        {
            this.AffliMerchant.DataSource = sqlcmd.getCommonData("Merchant", "*", null);
            this.AffliMerchant.DataTextField = "MerchantName";
            this.AffliMerchant.DataValueField = "MerchantID";
            this.AffliMerchant.DataBind();
        }
        public void EditItemsDataBind()
        {
            this.itemName.Text = mItems.itemName;
            this.itemDescri.Text = mItems.itemDescri;
            this.itemMarketPrice.Text = mItems.itemMarketPrice;
            this.itemCost.Text = mItems.itemCost;
            this.itemSalePrice.Text = mItems.itemSalePrice;
            this.AffliStation.SelectedValue = mItems.itemAffiliStation.ToString();
            this.AffliMerchant.SelectedValue = mItems.itemAffiliMerchant.ToString();
            this.AffliBrand.SelectedValue = mItems.itemAffiliBrand.ToString();
            this.AffliParType.SelectedValue = mItems.itemAffiliParType.ToString();
            this.AffliSubType.SelectedValue = mItems.itemAffiliSubType.ToString();
            this.itemStcok.Text = mItems.itemStock;
            this.itemSaleNum.Text = mItems.itemSaleNum;
            this.itemContent.Text = mItems.itemContent;
            if (mItemTri.IsTrial == true)
            {
                this.IsTrial.SelectedValue = "true";
                this.itemTriPrice.Text = mItemTri.itemTriPrice;
                this.itemTriOnlStock.Text = mItemTri.itemTriOnlStock;
                this.itemTriVideoStock.Text = mItemTri.itemTriVideoStock;
                this.itemTriApply.Text = mItemTri.itemTriApply;
                this.itemTriAgree.Text = mItemTri.itemTriAgree;
                this.itemTriStime.Text = mItemTri.itemTriStime;
                this.itemTriEtime.Text = mItemTri.itemTriEtime;
                this.itemTriState.SelectedValue = mItemTri.itemTriState.ToString();
            }
            if (mItemSec.IsSeckill == true)
            {
                this.IsSeckill.SelectedValue = "true";
                this.itemSecPrice.Text = mItemSec.itemSecPrice;
                this.itemSecStock.Text = mItemSec.itemSecStock;
                this.itemSecSaleNum.Text = mItemSec.itemSecSaleNum;
                this.itemSecTime.Text = mItemSec.itemSecTime;
                this.itemSecState.SelectedValue = mItemSec.itemSecState.ToString();
               
            }


        }
        protected void BtnUpLoad_Click(object sender, EventArgs e)
        {
            UploadItemThumbnail();
            Response.Write("<script>alert('上传成功!');</script>");
        }
        
        private void UploadItemThumbnail()
        {
            string filename = this.ItemThumbnail.FileName;
            string targetpath = Server.MapPath("../../FileUpload/Images/ItemsThumb/");
            string filepath = targetpath + this.ItemThumbnail.FileName;
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            ItemThumbnail.SaveAs(Server.MapPath("../../FileUpload/Images/ItemsThumb/") + this.ItemThumbnail.FileName);
            RefileName = this.ItemThumbnail.FileName;
           // path1 = filepath;


           // string path2 = Server.MapPath("../../FileUpload/Images/ItemsThumb/");
           // RefileName = "Thumb_" + this.ItemThumbnail.FileName;
           // UploadImage.MakeThumbnail(path1, path2 + RefileName, 100, 100, "Hw");

        }

        protected void AffliParType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParTypeIDs = Convert.ToInt32(this.AffliParType.SelectedValue.ToString());
            this.AffliSubType.DataSource = sqlcmd.getCommonData("ItmesSubType", "*", " ParentID = " + ParTypeIDs);
            this.AffliSubType.DataTextField = "sTypeName";
            this.AffliSubType.DataValueField = "SubTypeID";
            this.AffliSubType.DataBind();
        }

        protected void AffliStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            AffliStations = Convert.ToInt32(this.AffliStation.SelectedValue.ToString());
            this.AffliMerchant.DataSource = sqlcmd.getCommonData("Merchant", "*", " AffliStation = " + AffliStations);
            this.AffliMerchant.DataTextField = "MerchantName";
            this.AffliMerchant.DataValueField = "MerchantID";
            this.AffliMerchant.DataBind();
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
           
                int result = 0;
                ModelItems item = new ModelItems();
                {
                    item.itemsID = Convert.ToInt32(ItemsID);
                    item.itemName = this.itemName.Text;
                    item.itemDescri = this.itemDescri.Text;
                    item.itemMarketPrice = this.itemMarketPrice.Text;
                    item.itemCost = this.itemCost.Text;
                    item.itemSalePrice = this.itemSalePrice.Text;
                    item.itemSaleNum = this.itemSalePrice.Text;
                    item.itemAffiliStation = this.AffliStation.SelectedValue.ToString();
                    item.itemAffiliMerchant = this.AffliMerchant.SelectedValue.ToString();
                    item.itemAffiliBrand = this.AffliBrand.SelectedValue.ToString();
                    item.itemAffiliParType = this.AffliParType.SelectedValue.ToString();
                    item.itemAffiliSubType = this.AffliSubType.SelectedValue.ToString();
                    item.itemStock = this.itemStcok.Text;
                    item.itemSaleNum = this.itemSaleNum.Text;
                    item.itemState = this.itemState.SelectedValue.ToString();
                    item.itemThumbnail = RefileName;
                    item.itemContent = "'" + this.itemContent.Text + "'";
                    result = ItemBll.UpdateItems(item);
                }
                bool IsTrial = Convert.ToBoolean(this.IsTrial.SelectedValue.ToString());
                if (IsTrial == true)
                {
                    ModelItemsTrial itemTrial = new ModelItemsTrial();
                    {
                        itemTrial.itemsID = Convert.ToInt32(ItemsID);
                        itemTrial.IsTrial = IsTrial;
                        itemTrial.itemTriPrice = itemTriPrice.Text;
                        itemTrial.itemTriOnlStock = itemTriOnlStock.Text;
                        itemTrial.itemTriVideoStock = itemTriVideoStock.Text;
                        itemTrial.itemTriApply = itemTriApply.Text;
                        itemTrial.itemTriAgree = itemTriAgree.Text;
                        itemTrial.itemTriStime = itemTriStime.Text;
                        itemTrial.itemTriEtime = itemTriEtime.Text;
                        itemTrial.itemTriState = this.itemTriState.SelectedValue.ToString();
                        result = ItemBll.AddWithUpdateTrialItems(itemTrial);
                    }


                }
                bool IsSeckill = Convert.ToBoolean(this.IsSeckill.SelectedValue.ToString());
                if (IsSeckill == true)
                {
                    ModelItemsSeckill itemSeckill = new ModelItemsSeckill();
                    {
                        itemSeckill.itemsID = Convert.ToInt32(ItemsID);
                        itemSeckill.IsSeckill = IsSeckill;
                        itemSeckill.itemSecPrice = itemSecPrice.Text;
                        itemSeckill.itemSecStock = itemSecStock.Text;
                        itemSeckill.itemSecSaleNum = itemSecSaleNum.Text;
                        itemSeckill.itemSecState = this.itemSecState.SelectedValue.ToString();
                        itemSeckill.itemSecTime = itemSecTime.Text;
                        result = ItemBll.AddWithUpdateSeckillItems(itemSeckill);
                    }

                }

                if (result != 0)
                {
                    Response.Write("<script>alert('修改成功!');menuFrame.location.href ='ItemsManage.aspx';</script>");
                }
            
        }

        protected void IsTrial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.IsTrial.SelectedValue.ToString()) == true)
            {
                this.itemTriPrice.Enabled = true;
                this.itemTriOnlStock.Enabled = true;
                this.itemTriVideoStock.Enabled = true;
                this.itemTriApply.Enabled = true;
                this.itemTriAgree.Enabled = true;
                this.itemTriStime.Enabled = true;
                this.itemTriEtime.Enabled = true;
                this.itemTriState.Enabled = true;

                this.itemTriPriceValidator.Enabled = true;
                this.itemTriOnlStockValidator.Enabled = true;
                this.itemTriVideoStockValidator.Enabled = true;
                this.itemTriApplyValidator.Enabled = true;
                this.itemTriAgreeValidator.Enabled = true;
                this.itemTriStimeValidator.Enabled = true;
                this.itemTriEtimeValidator.Enabled = true;
            }
            else
            {
                this.itemTriPrice.Enabled = false;
                this.itemTriOnlStock.Enabled = false;
                this.itemTriVideoStock.Enabled = false;
                this.itemTriApply.Enabled = false;
                this.itemTriAgree.Enabled = false;
                this.itemTriStime.Enabled = false;
                this.itemTriEtime.Enabled = false;
                this.itemTriState.Enabled = false;

                this.itemTriPriceValidator.Enabled = false;
                this.itemTriOnlStockValidator.Enabled = false;
                this.itemTriVideoStockValidator.Enabled = false;
                this.itemTriApplyValidator.Enabled = false;
                this.itemTriAgreeValidator.Enabled = false;
                this.itemTriStimeValidator.Enabled = false;
                this.itemTriEtimeValidator.Enabled = false;
            }
        }
        protected void IsSeckill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(this.IsSeckill.SelectedValue.ToString()) == true)
            {
                this.itemSecPrice.Enabled = true;
                this.itemSecStock.Enabled = true;
                this.itemSecSaleNum.Enabled = true;
                this.itemSecTime.Enabled = true;
                this.itemSecState.Enabled = true;

                this.itemSecPriceValidator.Enabled = true;
                this.itemSecStockValidator.Enabled = true;
                this.itemSecSaleNumValidator.Enabled = true;
                this.itemSecTimeValidator.Enabled = true;
            }
            else
            {
                this.itemSecPrice.Enabled = false;
                this.itemSecStock.Enabled = false;
                this.itemSecSaleNum.Enabled = false;
                this.itemSecTime.Enabled = false;
                this.itemSecState.Enabled = false;

                this.itemSecPriceValidator.Enabled = false;
                this.itemSecStockValidator.Enabled = false;
                this.itemSecSaleNumValidator.Enabled = false;
                this.itemSecTimeValidator.Enabled = false;
            }
        }
    }
}