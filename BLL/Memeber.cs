using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Memeber
    {
        DataConnect dc = new DataConnect();
        public Model.ModelUser getUserModel(int ID)
        {
            SqlParameter[] pars ={
                                    new SqlParameter("@ID",SqlDbType.Int,4)
                                    };
            pars[0].Value = ID;
            Model.ModelUser model = new Model.ModelUser();
            DataTable dt = dc.ExcuteSelectReturnDataTable("Model_Member", CommandType.StoredProcedure, pars);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["userID"] != null)
                {
                    model.userID = int.Parse(dt.Rows[0]["userID"].ToString());
                }
                if (dt.Rows[0]["userName"] != null)
                {
                    model.userName = dt.Rows[0]["userName"].ToString();
                }
                if (dt.Rows[0]["userPassword"] != null)
                {
                    model.userPassword = dt.Rows[0]["userPassword"].ToString();
                }
                if (dt.Rows[0]["nickName"] != null)
                {
                    model.nickName = dt.Rows[0]["nickName"].ToString();
                }
                if (dt.Rows[0]["userSex"] != null)
                {
                    model.userSex = dt.Rows[0]["userSex"].ToString();
                }
                if (dt.Rows[0]["userEmail"] != null)
                {
                    model.userEmail = dt.Rows[0]["userEmail"].ToString();
                }
                if (dt.Rows[0]["userTele"] != null)
                {
                    model.userTele = dt.Rows[0]["userTele"].ToString();
                }
                if (dt.Rows[0]["userLevel"] != null)
                {
                    model.userLevel = dt.Rows[0]["userLevel"].ToString();
                }
                if (dt.Rows[0]["userVipLevel"] != null)
                {
                    model.userVipLevel = dt.Rows[0]["userVipLevel"].ToString();
                }
                if (dt.Rows[0]["userState"] != null)
                {
                    model.userState = dt.Rows[0]["userState"].ToString();
                }
                if (dt.Rows[0]["userCreatime"] != null)
                {
                    model.userCreatime = Convert.ToDateTime(dt.Rows[0]["userCreatime"].ToString());
                }
                

                return model;
            }
            else
                return null;
        }

        public int RegisterClient(ModelUser model)
        {


            SqlParameter[] pars ={
                                new SqlParameter("@userName",SqlDbType.VarChar,100),
                                new SqlParameter("@userSex",SqlDbType.VarChar,10),
                                new SqlParameter("@userTele",SqlDbType.VarChar,50),
                                new SqlParameter("@userEmail",SqlDbType.VarChar,100),
                                new SqlParameter("@userPassword",SqlDbType.VarChar,100),
                                new SqlParameter("@userCreatime",SqlDbType.DateTime),
                               new SqlParameter("@Lastid",SqlDbType.Int,4)
                                };
            pars[0].Value = model.userName;
            pars[1].Value = model.userSex;
            pars[2].Value = model.userTele;
            pars[3].Value = model.userEmail;
            pars[4].Value = model.userPassword;
            pars[5].Value = model.userCreatime;
            pars[6].Direction = ParameterDirection.Output;
            return dc.ItemsExcuteCommandReturnInt("ADD_User", CommandType.StoredProcedure, pars);



            
        }
        public static int EmailCheck(string sUserName, string ToUserEmail)
        {
            DataConnect dc2 = new DataConnect();
            string sql = "select a.userID from (Select userID,substring(sys.fn_VarBinToHexStr(HashBytes('MD5',cast(userName as varchar))),3,32) as username from Memeber where userEmail ='" + ToUserEmail + "')a where a.username='" + sUserName + "'";
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@username",sUserName),
           
            };
            object obj = dc2.SelectSqlReturnObject(sql, CommandType.Text, pars);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }


        }

        public int UserLogin(string username, string pwd)
        {
            string sql = "select count(*) from dbo.Memeber where userName=@username and userPassword=@pwd and userState=1";
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@username",username),
            new SqlParameter("@pwd",pwd)
            };
            object obj = dc.SelectSqlReturnObject(sql, CommandType.Text, pars);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }


        }
       
    }
}
