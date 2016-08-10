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

namespace Uwin.admin.Ad
{
    public partial class WapAD : System.Web.UI.Page
    {
        SystemInfo sysBll = new SystemInfo();
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Station.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
                this.Station.DataTextField = "station";
                this.Station.DataValueField = "staid";
                this.Station.DataBind();
            }
        }

       

        protected void Station_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            string picUrl = DateTime.Now.ToString("yyyyMMddhhmmss") + WapBannera.FileName;
            string column = " ADlink = " + "'" + this.WapBanneraLink.Text + "'" + " , ADImge = " + "'" + picUrl + "'" + " , ADAffliStation = " + this.Station.SelectedValue.ToString();
            bool isExit=false;
            int count=0;
            DataTable dt = sqlcmd.getCommonData(" WapAD ", " ADAffliStation "," 1=1");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ADAffliStation"].ToString() == this.Station.SelectedValue.ToString())
                    {
                        isExit = true;
                        break;
                    }
                    
                }
            }
            if (isExit)
            {
                count = sqlcmd.CommonUpdate(" WapAD ", column, " ADAffliStation =" + this.Station.SelectedValue.ToString());
            }
            else 
            {
                count = sqlcmd.CommonInsert(" WapAD ", " ADImge,ADlink,ADAffliStation", "'" + picUrl + "','"  + this.WapBanneraLink.Text + "'," + this.Station.SelectedValue.ToString());
            }
            if (count != 0)
            {
                string path = Server.MapPath(@"\FileUpload\Images\AD\");
                if (UploadImage.FileUpLoad(WapBannera, path, picUrl) == "false")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('更换广告失败')", true);
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('更换广告成功')", true);
            }
        }
    }
}