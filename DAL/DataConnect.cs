using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DataConnect
    {

        public string ConnString
        {
            get
            {
                
                return System.Configuration.ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            }


        }

       
        public int ExcuteCommandReturnInt(string CommandText, CommandType type, SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {

                SqlCommand cmd = new SqlCommand(CommandText, conn);
                cmd.CommandType = type;
                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                int count = cmd.ExecuteNonQuery();

                return count;
            }
            catch (Exception ex)
            {

                return 0;

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        public int ItemsExcuteCommandReturnInt(string CommandText, CommandType type, SqlParameter[] pars)
        {
           
            SqlConnection conn = new SqlConnection(ConnString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                
                SqlCommand cmd = new SqlCommand(CommandText, conn);
                cmd.CommandType = type;
                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                        
                       
                    }
                }

                cmd.ExecuteNonQuery();
                int Lastid = Convert.ToInt32(cmd.Parameters["@Lastid"].Value);
                return Lastid;
                
            }
            catch (Exception ex)
            {

                return 0;

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
       
        public DataSet ExcuteSelectReturnDataSet(string SelectStr, CommandType type, SqlParameter[] pars)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnString);
            SqlDataAdapter sda = new SqlDataAdapter(SelectStr, conn);
            if (pars != null && pars.Length > 0)
            {
                foreach (SqlParameter p in pars)
                {
                    sda.SelectCommand.Parameters.Add(p);
                }
            }
            sda.SelectCommand.CommandType = type;
            sda.Fill(ds);
            return ds;
        }

    
        public SqlCommand ExcuteSelectReturnSqlCommand(string str)
        {
            SqlConnection con = new SqlConnection(ConnString);
            SqlCommand sqlcmd = new SqlCommand();   
            sqlcmd.CommandText = str; 
            sqlcmd.Connection = con; 

            return sqlcmd;
            
        }

     
        public DataTable ExcuteSelectReturnDataTable(string SelectStr, CommandType type, SqlParameter[] pars)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnString);
            SqlDataAdapter sda = new SqlDataAdapter(SelectStr, con);
            if (pars != null && pars.Length > 0)
            {
                foreach (SqlParameter p in pars)
                {
                    sda.SelectCommand.Parameters.Add(p);
                }
            }
            sda.SelectCommand.CommandType = type;
            sda.Fill(dt);
            return dt;
        }

       
        public SqlDataReader SelectSqlReturnDataReader(string cmdText, CommandType type, SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            try
            {

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.CommandType = type;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


       
        public object SelectSqlReturnObject(string cmdText, CommandType type, SqlParameter[] pars)
        {
            SqlConnection con = new SqlConnection(ConnString);
            try
            {
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(cmdText, con);

                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.CommandType = type;
                object obj = cmd.ExecuteScalar();
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }



        }


    }
}
