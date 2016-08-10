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
using System.Data.Sql;

namespace Uwin.admin.Statistics
{
    public partial class SystemInfoSta : System.Web.UI.Page
    {
        SystemInfo sysbll = new SystemInfo();
        ModelSysinfo model = new ModelSysinfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                model= sysbll.GetSystemInfoModel(1);
                this.WebName.Text = model.WebName;
                this.WebTitle.Text = model.WebTitle;
                this.MetaKeywords.Text = model.MetaKeywords;
                this.MetaDescription.Text = model.MetaDescription;
                this.WebHttp.Text = model.WebHttp;
                this.CopyRight.Text = model.CopyRight;
                this.Beian.Text = model.Beian;
                this.ComAddress.Text = model.ComAddress;
                this.Logo.ImageUrl = model.Logo;
                
            }
        }
    }
}