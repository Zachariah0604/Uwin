using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Model;
using DAL;

namespace BLL
{
    public class SystemInfo
    {
        DataConnect dc = new DataConnect();

        //public int GetSystemInfo()
        //{
        //    SqlParameter[] pars ={
        //                        new SqlParameter("@ID",SqlDbType.Int,4),
        //                        new SqlParameter("@WebName",SqlDbType.VarChar,100),
        //                        new SqlParameter("@WebTitle",SqlDbType.VarChar,100),
        //                        new SqlParameter("@MetaKeywords",SqlDbType.VarChar,500),
        //                        new SqlParameter("@MetaDescription",SqlDbType.VarChar,500)
        //                        }; 
        //}

        public Model.ModelSysinfo GetSystemInfoModel(int ID)
        {
            SqlParameter[] pars ={
                                    new SqlParameter("@ID",SqlDbType.Int,4)
                                    };
            pars[0].Value = ID;
            Model.ModelSysinfo model = new Model.ModelSysinfo();
            DataTable dt = dc.ExcuteSelectReturnDataTable("Model_SystemInfo",CommandType.StoredProcedure,pars);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["WebName"] != null)
                {
                    model.WebName = dt.Rows[0]["WebName"].ToString();
                }
                if (dt.Rows[0]["WebTitle"] != null)
                {
                    model.WebTitle = dt.Rows[0]["WebTitle"].ToString();
                }
                if (dt.Rows[0]["MetaKeywords"] != null)
                {
                    model.MetaKeywords = dt.Rows[0]["MetaKeywords"].ToString();
                }
                if (dt.Rows[0]["MetaDescription"] != null)
                {
                    model.MetaDescription = dt.Rows[0]["MetaDescription"].ToString();
                }
                if (dt.Rows[0]["WebHttp"] != null)
                {
                    model.WebHttp = dt.Rows[0]["WebHttp"].ToString();
                }
                if (dt.Rows[0]["CopyRight"] != null)
                {
                    model.CopyRight = dt.Rows[0]["CopyRight"].ToString();
                }
                if (dt.Rows[0]["Beian"] != null)
                {
                    model.Beian = dt.Rows[0]["Beian"].ToString();
                }
                if (dt.Rows[0]["ComAddress"] != null)
                {
                    model.ComAddress = dt.Rows[0]["ComAddress"].ToString();
                }
                if (dt.Rows[0]["Logo"] != null)
                {
                    model.Logo = dt.Rows[0]["Logo"].ToString();
                }
                if (dt.Rows[0]["PCBannera"] != null)
                {
                    model.PCBannera = dt.Rows[0]["PCBannera"].ToString();
                }
                if (dt.Rows[0]["PCBanneraLink"] != null)
                {
                    model.PCBanneraLink = dt.Rows[0]["PCBanneraLink"].ToString();
                }
                if (dt.Rows[0]["PCBannerb"] != null)
                {
                    model.PCBannerb = dt.Rows[0]["PCBannerb"].ToString();
                }
                if (dt.Rows[0]["PCBannerbLink"] != null)
                {
                    model.PCBannerbLink = dt.Rows[0]["PCBannerbLink"].ToString();
                }
                if (dt.Rows[0]["PCBannerc"] != null)
                {
                    model.PCBannerc = dt.Rows[0]["PCBannerc"].ToString();
                }
                if (dt.Rows[0]["PCBannercLink"] != null)
                {
                    model.PCBannercLink = dt.Rows[0]["PCBannercLink"].ToString();
                }
                if (dt.Rows[0]["PCBannerd"] != null)
                {
                    model.PCBannerd = dt.Rows[0]["PCBannerd"].ToString();
                }
                if (dt.Rows[0]["PCBannerdLink"] != null)
                {
                    model.PCBannerdLink = dt.Rows[0]["PCBannerdLink"].ToString();
                }
                if (dt.Rows[0]["WapBannera"] != null)
                {
                    model.WapBannera = dt.Rows[0]["WapBannera"].ToString();
                }
                if (dt.Rows[0]["WapBanneraLink"] != null)
                {
                    model.WapBanneraLink = dt.Rows[0]["WapBanneraLink"].ToString();
                }
                if (dt.Rows[0]["WapBannerb"] != null)
                {
                    model.WapBannerb = dt.Rows[0]["WapBannerb"].ToString();
                }
                if (dt.Rows[0]["WapBannerbLink"] != null)
                {
                    model.WapBannerbLink = dt.Rows[0]["WapBannerbLink"].ToString();
                }
                if (dt.Rows[0]["WapBannerc"] != null)
                {
                    model.WapBannerc = dt.Rows[0]["WapBannerc"].ToString();
                }
                if (dt.Rows[0]["WapBannercLink"] != null)
                {
                    model.WapBannercLink = dt.Rows[0]["WapBannercLink"].ToString();
                }
                if (dt.Rows[0]["WapBannerd"] != null)
                {
                    model.WapBannerd = dt.Rows[0]["WapBannerd"].ToString();
                }
                if (dt.Rows[0]["WapBannerdLink"] != null)
                {
                    model.WapBannerdLink = dt.Rows[0]["WapBannerdLink"].ToString();
                }
                if (dt.Rows[0]["WapBannerAffiStation"] != null)
                {
                    model.WapBannerAffiStation = dt.Rows[0]["WapBannerAffiStation"].ToString();
                }
                if (dt.Rows[0]["Ada"] != null)
                {
                    model.Ada = dt.Rows[0]["Ada"].ToString();
                }
                return model;
            }
            else
                return null;
                                    
        }
    }
}
