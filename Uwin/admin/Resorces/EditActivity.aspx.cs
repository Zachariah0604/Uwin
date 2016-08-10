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

namespace Uwin.admin.Resorces
{
    public partial class EditActivity : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        Activity ActivityBll = new Activity();
        ModelActivity mActivity = new ModelActivity();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                StationBind();
                if (Request.QueryString["ActivityID"] == null || Request.QueryString["ActivityID"].ToString().Length == 0)
                {
                    Response.Redirect("ActicleList.aspx");
                }
                else
                {
                    int ActivityID = int.Parse(Request.QueryString["ActivityID"].ToString());
                    mActivity=ActivityBll.GetModel(ActivityID);
                    ActivityDataBind();
                }
            }
        }

        private void StationBind()
        {
            this.ActivityAffiStation.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
            this.ActivityAffiStation.DataTextField = "station";
            this.ActivityAffiStation.DataValueField = "staid";
            this.ActivityAffiStation.DataBind();
        }

        public void ActivityDataBind()
        {
            this.ActivityName.Text = mActivity.ActivityName;
            this.ActivityAffliType.SelectedValue = mActivity.ActivityAffliType.ToString();
            this.ActivityZan.Text = mActivity.ActivityZan;
            this.ActivityClick.Text = mActivity.ActivityClick;
            this.ActivityShare.Text = mActivity.ActivityShare;
            this.ActivityAffiStation.SelectedValue = mActivity.ActivityAffiStation.ToString();
            this.ActivityStime.Text = mActivity.ActivityStime;
            this.AcrtivityEtime.Text = mActivity.AcrtivityEtime;
            this.ActivityState.SelectedValue = mActivity.ActivityState.ToString();
            this.ActivityContent.Text = mActivity.ActivityContent;


        }



        protected void EditBtn_Click(object sender, EventArgs e)
        {
            string ActivityThumbs = DateTime.Now.ToString("yyyyMMddhhmmss") + ActivityThumb.FileName;
            ModelActivity model = new ModelActivity()
            {
                ActivityName = "'" + this.ActivityName.Text + "'",
                ActivityAffliType = this.ActivityAffliType.SelectedValue.ToString(),
                ActivityClick = "'" + this.ActivityClick.Text + "'",
                ActivityZan = "'" + this.ActivityZan.Text + "'",
                ActivityShare = "'" + this.ActivityShare.Text + "'",
                ActivityAffiStation="'" +this.ActivityAffiStation.SelectedValue.ToString(),
                ActivityStime = "'" + this.ActivityStime.Text + "'",
                AcrtivityEtime = "'" + this.AcrtivityEtime.Text + "'",
                ActivityState = this.ActivityState.SelectedValue.ToString() ,
                ActivityContent = "'" + this.ActivityContent.Text + "'",
                ActivityCreatime = DateTime.Now.ToString("yyyyMMddhhmmss"),
            };
            int count = ActivityBll.UpdateActivity(model);
            if (count != 0)
            {
                string path = Server.MapPath(@"\FileUpload\Images\ActivityImages\");
                if (UploadImage.FileUpLoad(ActivityThumb, path, ActivityThumbs) == "false")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "test", "alert('文件上传失败')", true);
                }
                else { Response.Write("修改成功"); }
            }
        }

       
    }
}