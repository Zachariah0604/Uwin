using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class StatisticsBll
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        public void getCountWithDates(string table, string colums, string condition, int CountName, int RowsCount, string NumName, string RowsDay, int SpecificName)
        {
            DataTable dt = sqlcmd.getCommonCountDayData(table, colums, condition);
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["total"].ToString() != null)
                    {
                        CountName += Convert.ToInt32(dt.Rows[j]["total"].ToString());
                        SpecificName = CountName;
                    }
                }
                RowsCount = dt.Rows.Count;
                if (RowsCount > 20)
                    RowsCount = 20;
                for (int i = RowsCount - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["total"].ToString() != null)
                    {
                        string daynum = dt.Rows[i]["total"].ToString();


                        if (i < dt.Rows.Count - 1)
                            NumName += "," + daynum;
                        else
                            NumName += daynum;
                    }
                    if (dt.Rows[i]["Dates"].ToString() != null)
                    {
                        string day = dt.Rows[i]["Dates"].ToString();
                        if (i < dt.Rows.Count - 1)
                            RowsDay += "," + day.Replace("-", "");
                        else
                            RowsDay += day.Replace("-", "");
                    }
                }
            }

        }
    }
}
