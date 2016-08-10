using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using System.Data.SqlClient;



namespace Uwin.admin.ArticleManage
{
    public partial class AddArticle : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        Article articleBll = new Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Type.DataSource = sqlcmd.getCommonData("ArticleType", "*", null);
                this.Type.DataTextField = "TypeName";
                this.Type.DataValueField = "Typeid";
                this.Type.DataBind();
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
           
            string picUrl = DateTime.Now.ToString("yyyyMMddhhmmss") + PicUrl.FileName;
            ModelArtice art = new ModelArtice()
            {
                Title = this.Title.Text,
                TypeId = int.Parse(this.Type.SelectedValue),
                Author = this.Author.Text,
                Url = this.Url.Text,
                Keyword = this.Keyword.Text,
                PicUrl = picUrl,
                Click = this.Click.Text,
                Content = this.Content.Text,
                Creatime = DateTime.Now
            };
            int count = articleBll.AddArticle(art);
            if (count != 0)
            {
                string path = Server.MapPath(@"\FileUpload\Images\NewsImages\");
                if (UploadImage.FileUpLoad(PicUrl, path, picUrl) == "false")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('文件上传失败')", true);
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('文章发布成功')", true);
            }
        }
    }
}