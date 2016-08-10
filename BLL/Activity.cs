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
    public class Activity
    {
        DataConnect dc = new DataConnect();


        public int AddActivity(ModelActivity model)
        {
            SqlParameter[] pars ={

                                new SqlParameter("@ActivityName",SqlDbType.VarChar,100),
                                new SqlParameter("@ActivityAffliType",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityClick",SqlDbType.VarChar,20),
                                new SqlParameter("@ActivityZan",SqlDbType.VarChar,20),
                                new SqlParameter("@ActivityShare",SqlDbType.VarChar,20),
                                new SqlParameter("@ActivityAffiStation",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityStime",SqlDbType.VarChar,50),
                                new SqlParameter("@AcrtivityEtime",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityState",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityCreatime",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityThumb",SqlDbType.VarChar,100),
                                new SqlParameter("@ActivityContent",SqlDbType.Text)
                                };
            pars[0].Value = model.ActivityName;
            pars[1].Value = model.ActivityAffliType;
            pars[2].Value = model.ActivityClick;
            pars[3].Value = model.ActivityZan;
            pars[4].Value = model.ActivityShare;
            pars[5].Value = model.ActivityAffiStation;
            pars[6].Value = model.ActivityStime;
            pars[7].Value = model.AcrtivityEtime;
            pars[8].Value = model.ActivityState;
            pars[9].Value = model.ActivityCreatime;
            pars[10].Value = model.ActivityThumb;
            pars[11].Value = model.ActivityContent;

            return dc.ExcuteCommandReturnInt("ADD_Activity", CommandType.StoredProcedure, pars);
        }

        public int UpdateActivity(ModelActivity model)
        {
            SqlParameter[] pars ={

                                new SqlParameter("@ActivityName",SqlDbType.VarChar,100),
                                new SqlParameter("@ActivityAffliType",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityClick",SqlDbType.VarChar,20),
                                new SqlParameter("@ActivityZan",SqlDbType.VarChar,20),
                                new SqlParameter("@ActivityShare",SqlDbType.VarChar,20),
                                new SqlParameter("@ActivityAffiStation",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityStime",SqlDbType.VarChar,50),
                                new SqlParameter("@AcrtivityEtime",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityState",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityCreatime",SqlDbType.VarChar,50),
                                new SqlParameter("@ActivityThumb",SqlDbType.VarChar,100),
                                new SqlParameter("@ActivityContent",SqlDbType.Text)
                                };
            pars[0].Value = model.ActivityName;
            pars[1].Value = model.ActivityAffliType;
            pars[2].Value = model.ActivityClick;
            pars[3].Value = model.ActivityZan;
            pars[4].Value = model.ActivityShare;
            pars[5].Value = model.ActivityAffiStation;
            pars[6].Value = model.ActivityStime;
            pars[7].Value = model.AcrtivityEtime;
            pars[8].Value = model.ActivityState;
            pars[9].Value = model.ActivityCreatime;
            pars[10].Value = model.ActivityThumb;
            pars[11].Value = model.ActivityContent;

            return dc.ExcuteCommandReturnInt("Update_Activity", CommandType.StoredProcedure, pars);
        }

        public Model.ModelActivity GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ActivityID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;
            Model.ModelActivity model = new Model.ModelActivity();
            DataTable dt = dc.ExcuteSelectReturnDataTable("Model_Activity", CommandType.StoredProcedure, parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ActivityName"].ToString()!=null)
                    model.ActivityName = dt.Rows[0]["ActivityName"].ToString();
                if (dt.Rows[0]["ActivityAffliType"].ToString() != null)
                    model.ActivityAffliType = dt.Rows[0]["ActivityAffliType"].ToString();
                if (dt.Rows[0]["ActivityClick"].ToString() != null)
                    model.ActivityClick = dt.Rows[0]["ActivityClick"].ToString();
                if (dt.Rows[0]["ActivityZan"].ToString() != null)
                    model.ActivityZan = dt.Rows[0]["ActivityZan"].ToString();
                if (dt.Rows[0]["ActivityShare"].ToString() != null)
                    model.ActivityShare = dt.Rows[0]["ActivityShare"].ToString();
                if (dt.Rows[0]["ActivityAffiStation"].ToString() != null)
                    model.ActivityAffiStation = dt.Rows[0]["ActivityAffiStation"].ToString();
                if (dt.Rows[0]["ActivityStime"].ToString() != null)
                    model.ActivityStime = dt.Rows[0]["ActivityStime"].ToString();
                if (dt.Rows[0]["AcrtivityEtime"].ToString() != null)
                    model.AcrtivityEtime = dt.Rows[0]["AcrtivityEtime"].ToString();
                if (dt.Rows[0]["ActivityState"].ToString() != null)
                    model.ActivityState = dt.Rows[0]["ActivityState"].ToString();
                if (dt.Rows[0]["ActivityCreatime"].ToString() != null)
                    model.ActivityCreatime = dt.Rows[0]["ActivityCreatime"].ToString();
                if (dt.Rows[0]["ActivityThumb"].ToString() != null)
                    model.ActivityThumb = dt.Rows[0]["ActivityThumb"].ToString();
                if (dt.Rows[0]["ActivityContent"].ToString() != null)
                    model.ActivityContent = dt.Rows[0]["ActivityContent"].ToString();
                
                return model;
            }
            else
                return null;
        }
    }
}
