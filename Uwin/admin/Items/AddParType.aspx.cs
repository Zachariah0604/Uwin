using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace Uwin.admin.Items
{
    public partial class AddParType : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        static string RefileName = "";
        static string path1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string parTypeName = "'"+this.ParTypeName.Text+"'";
            string table = "ItemsParType";

            int count = sqlcmd.CommonInsert(table, "pTypeName", parTypeName);
            if (count != 0)
                Response.Write("添加成功");
            else
                Response.Write("添加失败");
        }
        protected void BtnUpLoad_Click(object sender, EventArgs e)
        {
            UploadItemThumbnail();
            this.ItemThumbnailShow.ImageUrl = "../../FileUpload/Images/ItemsThumb/menu/" + RefileName;
            Response.Write("<script>alert('上传成功!');</script>");
        }

        private void UploadItemThumbnail()
        {
            string filename = this.ItemThumbnail.FileName;
            string targetpath = Server.MapPath("../../FileUpload/Images/ItemsThumb/menu/");
            string filepath = targetpath + this.ItemThumbnail.FileName;
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            ItemThumbnail.SaveAs(Server.MapPath("../../FileUpload/Images/ItemsThumb/menu/") + this.ItemThumbnail.FileName);
            path1 = filepath;


            string path2 = Server.MapPath("../../FileUpload/Images/ItemsThumb/menu/");
            RefileName = "ItemTyThumb_" + this.ItemThumbnail.FileName;
            UploadImage.MakeThumbnail(path1, path2 + RefileName, 120, 120, "Hw");

        }
    }
}