using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace BLL
{
    public class Item
    {
        DataConnect sqldata = new DataConnect();


        public SqlCommand parType()
        {
            string sql = "select * from dbo.ItemsParType";
            SqlCommand cmd = sqldata.ExcuteSelectReturnSqlCommand(sql);
            return cmd;
        }

        public int AddItems(ModelItems model)
        {
            SqlParameter[] pars ={
                                
                                new SqlParameter("@itemName",SqlDbType.VarChar,100),
                                new SqlParameter("@itemDescri",SqlDbType.VarChar,500),
                                new SqlParameter("@itemMarketPrice",SqlDbType.VarChar,50),
                                new SqlParameter("@itemCost",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSalePrice",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliStation",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliMerchant",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliBrand",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliParType",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliSubType",SqlDbType.VarChar,50),
                                new SqlParameter("@itemStock",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSaleNum",SqlDbType.VarChar,50),
                                new SqlParameter("@itemState",SqlDbType.VarChar),
                                new SqlParameter("@itemThumbnail",SqlDbType.VarChar,100),
                                new SqlParameter("@itemContent",SqlDbType.Text),
                                new SqlParameter("@itemTime",SqlDbType.DateTime),
                                new SqlParameter("@Lastid",SqlDbType.Int,4)
                                };
            pars[0].Value = model.itemName;
            pars[1].Value = model.itemDescri;
            pars[2].Value = model.itemMarketPrice;
            pars[3].Value = model.itemCost;
            pars[4].Value = model.itemSalePrice;
            pars[5].Value = model.itemAffiliStation;
            pars[6].Value = model.itemAffiliMerchant;
            pars[7].Value = model.itemAffiliBrand;
            pars[8].Value = model.itemAffiliParType;
            pars[9].Value = model.itemAffiliSubType;
            pars[10].Value = model.itemStock;
            pars[11].Value = model.itemSaleNum;
            pars[12].Value = model.itemState;
            pars[13].Value = model.itemThumbnail;
            pars[14].Value = model.itemContent;
            pars[15].Value = model.itemTime;
            pars[16].Direction = ParameterDirection.Output;

            return sqldata.ItemsExcuteCommandReturnInt("ADD_Items", CommandType.StoredProcedure, pars);
        }

        
        public int UpdateItems(ModelItems model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@itemsID",SqlDbType.Int,4),
                                new SqlParameter("@itemName",SqlDbType.VarChar,100),
                                new SqlParameter("@itemDescri",SqlDbType.VarBinary,500),
                                new SqlParameter("@itemMarketPrice",SqlDbType.VarChar,50),
                                new SqlParameter("@itemCost",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSalePrice",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliStation",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliMerchant",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliBrand",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliParType",SqlDbType.VarChar,50),
                                new SqlParameter("@itemAffiliSubType",SqlDbType.VarChar,50),
                                new SqlParameter("@itemStock",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSaleNum",SqlDbType.VarChar,50),
                                new SqlParameter("@itemState",SqlDbType.VarChar),
                                new SqlParameter("@itemThumbnail",SqlDbType.VarChar,100),
                                new SqlParameter("@itemContent",SqlDbType.Text),
                                new SqlParameter("@itemTime",SqlDbType.DateTime),
                                
                                };
           
            pars[0].Value = model.itemsID;
            pars[1].Value = model.itemName;
            pars[2].Value = model.itemDescri;
            pars[3].Value = model.itemMarketPrice;
            pars[4].Value = model.itemCost;
            pars[5].Value = model.itemSalePrice;
            pars[6].Value = model.itemAffiliStation;
            pars[7].Value = model.itemAffiliMerchant;
            pars[8].Value = model.itemAffiliBrand;
            pars[9].Value = model.itemAffiliParType;
            pars[10].Value = model.itemAffiliSubType;
            pars[11].Value = model.itemStock;
            pars[12].Value = model.itemSaleNum;
            pars[13].Value = model.itemState;
            pars[14].Value = model.itemThumbnail;
            pars[15].Value = model.itemContent;
            pars[16].Value = model.itemTime;


            return sqldata.ExcuteCommandReturnInt("Update_Items", CommandType.StoredProcedure, pars);
        }
       
        public int AddWithUpdateTrialItems(ModelItemsTrial model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@itemsID",SqlDbType.Int,4),
                                new SqlParameter("@IsTrial",SqlDbType.Bit),
                                new SqlParameter("@itemTriPrice",SqlDbType.VarChar,50),
                                new SqlParameter("@itemTriOnlStock",SqlDbType.VarChar,50),
                                new SqlParameter("@itemTriVideoStock",SqlDbType.VarChar,50),
                                new SqlParameter("@itemTriApply",SqlDbType.VarChar,50),
                                new SqlParameter("@itemTriAgree",SqlDbType.VarChar,50),
                                new SqlParameter("@itemTriStime",SqlDbType.VarChar,100),
                                new SqlParameter("@itemTriEtime",SqlDbType.VarChar,100),
                                new SqlParameter("@itemTriState",SqlDbType.Text)
                                };
            pars[0].Value = model.itemsID;
            pars[1].Value = model.IsTrial;
            pars[2].Value = model.itemTriPrice;
            pars[3].Value = model.itemTriOnlStock;
            pars[4].Value = model.itemTriVideoStock;
            pars[5].Value = model.itemTriApply;
            pars[6].Value = model.itemTriAgree;
            pars[7].Value = model.itemTriStime;
            pars[8].Value = model.itemTriEtime;
            pars[9].Value = model.itemTriState;

            return sqldata.ExcuteCommandReturnInt("AddWithUpdate_TrialItems", CommandType.StoredProcedure, pars);
        }

        public int AddWithUpdateSeckillItems(ModelItemsSeckill model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@itemsID",SqlDbType.Int,4),
                                new SqlParameter("@IsSeckill",SqlDbType.Bit),
                                new SqlParameter("@itemSecPrice",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSecStock",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSecSaleNum",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSecState",SqlDbType.VarChar,50),
                                new SqlParameter("@itemSecTime",SqlDbType.VarChar,100)
                                };
            pars[0].Value = model.itemsID;
            pars[1].Value = model.IsSeckill;
            pars[2].Value = model.itemSecPrice;
            pars[3].Value = model.itemSecStock;
            pars[4].Value = model.itemSecSaleNum;
            pars[5].Value = model.itemSecState;
            pars[6].Value = model.itemSecTime;

            return sqldata.ExcuteCommandReturnInt("AddWithUpdate_SeckillItems", CommandType.StoredProcedure, pars);
        }


        public Model.ModelItems GetItemsModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.ModelItems model = new Model.ModelItems();
            
            DataSet ds = sqldata.ExcuteSelectReturnDataSet("Model_Items", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["itemsID"].ToString() != "")
                {
                    model.itemsID = int.Parse(ds.Tables[0].Rows[0]["itemsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["itemName"].ToString() != "")
                {
                    model.itemName = ds.Tables[0].Rows[0]["itemName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemDescri"].ToString() != "")
                {
                    model.itemDescri = ds.Tables[0].Rows[0]["itemDescri"].ToString();
                }

                if (ds.Tables[0].Rows[0]["itemMarketPrice"].ToString() != "")
                {
                    model.itemMarketPrice = ds.Tables[0].Rows[0]["itemMarketPrice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemCost"].ToString() != "")
                {
                    model.itemCost = ds.Tables[0].Rows[0]["itemCost"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemSalePrice"].ToString() != "")
                {
                    model.itemSalePrice = ds.Tables[0].Rows[0]["itemSalePrice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemAffiliStation"].ToString() != "")
                {
                    model.itemAffiliStation = ds.Tables[0].Rows[0]["itemAffiliStation"].ToString();
                }

                if (ds.Tables[0].Rows[0]["itemAffiliMerchant"].ToString() != "")
                {
                    model.itemAffiliMerchant = ds.Tables[0].Rows[0]["itemAffiliMerchant"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemAffiliBrand"].ToString() != "")
                {
                    model.itemAffiliBrand = ds.Tables[0].Rows[0]["itemAffiliBrand"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemAffiliParType"].ToString() != "")
                {
                    model.itemAffiliParType = ds.Tables[0].Rows[0]["itemAffiliParType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemAffiliSubType"].ToString() != "")
                {
                    model.itemAffiliSubType = ds.Tables[0].Rows[0]["itemAffiliSubType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemStock"].ToString() != "")
                {
                    model.itemStock = ds.Tables[0].Rows[0]["itemStock"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemSaleNum"].ToString() != "")
                {
                    model.itemSaleNum = ds.Tables[0].Rows[0]["itemSaleNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemState"].ToString() != "")
                {
                    model.itemState = ds.Tables[0].Rows[0]["itemState"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemTime"].ToString() != "")
                {
                    model.itemTime = DateTime.Parse(ds.Tables[0].Rows[0]["itemTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["itemThumbnail"].ToString() != "")
                {
                    model.itemThumbnail = ds.Tables[0].Rows[0]["itemThumbnail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["itemContent"].ToString() != "")
                {
                    model.itemContent = ds.Tables[0].Rows[0]["itemContent"].ToString();
                }

                
               

                return model;
            }
            else
            {
                return null;
            }
        }

        public Model.ModelItemsTrial GetItemsTriModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.ModelItemsTrial Tmodel = new Model.ModelItemsTrial();
            DataSet ds = sqldata.ExcuteSelectReturnDataSet("Model_Items", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                    if (ds.Tables[0].Rows[0]["IsTrial"].ToString() != "")
                    {
                        Tmodel.IsTrial = bool.Parse(ds.Tables[0].Rows[0]["IsTrial"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["itemTriPrice"].ToString() != "")
                    {
                        Tmodel.itemTriPrice = ds.Tables[0].Rows[0]["itemTriPrice"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemTriOnlStock"].ToString() != "")
                    {
                        Tmodel.itemTriOnlStock = ds.Tables[0].Rows[0]["itemTriOnlStock"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemTriVideoStock"].ToString() != "")
                    {
                        Tmodel.itemTriVideoStock = ds.Tables[0].Rows[0]["itemTriVideoStock"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemTriApply"].ToString() != "")
                    {
                        Tmodel.itemTriApply = ds.Tables[0].Rows[0]["itemTriApply"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemTriAgree"].ToString() != "")
                    {
                        Tmodel.itemTriAgree = ds.Tables[0].Rows[0]["itemTriAgree"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemTriStime"].ToString() != "")
                    {
                        Tmodel.itemTriStime = ds.Tables[0].Rows[0]["itemTriStime"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemTriState"].ToString() != "")
                    {
                        Tmodel.itemTriState = ds.Tables[0].Rows[0]["itemTriState"].ToString();
                    }

                
                return Tmodel;
                
            }
            else
            {
                return null;
            }
        }
        public Model.ModelItemsSeckill GetItemsSecModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.ModelItemsSeckill Smodel = new Model.ModelItemsSeckill();
            DataSet ds = sqldata.ExcuteSelectReturnDataSet("Model_Items", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                    if (ds.Tables[0].Rows[0]["IsSeckill"].ToString() != "")
                    {
                        Smodel.IsSeckill = bool.Parse(ds.Tables[0].Rows[0]["IsSeckill"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["itemSecPrice"].ToString() != "")
                    {
                        Smodel.itemSecPrice = ds.Tables[0].Rows[0]["itemSecPrice"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemSecStock"].ToString() != "")
                    {
                        Smodel.itemSecStock = ds.Tables[0].Rows[0]["itemSecStock"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemSecSaleNum"].ToString() != "")
                    {
                        Smodel.itemSecSaleNum = ds.Tables[0].Rows[0]["itemSecSaleNum"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemSecState"].ToString() != "")
                    {
                        Smodel.itemSecState = ds.Tables[0].Rows[0]["itemSecState"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["itemTriAgree"].ToString() != "")
                    {
                        Smodel.itemSecTime = ds.Tables[0].Rows[0]["itemSecTime"].ToString();
                    }
                   

                
                return Smodel;
                }
                

            else
            {
                return null;
            }
        }

    }
}
