using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using DAL;
using Model;
using System.Data.SqlClient;

namespace BLL
{
    public class UserAddress
    {
        DataConnect dc = new DataConnect();
        Sqlcmd sqlcmd = new Sqlcmd();
        public Model.ModelUserAddress GetUserAddress(int ID)
        {
            SqlParameter[] pars ={
                                     new SqlParameter("@ID",SqlDbType.Int,4)
                                };
            pars[0].Value = ID;

            Model.ModelUserAddress model=new ModelUserAddress();
            DataTable dt = dc.ExcuteSelectReturnDataTable("Model_UserAddress",CommandType.StoredProcedure,pars);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["id"].ToString() != null)
                {
                    model.id = int.Parse(dt.Rows[0]["id"].ToString());
                }
                if (dt.Rows[0]["AffliUserID"].ToString() != null)
                {
                    model.AffliUserID = int.Parse(dt.Rows[0]["AffliUserID"].ToString());
                }
                if (dt.Rows[0]["AffliExpress"].ToString() != null)
                {
                    model.AffliExpress = int.Parse(dt.Rows[0]["AffliExpress"].ToString());
                }
                if (dt.Rows[0]["ReceUser"].ToString() != null)
                {
                    model.ReceUser = dt.Rows[0]["ReceUser"].ToString();
                }
                if (dt.Rows[0]["ReceTele"].ToString() != null)
                {
                    model.ReceTele = dt.Rows[0]["ReceTele"].ToString();
                }
                if (dt.Rows[0]["ReceArea"].ToString() != null)
                {
                    model.ReceArea = dt.Rows[0]["ReceArea"].ToString();
                }
                if (dt.Rows[0]["ReceAddress"].ToString() != null)
                {
                    model.ReceAddress = dt.Rows[0]["ReceAddress"].ToString();
                }
                return model;
            }
            else
                return null;
        }


        public int AddUserAddress(ModelUserAddress model)
        {
            SqlParameter[] pars ={
                                
                                new SqlParameter("@AffliUserID",SqlDbType.Int,4),
                                new SqlParameter("@AffliExpress",SqlDbType.Int,4),
                                new SqlParameter("@ReceUser",SqlDbType.VarChar,50),
                                new SqlParameter("@ReceTele",SqlDbType.VarChar,50),
                                new SqlParameter("@ReceArea",SqlDbType.VarChar,50),
                                new SqlParameter("@ReceAddress",SqlDbType.VarChar,200),
                                };
            pars[0].Value = model.AffliUserID;
            pars[1].Value = model.AffliExpress;
            pars[2].Value = model.ReceUser;
            pars[3].Value = model.ReceTele;
            pars[4].Value = model.ReceArea;
            pars[5].Value = model.ReceAddress;

            return dc.ExcuteCommandReturnInt("ADD_UserAddress", CommandType.StoredProcedure, pars);
        }


        public int UpdateUserAddress(ModelUserAddress model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@id",SqlDbType.Int,4),
                                new SqlParameter("@AffliUserID",SqlDbType.Int,4),
                                new SqlParameter("@AffliExpress",SqlDbType.Int,4),
                                new SqlParameter("@ReceUser",SqlDbType.VarChar,50),
                                new SqlParameter("@ReceTele",SqlDbType.VarChar,50),
                                new SqlParameter("@ReceArea",SqlDbType.VarChar,50),
                                new SqlParameter("@ReceAddress",SqlDbType.VarChar,200),
                                
                                };

            pars[0].Value = model.id;
            pars[1].Value = model.AffliUserID;
            pars[2].Value = model.AffliExpress;
            pars[3].Value = model.ReceUser;
            pars[4].Value = model.ReceTele;
            pars[5].Value = model.ReceArea;
            pars[6].Value = model.ReceAddress;


            return dc.ExcuteCommandReturnInt("Update_UserAddress", CommandType.StoredProcedure, pars);
        }
    }
}
