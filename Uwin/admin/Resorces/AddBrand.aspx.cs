using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BLL;
using Model;

namespace Uwin.admin.Resorces
{
    public partial class AddBrand : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string table = "dbo.ItemBrand";
            string BrandName = "'" + this.BrandName.Text + "'";
            string picUrl = DateTime.Now.ToString("yyyyMMddhhmmss") + BrandLogo.FileName;
            int count = sqlcmd.CommonInsert(table, " BrandName，BrandLogo", " "+BrandName + "," + picUrl);
            if (count != 0)
            {
                string path = Server.MapPath(@"\FileUpload\Images\Brand\");
                if (UploadImage.FileUpLoad(BrandLogo, path, picUrl) == "false")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('添加失败')", true);
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('添加成功')", true);
            }

        }
    }
}