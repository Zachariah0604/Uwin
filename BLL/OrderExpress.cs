using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace BLL
{
    public class OrderExpress
    {
        DataConnect dc = new DataConnect();

        public int UpdateOrderExp(ModelExp model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@expressID",SqlDbType.Int,4),
                                new SqlParameter("@AffliOrderID",SqlDbType.Int,4),
                                new SqlParameter("@expressNum",SqlDbType.VarChar,100),
                                new SqlParameter("@expDeliveryTime",SqlDbType.DateTime),
                                //new SqlParameter("@expReceTime",SqlDbType.DateTime),
                                new SqlParameter("@expCompany",SqlDbType.VarChar,50),
                                new SqlParameter("@expAdress",SqlDbType.VarChar,500)
                                };
            pars[0].Value = model.expressID;
            pars[1].Value = model.AffliOrderID;
            pars[2].Value = model.expressNum;
            pars[3].Value = model.expDeliveryTime;
           // pars[4].Value = model.expReceTime;
            pars[4].Value = model.expCompany;
            pars[5].Value = model.expAdress;
            return dc.ExcuteCommandReturnInt("Update_OrderExp", CommandType.StoredProcedure, pars);
        }
        public Model.ModelExp GetExpModel(int ID)
        {
            SqlParameter[] pars ={
                                    new SqlParameter("@ID",SqlDbType.Int,4)
                                    };
            pars[0].Value = ID;
            Model.ModelExp model = new Model.ModelExp();
            DataTable dt = dc.ExcuteSelectReturnDataTable("Model_OrderExp", CommandType.StoredProcedure, pars);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["expressID"] != null)
                {
                    model.expressID = int.Parse(dt.Rows[0]["expressID"].ToString());
                }
                if (dt.Rows[0]["AffliOrderID"] != null)
                {
                    model.AffliOrderID = int.Parse(dt.Rows[0]["AffliOrderID"].ToString());
                }
                if (dt.Rows[0]["expressNum"] != null)
                {
                    model.expressNum = dt.Rows[0]["expressNum"].ToString();
                }
                if (dt.Rows[0]["expCompany"] != null)
                {
                    model.expCompany = dt.Rows[0]["expCompany"].ToString();
                }
                if (dt.Rows[0]["expAdress"] != null)
                {
                    model.expAdress = dt.Rows[0]["expAdress"].ToString();
                }
                if (dt.Rows[0]["expDeliveryTime"] != null)
                {
                    model.expDeliveryTime = DateTime.Parse(dt.Rows[0]["expDeliveryTime"].ToString());
                }
                if (dt.Rows[0]["expReceTime"] != null)
                {
                    model.expReceTime = DateTime.Parse(dt.Rows[0]["expReceTime"].ToString());
                }
               
                return model;
            }
            else
                return null;

        }
    }
}
