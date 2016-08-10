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

namespace Uwin.admin.Items
{
    public partial class AddSubType : System.Web.UI.Page
    {
        public static int ParTypeIDs=1;
        Sqlcmd sqlcmd = new Sqlcmd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Item item = new Item();
                SqlCommand sqlcmd = item.parType();
                sqlcmd.Connection.Open();
                SqlDataReader sdr = sqlcmd.ExecuteReader();
                while (sdr.Read())
                {
                    parTypeID.Items.Add(new ListItem(sdr["pTypeName"].ToString(), sdr["ParTypeID"].ToString()));
                }
                sdr.Close();
            }
        }

        protected void parTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParTypeIDs = Convert.ToInt32(this.parTypeID.SelectedValue.ToString());
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string subTypeName = "'" +this.subTypeName.Text +"'";
            string values = subTypeName + "," + ParTypeIDs;
            string table = "ItmesSubType";
            int result=sqlcmd.CommonInsert(table, "sTypeName,ParentID", values);
            if (result != 0)
                Response.Write("添加成功");
            else
                Response.Write("添加失败");
        }
    }
}