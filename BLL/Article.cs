using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Article
    {
        DataConnect dc = new DataConnect();



        public int UpdateArticleType(string TypeId, string TypeName)
        {
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@TypeId",TypeId),
                new SqlParameter("@TypeName",TypeName)
            };
            int count = dc.ExcuteCommandReturnInt("UpdateArticleType",CommandType.StoredProcedure,pars);
            return count;
        }

        public int AddArticle(ModelArtice model)
        {
            SqlParameter[] pars ={
                                
                                new SqlParameter("@Title",SqlDbType.NVarChar,100),
                                new SqlParameter("@TypeId",SqlDbType.Int,4),
                                new SqlParameter("@Author",SqlDbType.NVarChar,50),
                                new SqlParameter("@Url",SqlDbType.NVarChar,50),
                                new SqlParameter("@Keyword",SqlDbType.NVarChar,200),
                                new SqlParameter("@Click",SqlDbType.NVarChar,50),
                                new SqlParameter("@Content",SqlDbType.Text),
                                new SqlParameter("@PicUrl",SqlDbType.NVarChar,200),
                                new SqlParameter("@CreateTime",SqlDbType.DateTime,100)
                                };
            pars[0].Value = model.Title;
            pars[1].Value = model.TypeId;
            pars[2].Value = model.Author;
            pars[3].Value = model.Url;
            pars[4].Value = model.Keyword;
            pars[5].Value = model.Click;
            pars[6].Value = model.Content;
            pars[7].Value = model.PicUrl;
            pars[8].Value = model.Creatime;

            return dc.ExcuteCommandReturnInt("ADD_Article",CommandType.StoredProcedure,pars);
        }

        public int UpdateArticle(ModelArtice model)
        {
            SqlParameter[] pars ={
                                new SqlParameter("@NewsId",SqlDbType.Int,4),
                                new SqlParameter("@Title",SqlDbType.NVarChar,100),
                                new SqlParameter("@TypeId",SqlDbType.Int,4),
                                new SqlParameter("@Author",SqlDbType.NVarChar,50),
                                new SqlParameter("@Url",SqlDbType.NVarChar,50),
                                new SqlParameter("@Keyword",SqlDbType.NVarChar,50),
                                new SqlParameter("@Click",SqlDbType.NVarChar,50),
                                new SqlParameter("@Content",SqlDbType.Text),
                                new SqlParameter("@PicUrl",SqlDbType.NVarChar,100),
                                new SqlParameter("@CreateTime",SqlDbType.DateTime,100)
                                };
            pars[0].Value = model.Title;
            pars[1].Value = model.TypeId;
            pars[2].Value = model.Author;
            pars[3].Value = model.Url;
            pars[4].Value = model.Keyword;
            pars[5].Value = model.Click;
            pars[6].Value = model.Content;
            pars[7].Value = model.PicUrl;
            pars[8].Value = model.Creatime;
            return dc.ExcuteCommandReturnInt("Update_Article", CommandType.StoredProcedure, pars);
        }
        public Model.ModelArtice GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.ModelArtice model = new Model.ModelArtice();
            DataSet ds = dc.ExcuteSelectReturnDataSet("Model_Article", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NewsId"].ToString() != "")
                {
                    model.NewsId = int.Parse(ds.Tables[0].Rows[0]["NewsId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString());
                }

                if (ds.Tables[0].Rows[0]["Url"].ToString() != "")
                {
                    model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Keyword"].ToString() != "")
                {
                    model.Keyword = ds.Tables[0].Rows[0]["Keyword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Author"].ToString() != "")
                {
                    model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = ds.Tables[0].Rows[0]["Click"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PicUrl"].ToString() != "")
                {
                    model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.Creatime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeName"].ToString() != "")
                {
                    model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TypeLink"].ToString() != "")
                {
                    model.TypeLink = ds.Tables[0].Rows[0]["TypeLink"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
