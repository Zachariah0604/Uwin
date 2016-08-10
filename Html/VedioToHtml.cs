using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BLL;
using Model;

namespace Html
{
    public class VedioToHtml
    {
           
            public static void MakeVedio(int videoAfiiliStation)
            {
                Sqlcmd sqlcmd = new Sqlcmd();
                string ModelPath = "Model\\PC\\Vedio\\Vedio.html";
                
                string Headercontent = Html.DirFile.ReadFile("HeaderSecond.html");
                string Footercontent = Html.DirFile.ReadFile("Footer.html");
                
                string savePath = "Vedio\\";

                string ChannelNameList = null;
                string VedioListName = null;
                string itemsLists = null;

                DataTable dt = sqlcmd.getCommonData("Video", "*", " videoAfiiliStation=" + videoAfiiliStation);
                if (dt.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        string tempcontent = Html.DirFile.ReadFile(ModelPath);
                        VedioListName = "Vedio_" + videoAfiiliStation + "_" +dt.Rows[i]["VedioChannelID"].ToString() + ".html";

                        for (int channelname = 0; channelname < dt.Rows.Count; channelname++)
                        {
                            ChannelNameList += "<li><a  href='Vedio_" + videoAfiiliStation + "_" + dt.Rows[channelname]["VedioChannelID"].ToString() + ".html" + "' target=\"_top\">" + dt.Rows[channelname]["VedioChannelName"].ToString() + "</a></li>";
                        }
                        string videoDir = dt.Rows[i]["videoDir"].ToString();
                        string Positions = "当前位置：<a href='../index.shtml' target='_blank' style='color:#000'>首页</a>>>视频专区>><a href='" + VedioListName + "' style='color:#000' target='_top'>" + dt.Rows[i]["VedioChannelName"].ToString() + "</a>";
                        tempcontent = tempcontent.Replace("{$header$}", Headercontent);
                        tempcontent = tempcontent.Replace("{$ChannelNameList}", ChannelNameList);
                        ChannelNameList = null;
                        tempcontent = tempcontent.Replace("{$videoDir}", videoDir);
                        tempcontent = tempcontent.Replace("{$Positions}", Positions);
                        tempcontent = tempcontent.Replace("{$VedioChannelName}", dt.Rows[i]["VedioChannelName"].ToString());
                        
                        string videoIemsArray = dt.Rows[i]["videoIemsArray"].ToString();
                        int videoIemsArrayLen = dt.Rows[i]["videoIemsArray"].ToString().Length;
                        if (videoIemsArray != null && videoIemsArrayLen != 0)
                        {
                            string[] itemslist = videoIemsArray.Split(',');
                            for (int j = 0; j < itemslist.Length; j++)
                            {
                                int itemsID = int.Parse(itemslist[j]);
                                DataTable dtitems = sqlcmd.getCommonData("Items", " itemDescri,itemLink,itemTime", " itemsID=" + itemsID);
                                if (dtitems.Rows.Count > 0)
                                {
                                    for (int m = 0; m < dtitems.Rows.Count; m++)
                                    {
                                        string itemDescri = dtitems.Rows[m]["itemDescri"].ToString();
                                        string itemLink = dtitems.Rows[m]["itemLink"].ToString();
                                        string itemTime = dtitems.Rows[m]["itemTime"].ToString();
                                        itemsLists += "<div class=\"cd-timeline-block\"><div class=\"cd-timeline-img cd-picture\"><img src=\"../img/cd-icon-picture.svg\" alt=\"商品\"></div><div class=\"cd-timeline-content\"><h2>" + itemDescri + "</p><a href='../Items/" + itemLink + "' class=\"cd-read-more\" target=\"_blank\">查看详细</a><span class=\"cd-date\">" + itemTime + "</span></div></div>";
                                    }
                                }
                            }
                           
                        }
                        
                        tempcontent = tempcontent.Replace("{$itemsLists}", itemsLists);
                        tempcontent = tempcontent.Replace("{$DetailTitle}", "");
                        tempcontent = tempcontent.Replace("{$ColumnTitle}", "视频区-");
                        tempcontent = tempcontent.Replace("{$TypeNameTitle}", dt.Rows[i]["VedioChannelName"].ToString() + "-");
                        tempcontent = tempcontent.Replace("{$Footer$}", Footercontent);
                        itemsLists = null;

                        Html.DirFile.CreateFile(savePath + VedioListName, tempcontent);
                    }
                    
                }
                


            }
    }
}
