using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using DAL;


namespace BLL
{
    public class Admin
    {
        DataConnect sqldata = new DataConnect();

        public int Add(Model.ModelAdmin model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
                    new SqlParameter("@tele",SqlDbType.VarChar,50),
                    new SqlParameter("@email",SqlDbType.VarChar,100),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@creatime", SqlDbType.DateTime),
					new SqlParameter("@stationId", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.name;
            parameters[2].Value = model.pwd;
            parameters[3].Value = model.tele;
            parameters[4].Value = model.email;
            parameters[5].Value = model.roleId;
            parameters[6].Value = model.creatime;
            parameters[7].Value = model.stationId;

            sqldata.ExcuteCommandReturnInt("ADD_Manager", CommandType.StoredProcedure, parameters);
            return (int)parameters[0].Value;
        }

        public int StationAdd(Model.ModelStation model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@staid", SqlDbType.Int,4),
					new SqlParameter("@station", SqlDbType.VarChar,50),
					new SqlParameter("@roleId", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.station;
            parameters[2].Value = model.roleId;

            sqldata.ExcuteCommandReturnInt("ADD_Station", CommandType.StoredProcedure, parameters);
            return (int)parameters[0].Value;
        }

        public int Update(Model.ModelAdmin model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@pwd", SqlDbType.VarChar,50),
                    new SqlParameter("@tele",SqlDbType.VarChar,50),
                    new SqlParameter("@email",SqlDbType.VarChar,100),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@creatime", SqlDbType.DateTime),
					new SqlParameter("@stationId", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.name;
            parameters[2].Value = model.pwd;
            parameters[3].Value = model.tele;
            parameters[4].Value = model.email;
            parameters[5].Value = model.roleId;
            parameters[6].Value = model.creatime;
            parameters[7].Value = model.stationId;

            int count = sqldata.ExcuteCommandReturnInt("Update_Manager", CommandType.StoredProcedure, parameters);
            return count;
        }

        public Model.ModelAdmin GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.ModelAdmin model = new Model.ModelAdmin();
            DataSet ds = sqldata.ExcuteSelectReturnDataSet("Model_uwinAdmin", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.pwd = ds.Tables[0].Rows[0]["password"].ToString();
                if (ds.Tables[0].Rows[0]["roleId"].ToString() != "")
                {
                    model.roleId = int.Parse(ds.Tables[0].Rows[0]["roleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["telephone"].ToString() != "")
                {
                    model.tele = ds.Tables[0].Rows[0]["telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["email"].ToString() != "")
                {
                    model.email = ds.Tables[0].Rows[0]["email"].ToString();
                }
               
                if (ds.Tables[0].Rows[0]["stationId"].ToString() != "")
                {
                    model.stationId = int.Parse(ds.Tables[0].Rows[0]["stationId"].ToString());
                }
                
                return model;
            }
            else
            {
                return null;
            }
        }

       
        public SqlCommand station()
        {

            string sql = "select * from dbo.uwinStation left join dbo.uwinRole on dbo.uwinStation.roleId=dbo.uwinRole.rolid";
            SqlCommand cmd = sqldata.ExcuteSelectReturnSqlCommand(sql);
            return cmd;
        }

        public int adminLogin(string username, string pwd, int roleId)
        {
            string sql = "select count(*) from dbo.uwinAdmin where name=@username and password=@pwd and roleId='"+roleId+"'";
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@username",username),
            new SqlParameter("@pwd",pwd)
            };
            object obj = sqldata.SelectSqlReturnObject(sql, CommandType.Text, pars);
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
