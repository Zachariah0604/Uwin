using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace BLL
{
    public class Order
    {
        DataConnect dc = new DataConnect();

        public int AddOrder(ModelOrder model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@orderItemID",SqlDbType.Int,4),
                                new SqlParameter("@orderNum",SqlDbType.VarChar,100),
                                new SqlParameter("@orderCost",SqlDbType.VarChar,50),
                                new SqlParameter("@orderCount",SqlDbType.VarChar,10),
                                new SqlParameter("@orderItemID",SqlDbType.VarChar,10),
                                new SqlParameter("@orderExpress",SqlDbType.VarChar,10),
                                new SqlParameter("@orderItemName",SqlDbType.VarChar,100),
                                new SqlParameter("@orderAffiliCart",SqlDbType.VarChar,10),
                                new SqlParameter("@orderAffilStation",SqlDbType.VarChar,10),
                                new SqlParameter("@orderAffilMerchant",SqlDbType.VarChar,10),
                                new SqlParameter("@orderAffiUser",SqlDbType.VarChar,10),
                                new SqlParameter("@orderReceiver",SqlDbType.VarChar,50),
                                new SqlParameter("@orderReceiverTele",SqlDbType.VarChar,50),
                                new SqlParameter("@orderState",SqlDbType.VarChar,50),
                                new SqlParameter("@orderCreatTime",SqlDbType.DateTime)
            };
            pars[0].Value = model.orderID;
            pars[1].Value = model.orderNum;
            pars[2].Value = model.orderCost;
            pars[3].Value = model.orderCount;
            pars[4].Value = model.orderItemID;
            pars[5].Value = model.orderExpress;
            pars[6].Value = model.orderItemName;
            pars[7].Value = model.orderAffiliCart;
            pars[8].Value = model.orderAffilStation;
            pars[9].Value = model.orderAffilMerchant;
            pars[10].Value = model.orderAffiUser;
            pars[11].Value = model.orderReceiver;
            pars[12].Value = model.orderReceiverTele;
            pars[13].Value = model.orderState;
            pars[14].Value = model.orderCreatTime;
            return dc.ExcuteCommandReturnInt("ADD_Order",CommandType.StoredProcedure,pars);
        }

        public int AddTriOrder(ModelOrderTri model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@orderID",SqlDbType.Int,4),
                                new SqlParameter("@IsTrial",SqlDbType.Bit),
                                new SqlParameter("@orderTriType",SqlDbType.VarChar,50),
                                new SqlParameter("@orderTriDeliMethod",SqlDbType.VarChar,50),
                                new SqlParameter("@orderTriApplyMethod",SqlDbType.VarChar,50),
                                new SqlParameter("@orderTriApplyer",SqlDbType.VarChar,50),
                                new SqlParameter("@orderTriApplyerTele",SqlDbType.VarChar,50),
                                new SqlParameter("@orderTriState",SqlDbType.VarChar,50),
                                new SqlParameter("@orderTriTime",SqlDbType.VarChar,100)
            };
            pars[0].Value = model.orderID;
            pars[1].Value = model.IsTrial;
            pars[2].Value = model.orderTriType;
            pars[3].Value = model.orderTriDeliMethod;
            pars[4].Value = model.orderTriApplyMethod;
            pars[5].Value = model.orderTriApplyer;
            pars[6].Value = model.orderTriApplyerTele;
            pars[7].Value = model.orderTriState;
            pars[8].Value = model.orderTriTime;
            return dc.ExcuteCommandReturnInt("ADD_TriOrder", CommandType.StoredProcedure, pars);
        }

        public Model.ModelOrder getOrderModel(int ID)
        {
            SqlParameter[] pars ={
                                    new SqlParameter("@ID",SqlDbType.Int,4)
                                    };
            pars[0].Value = ID;
            Model.ModelOrder model = new Model.ModelOrder();
            DataTable dt = dc.ExcuteSelectReturnDataTable("Model_Order", CommandType.StoredProcedure, pars);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["orderNum"] != null)
                {
                    model.orderNum = dt.Rows[0]["orderNum"].ToString();
                }
                if (dt.Rows[0]["orderCost"] != null)
                {
                    model.orderCost = dt.Rows[0]["orderCost"].ToString();
                }
                if (dt.Rows[0]["orderCount"] != null)
                {
                    model.orderCount = dt.Rows[0]["orderCount"].ToString();
                }
                if (dt.Rows[0]["orderAffiliCart"] != null)
                {
                    model.orderAffiliCart = dt.Rows[0]["orderAffiliCart"].ToString();
                }
               
                if (dt.Rows[0]["orderItemID"] != null)
                {
                    model.orderItemID = dt.Rows[0]["orderItemID"].ToString();
                }
                if (dt.Rows[0]["orderExpress"] != null)
                {
                    model.orderExpress = dt.Rows[0]["orderExpress"].ToString();
                }
                if (dt.Rows[0]["orderItemName"] != null)
                {
                    model.orderItemName = dt.Rows[0]["orderItemName"].ToString();
                }
                if (dt.Rows[0]["orderAffilStation"] != null)
                {
                    model.orderAffilStation = dt.Rows[0]["orderAffilStation"].ToString();
                }
                if (dt.Rows[0]["orderAffilMerchant"] != null)
                {
                    model.orderAffilMerchant = dt.Rows[0]["orderAffilMerchant"].ToString();
                }
                if (dt.Rows[0]["orderAffiUser"] != null)
                {
                    model.orderAffiUser = dt.Rows[0]["orderAffiUser"].ToString();
                }
                if (dt.Rows[0]["orderReceiver"] != null)
                {
                    model.orderReceiver = dt.Rows[0]["orderReceiver"].ToString();
                }
                if (dt.Rows[0]["orderReceiverTele"] != null)
                {
                    model.orderReceiverTele = dt.Rows[0]["orderReceiverTele"].ToString();
                }
                if (dt.Rows[0]["orderState"] != null)
                {
                    model.orderState = dt.Rows[0]["orderState"].ToString();
                }
                if (dt.Rows[0]["orderCreatTime"] != null)
                {
                    model.orderCreatTime = dt.Rows[0]["orderCreatTime"].ToString();
                }
                
                return model;
            }
            else
                return null;
        }

        public Model.ModelOrderTri getOrderTriModel(int ID)
        {
            SqlParameter[] pars ={
                                    new SqlParameter("@ID",SqlDbType.Int,4)
                                    };
            pars[0].Value = ID;
            Model.ModelOrderTri model = new Model.ModelOrderTri();
            DataTable dt = dc.ExcuteSelectReturnDataTable("Model_Order", CommandType.StoredProcedure, pars);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["IsTrial"] != null)
                {
                    model.IsTrial = Boolean.Parse(dt.Rows[0]["IsTrial"].ToString());
                }
                if (dt.Rows[0]["orderTriType"] != null)
                {
                    model.orderTriType = dt.Rows[0]["orderTriType"].ToString();
                }
                if (dt.Rows[0]["orderTriDeliMethod"] != null)
                {
                    model.orderTriDeliMethod = dt.Rows[0]["orderTriDeliMethod"].ToString();
                }
                if (dt.Rows[0]["orderTriApplyMethod"] != null)
                {
                    model.orderTriApplyMethod = dt.Rows[0]["orderTriApplyMethod"].ToString();
                }
                if (dt.Rows[0]["orderTriApplyer"] != null)
                {
                    model.orderTriApplyer = dt.Rows[0]["orderTriApplyer"].ToString();
                }
                if (dt.Rows[0]["orderTriApplyerTele"] != null)
                {
                    model.orderTriApplyerTele = dt.Rows[0]["orderTriApplyerTele"].ToString();
                }
                if (dt.Rows[0]["orderTriState"] != null)
                {
                    model.orderTriState = dt.Rows[0]["orderTriState"].ToString();
                }
                if (dt.Rows[0]["orderTriTime"] != null)
                {
                    model.orderTriTime = dt.Rows[0]["orderTriTime"].ToString();
                }
                

                return model;
            }
            else
                return null;
        }
    }
}
