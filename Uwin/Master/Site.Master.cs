using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;

namespace Uwin.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected string WebTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebTitle = "";
        }
    }
}