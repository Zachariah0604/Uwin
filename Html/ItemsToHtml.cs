using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Html
{
    public class ItemsToHtml
    {
        public static void MakeItemList()
        {
            Sqlcmd sqlcd = new Sqlcmd();
            string ModelPath = "Model\\PC\\Items\\ItemsList.html";

            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            string savePath = "Items\\";
            string PageListLink = null;
            DataTable parType = sqlcd.getCommonData("ItemsParType", "*", " 1=1");
            if (parType.Rows.Count > 0)
            {
                for(int pType=0;pType<parType.Rows.Count;pType++)
                {
                    
                    string tempcontent = Html.DirFile.ReadFile(ModelPath);
                    tempcontent = tempcontent.Replace("{$header$}", Headercontent);
                    string ParTypeID=parType.Rows[pType]["ParTypeID"].ToString();
                    string pTypeLink = parType.Rows[pType]["pTypeLink"].ToString();
                    string parTypeName = parType.Rows[pType]["pTypeName"].ToString();
                    string Positions = "当前位置：<a href='../index.shtml' target='_blank' style='color:#000'>首页</a>>>产品列表>><a href='" + pTypeLink + "' style='color:#000' target='_top'>" + parTypeName + "</a>";
                    PageListLink = "items_" + ParTypeID + ".html";
                    tempcontent = tempcontent.Replace("{$Positions}", Positions);
                    tempcontent = tempcontent.Replace("{$parTypeName}", parTypeName);
                    string itemslist = null;
                    DataTable dt = sqlcd.getCommonData("Items", " * ", " itemAffiliParType = " + ParTypeID+" order by itemsID desc");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                           
                           

                            string itemThumbnail=dt.Rows[i]["itemThumbnail"].ToString();
                            string itemLink=dt.Rows[i]["itemLink"].ToString();
                            string itemName=dt.Rows[i]["itemName"].ToString();
                            string itemDescri=dt.Rows[i]["itemDescri"].ToString();
                            string itemSalePrice=dt.Rows[i]["itemSalePrice"].ToString();

                            string itemAffiliBrand = dt.Rows[i]["itemAffiliBrand"].ToString();
                            string AffiliBrandName = null;
                            DataTable AffiliBrand = sqlcd.getCommonData("ItemBrand", "*", " BrandID=" + itemAffiliBrand);
                            if (AffiliBrand.Rows.Count > 0)
                            {
                                AffiliBrandName = AffiliBrand.Rows[0]["BrandName"].ToString();
                            }

                            string itemAffiliSubType = dt.Rows[i]["itemAffiliBrand"].ToString();
                            string AffiliSubTypeName = null;
                            DataTable AffiliSubType = sqlcd.getCommonData("ItmesSubType", "*", " SubTypeID=" + itemAffiliSubType);
                            if (AffiliSubType.Rows.Count > 0)
                            {
                                AffiliSubTypeName = AffiliSubType.Rows[0]["sTypeName"].ToString();
                            }
                            
                            if (dt.Rows[i]["IsTrial"].ToString() != null && dt.Rows[i]["IsTrial"].ToString().Length!=0)
                            {
                                bool IsTrial = bool.Parse(dt.Rows[i]["IsTrial"].ToString());
                               
                                if (IsTrial == true)
                                {
                                    string itemTriPrice = dt.Rows[i]["itemTriPrice"].ToString();
                                    string itemTriEtime = dt.Rows[i]["itemTriEtime"].ToString();
                                    string itemTriOnlStock = dt.Rows[i]["itemTriOnlStock"].ToString();
                                    itemslist += "<article class=\"white-panel\"><a href='" + itemLink + "' target='_blank'><img src='../FileUpload/Images/ItemsThumb/" + itemThumbnail + "' class=\"thumb\"></a><div style=\"width:100%;height:10px;\"></div><h1 style=\"background-image:url(../images/uiys.png); height:50px; background-repeat:no-repeat; background-position:right;\"><a href='" + itemLink + "' target='_blank' style=\"line-height:10px;\"><strong><br/>" + itemName + "</strong></a></h1><p><br/>" + itemDescri + "</p><div style=\"width:100%;height:10px; border-bottom:1px dotted #777\"></div><p style=\" text-align:right;\"><br/>试用押金：" + itemTriPrice + "元</p><p style=\" text-align:right;\"><br/>结束时间：" + itemTriEtime + "</p><p style=\" text-align:right;\"><br/>剩余<span style=\"color:red\">" + itemTriOnlStock + "</span>件</p><div style=\"text-align:right;color:#777;\"><br/>" + AffiliBrandName + "&nbsp;&nbsp;&nbsp;" + AffiliSubTypeName + "</div></article>";
                                }
                            }
                            else if (dt.Rows[i]["IsSeckill"].ToString() != null && dt.Rows[i]["IsSeckill"].ToString().Length!=0)
                            {
                                bool IsSeckill = bool.Parse(dt.Rows[i]["IsSeckill"].ToString());
                                if (IsSeckill == true)
                                {
                                    string itemSecPrice = dt.Rows[i]["itemSecPrice"].ToString();
                                    string itemSecStock = dt.Rows[i]["itemSecStock"].ToString();
                                    itemslist += "<article class=\"white-panel\"><a href='" + itemLink + "' target='_blank'><img src='../FileUpload/Images/ItemsThumb/" + itemThumbnail + "' class=\"thumb\"></a><div style=\"width:100%;height:10px;\"></div><h1 style=\"background-image:url(../images/miaosha.png); height:50px; background-repeat:no-repeat; background-position:right;\"><a href='" + itemLink + "' target='_blank' style=\"line-height:10px;\"><strong><br/>" + itemName + "</strong></a></h1><p><br/>" + itemDescri + "</p><div style=\"width:100%;height:10px; border-bottom:1px dotted #777\"></div><p style=\" text-align:right;\"><br/>秒杀价：" + itemSecPrice + "元</p><p style=\" text-align:right;\"><br/>剩余<span style=\"color:red\">" + itemSecStock + "</span>件</p><div style=\"text-align:right;color:#777;\"><br/>" + AffiliBrandName + "&nbsp;&nbsp;&nbsp;" + AffiliSubTypeName + "</div></article>";
                                }
                            }
                            else
                            {
                                itemslist += "<article class=\"white-panel\"><a href='" + itemLink + "' target='_blank'><img src='../FileUpload/Images/ItemsThumb/" + itemThumbnail + "' class=\"thumb\"></a><h1><a href='" + itemLink + "' target='_blank'><strong><br/>" + itemName + "</strong></a></h1><p><br/>" + itemDescri + "</p><div style=\"width:100%;height:10px; border-bottom:1px dotted #777\"></div><p style=\" text-align:right;\"><br/>销售价：" + itemSalePrice + "元</p><div style=\"text-align:right;color:#777;\"><br/>" + AffiliBrandName + "&nbsp;&nbsp;&nbsp;" + AffiliSubTypeName + "</div></article>";
                            }
                            
                        }

                        tempcontent = tempcontent.Replace("{$itemslist}", itemslist);

                        tempcontent = tempcontent.Replace("{$ColumnTitle}", "产品中心-");
                        tempcontent = tempcontent.Replace("{$DetailTitle}", "");
                        tempcontent = tempcontent.Replace("{$TypeNameTitle}", parTypeName + "-");
                        tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
                        itemslist = null;
                        Html.DirFile.CreateFile(savePath + PageListLink, tempcontent);

                    }
                }
            }
        }
        public static void MakeTriItemList()
        {
            Sqlcmd sqlcd = new Sqlcmd();
            string ModelPath = "Model\\PC\\Items\\ItemsList.html";

            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            string savePath = "Items\\";
            string Pagelink = "TrialItems.html";
            string itemslist = "";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);
           
            string Positions = "当前位置：<a href='../index.shtml' target='_blank' style='color:#000'>首页</a>>>产品列表>><a href=\"../Items/TrialItems.html\" style='color:#000' target='_top'>试用商品</a>";
           
            tempcontent = tempcontent.Replace("{$Positions}", Positions);
            tempcontent = tempcontent.Replace("{$parTypeName}", "试用商品");
            DataTable dt = sqlcd.getCommonData(" Items ", " * ", " IsTrial=1 order by itemsID desc");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string itemLink = dt.Rows[i]["itemLink"].ToString();
                    string itemThumbnail = dt.Rows[i]["itemThumbnail"].ToString();
                    string itemAffiliBrand = dt.Rows[i]["itemAffiliBrand"].ToString();
                    string itemName = dt.Rows[i]["itemName"].ToString();
                    string itemDescri = dt.Rows[i]["itemDescri"].ToString();
                    string AffiliBrandName = null;
                    DataTable AffiliBrand = sqlcd.getCommonData("ItemBrand", "*", " BrandID=" + itemAffiliBrand);
                    if (AffiliBrand.Rows.Count > 0)
                    {
                        AffiliBrandName = AffiliBrand.Rows[0]["BrandName"].ToString();
                    }

                    string itemAffiliSubType = dt.Rows[i]["itemAffiliBrand"].ToString();
                    string AffiliSubTypeName = null;
                    DataTable AffiliSubType = sqlcd.getCommonData("ItmesSubType", "*", " SubTypeID=" + itemAffiliSubType);
                    if (AffiliSubType.Rows.Count > 0)
                    {
                        AffiliSubTypeName = AffiliSubType.Rows[0]["sTypeName"].ToString();
                    }
 
                    string itemTriPrice = dt.Rows[i]["itemTriPrice"].ToString();
                    string itemTriEtime = dt.Rows[i]["itemTriEtime"].ToString();
                    string itemTriOnlStock = dt.Rows[i]["itemTriOnlStock"].ToString();
                    itemslist += "<article class=\"white-panel\"><a href='" + itemLink + "' target='_blank'><img src='../FileUpload/Images/ItemsThumb/" + itemThumbnail + "' class=\"thumb\"></a><div style=\"width:100%;height:10px;\"></div><h1 style=\"background-image:url(../images/uiys.png); height:50px; background-repeat:no-repeat; background-position:right;\"><a href='" + itemLink + "' target='_blank' style=\"line-height:10px;\"><strong><br/>" + itemName + "</strong></a></h1><p><br/>" + itemDescri + "</p><div style=\"width:100%;height:10px; border-bottom:1px dotted #777\"></div><p style=\" text-align:right;\"><br/>试用押金：" + itemTriPrice + "元</p><p style=\" text-align:right;\"><br/>结束时间：" + itemTriEtime + "</p><p style=\" text-align:right;\"><br/>剩余<span style=\"color:red\">" + itemTriOnlStock + "</span>件</p><div style=\"text-align:right;color:#777;\"><br/>" + AffiliBrandName + "&nbsp;&nbsp;&nbsp;" + AffiliSubTypeName + "</div></article>";
                    
                }
                tempcontent = tempcontent.Replace("{$itemslist}", itemslist);

                tempcontent = tempcontent.Replace("{$ColumnTitle}", "产品中心-");
                tempcontent = tempcontent.Replace("{$DetailTitle}", "");
                tempcontent = tempcontent.Replace("{$TypeNameTitle}",  "试用商品-");
                tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
                itemslist = null;
                Html.DirFile.CreateFile(savePath + Pagelink, tempcontent);
            }
        }

        public static void MakeSecItemList()
        {
            Sqlcmd sqlcd = new Sqlcmd();
            string ModelPath = "Model\\PC\\Items\\ItemsList.html";

            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            string savePath = "Items\\";
            string Pagelink = "SecItems.html";
            string itemslist = "";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);

            string Positions = "当前位置：<a href='../index.shtml' target='_blank' style='color:#000'>首页</a>>>产品列表>><a href=\"../Items/SecItems.html\" style='color:#000' target='_top'>秒杀商品</a>";

            tempcontent = tempcontent.Replace("{$Positions}", Positions);
            tempcontent = tempcontent.Replace("{$parTypeName}", "秒杀商品");
            DataTable dt = sqlcd.getCommonData(" Items ", " * ", " IsSeckill=1 order by itemsID desc");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string itemLink = dt.Rows[i]["itemLink"].ToString();
                    string itemThumbnail = dt.Rows[i]["itemThumbnail"].ToString();
                    string itemAffiliBrand = dt.Rows[i]["itemAffiliBrand"].ToString();
                    string itemName = dt.Rows[i]["itemName"].ToString();
                    string itemDescri = dt.Rows[i]["itemDescri"].ToString();
                    string AffiliBrandName = null;
                    DataTable AffiliBrand = sqlcd.getCommonData("ItemBrand", "*", " BrandID=" + itemAffiliBrand);
                    if (AffiliBrand.Rows.Count > 0)
                    {
                        AffiliBrandName = AffiliBrand.Rows[0]["BrandName"].ToString();
                    }

                    string itemAffiliSubType = dt.Rows[i]["itemAffiliBrand"].ToString();
                    string AffiliSubTypeName = null;
                    DataTable AffiliSubType = sqlcd.getCommonData("ItmesSubType", "*", " SubTypeID=" + itemAffiliSubType);
                    if (AffiliSubType.Rows.Count > 0)
                    {
                        AffiliSubTypeName = AffiliSubType.Rows[0]["sTypeName"].ToString();
                    }

                    string itemSecPrice = dt.Rows[i]["itemSecPrice"].ToString();
                    string itemSecStock = dt.Rows[i]["itemSecStock"].ToString();
                    itemslist += "<article class=\"white-panel\"><a href='" + itemLink + "' target='_blank'><img src='../FileUpload/Images/ItemsThumb/" + itemThumbnail + "' class=\"thumb\"></a><div style=\"width:100%;height:10px;\"></div><h1 style=\"background-image:url(../images/miaosha.png); height:50px; background-repeat:no-repeat; background-position:right;\"><a href='" + itemLink + "' target='_blank' style=\"line-height:10px;\"><strong><br/>" + itemName + "</strong></a></h1><p><br/>" + itemDescri + "</p><div style=\"width:100%;height:10px; border-bottom:1px dotted #777\"></div><p style=\" text-align:right;\"><br/>秒杀价：" + itemSecPrice + "元</p><p style=\" text-align:right;\"><br/>剩余<span style=\"color:red\">" + itemSecStock + "</span>件</p><div style=\"text-align:right;color:#777;\"><br/>" + AffiliBrandName + "&nbsp;&nbsp;&nbsp;" + AffiliSubTypeName + "</div></article>";

                }
                tempcontent = tempcontent.Replace("{$itemslist}", itemslist);

                tempcontent = tempcontent.Replace("{$ColumnTitle}", "产品中心-");
                tempcontent = tempcontent.Replace("{$DetailTitle}", "");
                tempcontent = tempcontent.Replace("{$TypeNameTitle}", "秒杀商品-");
                tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
                itemslist = null;
                Html.DirFile.CreateFile(savePath + Pagelink, tempcontent);
            }
        }

        public static string MakeItemsDatilByItemsID(int ItemsID)
        {
            Sqlcmd sqlcmd=new Sqlcmd();
            string ModelPath = "Model\\PC\\Items\\Detail.html";
            string tempcontent = Html.DirFile.ReadFile(ModelPath);
            string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
            string Footercontent = Html.DirFile.ReadFile("Footer.html");
            
            string savePath = "Items\\"; ;
            BLL.Item ItemBll = new BLL.Item();

            Model.ModelItems mItems = new Model.ModelItems();
            mItems = ItemBll.GetItemsModel(ItemsID);
            tempcontent = tempcontent.Replace("{$header$}", Headercontent);

            tempcontent = tempcontent.Replace("{$ItemsTitle}", mItems.itemName);
            tempcontent = tempcontent.Replace("{$itemThumbnail}", mItems.itemThumbnail);
            DataTable parType = sqlcmd.getCommonData(" ItemsParType ", " * ", " ParTypeID = "+mItems.itemAffiliParType);
            string parTypelink = null;
            string parTypeName = null;
            string ParTypeID = "";
            if (parType.Rows.Count > 0)
            {
                ParTypeID = parType.Rows[0]["ParTypeID"].ToString();
                parTypeName = parType.Rows[0]["pTypeName"].ToString();
                parTypelink = parType.Rows[0]["pTypeLink"].ToString();
            }
            string htmlfilename = "Items_" + ParTypeID + "_" + Guid.NewGuid().ToString().Replace("-", "_") + ".html";
            tempcontent = tempcontent.Replace("{$parTypeName}", parTypeName);
            tempcontent = tempcontent.Replace("{$parTypelink}", parTypelink);
            string itemDescri = null;
            if (mItems.itemDescri!=""&&mItems.itemDescri!=null&&mItems.itemDescri.Length > 80)
            {
                itemDescri = mItems.itemDescri.ToString().Substring(0, 80)+"...";
            }
            tempcontent = tempcontent.Replace("{$itemDescri}", itemDescri);
            DataTable itemBrand = sqlcmd.getCommonData(" ItemBrand ", " * ", " BrandID = " + mItems.itemAffiliBrand);
            string itemBrandName = null;
            if (itemBrand.Rows.Count > 0)
            {
                itemBrandName = itemBrand.Rows[0]["BrandName"].ToString();
            }

            string itemsPrices = null;
            string itemsStock = null;
            Model.ModelItemsTrial mTriItems = new Model.ModelItemsTrial();
            mTriItems = ItemBll.GetItemsTriModel(ItemsID);
            Model.ModelItemsSeckill mSecItems = new Model.ModelItemsSeckill();
            mSecItems = ItemBll.GetItemsSecModel(ItemsID);
            if (mTriItems.IsTrial.ToString() != "" && mTriItems.IsTrial==true)
            {
                itemsPrices = "试用押金:<i style=\"color:red\">￥" + mTriItems.itemTriPrice.ToString() + "</i>";
                itemsStock = mTriItems.itemTriOnlStock.ToString() + "件";
            }
            else if (mSecItems.IsSeckill.ToString() != "" && mSecItems.IsSeckill == true)
            {
                itemsPrices = "秒杀价:<i style=\"color:red\">￥" + mSecItems.itemSecPrice + "</i>";
                itemsStock = mSecItems.itemSecStock.ToString() + "件";
            }
            else
            {
                itemsPrices = "市场价:<i style=\"color:red\">￥" + mItems.itemSalePrice.ToString() + "</i>";
                itemsStock = mItems.itemStock.ToString() + "件";
            }

            tempcontent = tempcontent.Replace("{$itemsPrices}", itemsPrices);
            tempcontent = tempcontent.Replace("{$itemsStock}", itemsStock);
            tempcontent = tempcontent.Replace("{$DetailTitle}", mItems.itemName + "-");

            tempcontent = tempcontent.Replace("{$ColumnTitle}", "产品中心-");
            tempcontent = tempcontent.Replace("{$TypeNameTitle}", parTypeName + "-");
            tempcontent = tempcontent.Replace("{$itemBrandName}", itemBrandName);
            tempcontent = tempcontent.Replace("{$itemContent}", mItems.itemContent);
            tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);

            Html.DirFile.CreateFile(savePath + htmlfilename, tempcontent);

            return htmlfilename;
        }
    }
}
