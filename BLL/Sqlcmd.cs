using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Sqlcmd
    {
        DataConnect db = new DataConnect();



        public DataTable getCommonData(string tableName, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@table",tableName),
             new SqlParameter("@columns",columns),
             new SqlParameter("@condition",condition)       
          };
            return db.ExcuteSelectReturnDataTable("CommonGetData", CommandType.StoredProcedure, pars);
        }

        public int getCountData(string tableName, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@table",tableName),
             new SqlParameter("@columns",columns),
             new SqlParameter("@condition",condition)       
          };
            return db.ExcuteCommandReturnInt("CommonGetCountData", CommandType.StoredProcedure, pars);
        }


        public DataTable getCommonJoinData(string tableName, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@Jointable",tableName),
             new SqlParameter("@columns",columns),
             new SqlParameter("@condition",condition)       
          };
            return db.ExcuteSelectReturnDataTable("CommonGetJoinData", CommandType.StoredProcedure, pars);
        }

        public DataTable getCommonCountDayData(string table, string columns,  string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@table",table),
             new SqlParameter("@columns",columns), 
             new SqlParameter("@condition",condition)
          };
            return db.ExcuteSelectReturnDataTable("getCommonCountDayData", CommandType.StoredProcedure, pars);
        }

        public DataSet PageIndex(string table, string columns, string condi)
        {
            string sql = "select "+ columns+" from " +table + " where " + condi;
            SqlParameter[] pars = new SqlParameter[]{
           
          };
            DataSet ds = db.ExcuteSelectReturnDataSet(sql,CommandType.Text,pars);
            return ds;
        }
        public DataSet JoinPageIndex(string table, string columns, string condi)
        {
            string sql = "select " + columns + " from " + table + " on " + condi;
            SqlParameter[] pars = new SqlParameter[]{
           
          };
            DataSet ds = db.ExcuteSelectReturnDataSet(sql, CommandType.Text, pars);
            return ds;
        }

       

        public int CommonUpdate(string table, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@table",table),
            new SqlParameter("@columns",columns), 
            new SqlParameter("@condition",condition)
          };

            return db.ExcuteCommandReturnInt("CommonUpdate", CommandType.StoredProcedure, pars);
        }


        public int CommonInsert(string table, string columns, string values)
        {
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@table",table),
            new SqlParameter("@columns",columns), 
            new SqlParameter("@values",values)
          };
            return db.ExcuteCommandReturnInt("CommonInsert", CommandType.StoredProcedure, pars);
        }


        public int CommonDeleteColumns(string table, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@table",table),          
            new SqlParameter("@condition",condition)
          };
            return db.ExcuteCommandReturnInt("CommonDeleteColumns", CommandType.StoredProcedure, pars);
        }

    }
}
