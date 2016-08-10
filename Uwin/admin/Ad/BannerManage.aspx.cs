using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Uwin.admin.Ad
{
    public partial class BannerManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string UploadBanner(FileUpload fileUpload, string filename, string path1, string RefileName)
        {
            
            string targetpath = Server.MapPath("../../FileUpload/Images/PCBanner/");
            string filepath = targetpath + filename;
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            RefileName = "Banner_" + filename;
            fileUpload.SaveAs(Server.MapPath("../../FileUpload/Images/PCBanner/") + RefileName);
            return RefileName;

        }
        protected void BtnUpLoad1_Click(object sender, EventArgs e)
        {
            string filename = this.FileUpload1.FileName;
            string RefileName = UploadBanner(FileUpload1, filename,null,null);
            int result = sqlcmd.CommonUpdate("SystemInfo", " PCBannera = " + "'" +RefileName + "'"," ID = 1 ");
            if(result!=0)
                Response.Write("<script>alert('上传成功!');</script>");
            else
                Response.Write("<script>alert('上传失败!');</script>");
        }

        protected void BtnUpLoad2_Click(object sender, EventArgs e)
        {
            string filename = this.FileUpload2.FileName;
            string RefileName = UploadBanner(FileUpload2, filename, null, null);
            int result = sqlcmd.CommonUpdate("SystemInfo", " PCBannerb = " + "'" +RefileName + "'", " ID = 1 ");
            if (result != 0)
                Response.Write("<script>alert('上传成功!');</script>");
            else
                Response.Write("<script>alert('上传失败!');</script>");
        }

        protected void BtnUpLoad3_Click(object sender, EventArgs e)
        {
            string filename = this.FileUpload3.FileName;
            string RefileName = UploadBanner(FileUpload3, filename, null, null);
            int result = sqlcmd.CommonUpdate("SystemInfo", " PCBannerc = " + "'" + RefileName + "'", " ID = 1 ");
            if (result != 0)
                Response.Write("<script>alert('上传成功!');</script>");
            else
                Response.Write("<script>alert('上传失败!');</script>");
        }

        protected void BtnUpLoad4_Click(object sender, EventArgs e)
        {
            string filename = this.FileUpload4.FileName;
            string RefileName = UploadBanner(FileUpload4, filename, null, null);
            int result = sqlcmd.CommonUpdate("SystemInfo", " PCBannerd = " + "'" + RefileName + "'", " ID = 1 ");
            if (result != 0)
                Response.Write("<script>alert('上传成功!');</script>");
            else
                Response.Write("<script>alert('上传失败!');</script>");
        }

        
    }
}