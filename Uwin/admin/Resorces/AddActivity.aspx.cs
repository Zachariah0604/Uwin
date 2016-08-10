using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using BLL;
using Model;


namespace Uwin.admin.Resorces
{
    public partial class AddActivity : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        BLL.Activity activityBll = new Activity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ActivityAffiStation.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
                this.ActivityAffiStation.DataTextField = "station";
                this.ActivityAffiStation.DataValueField = "staid";
                this.ActivityAffiStation.DataBind();
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string ActivityThumbs = DateTime.Now.ToString("yyyyMMddhhmmss") + ActivityThumb.FileName;
            ModelActivity model = new ModelActivity()
            {
                ActivityName = this.ActivityName.Text,
                ActivityAffliType = this.ActivityAffliType.SelectedValue.ToString(),
                ActivityClick = this.ActivityClick.Text,
                ActivityZan = this.ActivityZan.Text,
                ActivityShare = this.ActivityShare.Text,
                ActivityAffiStation = this.ActivityAffiStation.SelectedValue.ToString(),
                ActivityStime = this.ActivityStime.Text,
                AcrtivityEtime = this.AcrtivityEtime.Text,
                ActivityState = this.ActivityState.SelectedValue.ToString(),
                ActivityThumb = ActivityThumbs,
                ActivityContent = this.ActivityContent.Text,
                ActivityCreatime = DateTime.Now.ToString("yyyyMMddhhmmss"),
            };
            
            int count = activityBll.AddActivity(model);
            if (count != 0)
            {
                string path = Server.MapPath(@"\FileUpload\Images\ActivityImages\");
                if (UploadImage.FileUpLoad(ActivityThumb, path, ActivityThumbs) == "false")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('文件上传失败')", true);
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('成功添加一个活动')", true);
            }
            
        }
    }
}