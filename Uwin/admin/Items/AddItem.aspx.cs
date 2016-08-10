using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;
using Model;

namespace Uwin.admin.Items
{
    public partial class AddItem : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        public static int ParTypeIDs =1;
        public static int AffliStations = 1;
        Item ite = new Item();
        static string RefileName = "";
        static string path1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  
                    BindAffliStation();
                    BindAffliBrand();
                    BindAffliParType();
                   

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
       
        
        
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (RefileName == "")
            {
                Response.Write("<script>alert('没有上传图片!');</script>");
                return;
            }
            else
            {
                int result = 0;
                ModelItems item = new ModelItems();
                item.itemName = itemName.Text;
                item.itemDescri = itemDescri.Text;
                item.itemMarketPrice = itemMarketPrice.Text;
                item.itemCost = itemCost.Text;
                item.itemSalePrice = itemSalePrice.Text;
                item.itemSaleNum = itemSalePrice.Text;
                item.itemAffiliStation = this.AffliStation.SelectedValue.ToString();
                item.itemAffiliMerchant = this.AffliMerchant.SelectedValue.ToString();
                item.itemAffiliBrand = this.AffliBrand.SelectedValue.ToString();
                item.itemAffiliParType = this.AffliParType.SelectedValue.ToString();
                item.itemAffiliSubType = this.AffliSubType.SelectedValue.ToString();
                item.itemStock = itemStcok.Text;
                item.itemSaleNum = itemSaleNum.Text;
                item.itemState = this.itemState.SelectedValue.ToString();
                item.itemThumbnail = RefileName;
                item.itemContent = itemContent.Text;
                int Lastid = ite.AddItems(item);
                if (Lastid != 0)
                {
                    bool IsTrial = Convert.ToBoolean(this.IsTrial.SelectedValue.ToString());
                    if (IsTrial == true)
                    {
                        ModelItemsTrial itemTrial = new ModelItemsTrial();
                        itemTrial.itemsID = Lastid;
                        itemTrial.IsTrial = IsTrial;
                        itemTrial.itemTriPrice = itemTriPrice.Text;
                        itemTrial.itemTriOnlStock = itemTriOnlStock.Text;
                        itemTrial.itemTriVideoStock = itemTriVideoStock.Text;
                        itemTrial.itemTriApply = itemTriApply.Text;
                        itemTrial.itemTriAgree = itemTriAgree.Text;
                        itemTrial.itemTriStime = itemTriStime.Text;
                        itemTrial.itemTriEtime = itemTriEtime.Text;
                        itemTrial.itemTriState = this.itemTriState.SelectedValue.ToString();
                        result = ite.AddWithUpdateTrialItems(itemTrial);


                    }
                    bool IsSeckill = Convert.ToBoolean(this.IsSeckill.SelectedValue.ToString());
                    if (IsSeckill == true)
                    {
                        ModelItemsSeckill itemSeckill = new ModelItemsSeckill();
                        itemSeckill.itemsID = Lastid;
                        itemSeckill.IsSeckill = IsSeckill;
                        itemSeckill.itemSecPrice = itemSecPrice.Text;
                        itemSeckill.itemSecStock = itemSecStock.Text;
                        itemSeckill.itemSecSaleNum = itemSecSaleNum.Text;
                        itemSeckill.itemSecState = this.itemSecState.SelectedValue.ToString();
                        itemSeckill.itemSecTime = itemSecTime.Text;
                        result = ite.AddWithUpdateSeckillItems(itemSeckill);

                    }
                    Response.Write("<script>alert('添加成功!');menuFrame.location.href ='ItemsManage.aspx';</script>");
                }
               

                
            }

        }
        protected void BtnUpLoad_Click(object sender, EventArgs e)
        {
            UploadItemThumbnail();
            this.ItemThumbnailShow.ImageUrl = "../../FileUpload/Images/ItemsThumb/" + RefileName;
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
          //  path1 = filepath;


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