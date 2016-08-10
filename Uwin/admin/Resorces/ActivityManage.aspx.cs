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
using Html;

namespace Uwin.admin.Resorces
{
    public partial class ActivityManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();


        string condi = " 1=1 order by ActivityID desc";
        int pagesize = 9;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Stationbind();
                ActivityList();
            }
        }

        private void ActivityList()
        {
            DataSet ds = new DataSet();
            ds = sqlcmd.PageIndex("Activity left join uwinStation on Activity.ActivityAffiStation=uwinStation.staid", "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ActivityRepeter, pagesize);

            ActivityRepeter.DataBind();
        }
        private void Stationbind()
        {
            this.Station.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
            this.Station.DataTextField = "station";
            this.Station.DataValueField = "staid";
            this.Station.DataBind();
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ActivityRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ActivityRepeter.Items[i].FindControl("ActivityCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ActivityRepeter.Items[i].FindControl("ActivityID");

                    string condi = "where ActivityID=" + lb.Text;
                    sqlcmd.CommonDeleteColumns("dbo.Activity", condi);


                }
            }
            ActivityList();
        }


        protected void ToHtml_Click(object sender, EventArgs e)
        {
            int htmlCount = 0;
            for (int i = 0; i < ActivityRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ActivityRepeter.Items[i].FindControl("ActivityCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ActivityRepeter.Items[i].FindControl("ActivityID");
                    string ActivityLink = ActivityHtml.MakeActivityContentByID(int.Parse(lb.Text));
                    htmlCount++;
                    sqlcmd.CommonUpdate(" Activity ", " ActivityLink = " + "'" + ActivityLink + "'", " ActivityID = " + lb.Text);
                }
            }

            Response.Write("<Script Language='JavaScript'>window.alert('成功生成" + htmlCount + "张活动静态页');</script>");
        }

        protected void ActivityAffliType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActivityAffliType.SelectedValue.ToString() == "1")
            {
                condi = " 1=1 ";
                
            }
            
            else

                condi = " Activity.ActivityAffliType = " + this.ActivityAffliType.SelectedValue.ToString();
             
            ActivityList();
        }

        protected void Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            condi = "Activity.ActivityAffiStation =" + this.Station.SelectedValue.ToString();
            
            ActivityList();
        }
    }
}