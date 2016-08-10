using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;


namespace Uwin.admin.Items
{
    public partial class TypeManage : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        string table = "dbo.ItemsParType left join dbo.ItmesSubType";
        string condi = "dbo.ItemsParType.ParTypeID=dbo.ItmesSubType.ParentID";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                itemsTypelist();
            }
        }

        public void itemsTypelist()
        {

            DataSet ds = new DataSet();
            ds = sqlcmd.JoinPageIndex(table, "*", condi);
            this.PageInfo.InnerHtml = PageIndex.GetPageNum(ds, ItemsTypeRepeter, 9);

            ItemsTypeRepeter.DataBind();
            
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ItemsTypeRepeter.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)ItemsTypeRepeter.Items[i].FindControl("TypeCheck");
                if (cb.Checked)
                {
                    Label lb = (Label)ItemsTypeRepeter.Items[i].FindControl("SubTypeID");

                    sqlcmd.CommonDeleteColumns("dbo.ItmesSubType", "where SubTypeID= " + lb.Text);


                }
            }
            itemsTypelist();
        }
    }
}