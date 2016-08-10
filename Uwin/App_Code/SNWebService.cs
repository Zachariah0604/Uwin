using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Collections.Specialized;
using AjaxControlToolkit;
using System.Data.SqlClient;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]

public class SNWebService : System.Web.Services.WebService
{

    public SNWebService()
    {
        
        //InitializeComponent(); 
    }
  
    [WebMethod]
    public CascadingDropDownNameValue[] GetProvinceContents(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> provinceList = new List<CascadingDropDownNameValue>();

        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 

        SqlConnection sqlConn = new SqlConnection(connectionString);

        sqlConn.Open();

        string strSql = "Select * From ExProvince";

        SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);

        SqlDataReader dtrProvince = sqlCmd.ExecuteReader();

        while (dtrProvince.Read())
        {
            provinceList.Add(new CascadingDropDownNameValue(dtrProvince["Name"].ToString(),dtrProvince["Code"].ToString()));
        }

        dtrProvince.Close();

        sqlConn.Close();

        return provinceList.ToArray();
    }
    
    [WebMethod]
    public CascadingDropDownNameValue[] GetCityContents(string knownCategoryValues, string category)
    {
        StringDictionary provinceList = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        SqlConnection sqlConn = new SqlConnection(connectionString);

        sqlConn.Open();

        string strSql = "Select * From ExCity Where ProvinceId='" + provinceList["Province"] + "'";

        SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);

        SqlDataReader dtrCity = sqlCmd.ExecuteReader();

        List<CascadingDropDownNameValue> cityList = new List<CascadingDropDownNameValue>();

        while (dtrCity.Read())
        {
            cityList.Add(new CascadingDropDownNameValue(dtrCity["Name"].ToString(), dtrCity["code"].ToString()));
        }

        dtrCity.Close();

        return cityList.ToArray();
    }
   
    [WebMethod]
    public CascadingDropDownNameValue[] GetViliageContents(string knownCategoryValues, string category)
    {
        StringDictionary cityList = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        SqlConnection sqlConn = new SqlConnection(connectionString);

        sqlConn.Open();

        string strSql = "Select * From ExArea Where CityId='" + cityList["City"] + "'";

        SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);

        SqlDataReader dtrViliage = sqlCmd.ExecuteReader();

        List<CascadingDropDownNameValue> viliageList = new List<CascadingDropDownNameValue>();

        while (dtrViliage.Read())
        {
            viliageList.Add(new CascadingDropDownNameValue(dtrViliage["Name"].ToString(), dtrViliage["id"].ToString()));
        }

        dtrViliage.Close();

        return viliageList.ToArray();
    }
    
}

