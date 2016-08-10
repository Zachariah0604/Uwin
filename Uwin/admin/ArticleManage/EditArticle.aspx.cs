using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Uwin.admin.ArticleManage
{
    public partial class EditArticle : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        Article articleBll = new Article();
        ModelArtice mArticle = new ModelArtice();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ArticleTypeBind();
                if (Request.QueryString["NewsId"] == null || Request.QueryString["NewsId"].ToString().Length == 0)
                {
                    Response.Redirect("ActicleList.aspx");
                }
                else {
                    string NewsId = Request.QueryString["NewsId"].ToString();
                    DataTable dt = sqlcmd.getCommonData("Article", "*", "NewsId=" + NewsId);
                    if (dt.Rows.Count > 0)
                    {
                        mArticle.NewsId = int.Parse(dt.Rows[0]["NewsId"].ToString());
                        mArticle.Title = dt.Rows[0]["Title"].ToString();
                        mArticle.TypeId = int.Parse(dt.Rows[0]["TypeId"].ToString());
                        mArticle.Author = dt.Rows[0]["Author"].ToString();
                        mArticle.Url = dt.Rows[0]["Url"].ToString();
                        mArticle.Keyword = dt.Rows[0]["Keyword"].ToString();
                        mArticle.Click = dt.Rows[0]["Click"].ToString();
                        mArticle.Content = dt.Rows[0]["Content"].ToString();
                        mArticle.PicUrl = dt.Rows[0]["PicUrl"].ToString();

                        ArticleDataBind();
                    }
                }
            }
        }

        private void ArticleTypeBind()
        {
            this.Type.DataSource = sqlcmd.getCommonData("ArticleType", "*", null);
            this.Type.DataTextField = "TypeName";
            this.Type.DataValueField = "TypeId";
            this.Type.DataBind();
        }

        public void ArticleDataBind()
        {
            this.Title.Text = mArticle.Title;
            this.Author.Text = mArticle.Author;
            Url.Text = mArticle.Url;
            Keyword.Text = mArticle.Keyword;
            Click.Text = mArticle.Click;
            Content.Text = mArticle.Content;
           
            this.Type.SelectedValue = mArticle.TypeId.ToString();


        }

        

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            string picUrl = DateTime.Now.ToString("yyyyMMddhhmmss") + PicUrl.FileName;
            ModelArtice art = new ModelArtice()
            {
                Title = "'" +this.Title.Text+"'",
                TypeId = int.Parse(this.Type.SelectedValue),
                Author = "'" + this.Author.Text + "'",
                Url = "'" + this.Url.Text + "'",
                Keyword = "'" + this.Keyword.Text + "'",
                PicUrl = "'" + picUrl + "'",
                Click = "'" + this.Click.Text + "'",
                Content = "'" + this.Content.Text + "'",
                Creatime = DateTime.Now
            };
            int count = articleBll.UpdateArticle(art);
            if (count != 0)
            {
                string path = Server.MapPath(@"\FileUpload\Images\NewsImages\");
                if (UploadImage.FileUpLoad(PicUrl, path, picUrl) == "false")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('文件上传失败')", true);
                }
                else { Response.Write("修改成功"); }
            }
        }
    }
}