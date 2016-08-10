using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using BLL;


namespace Uwin.admin.Ad
{
    public partial class WapVideo : System.Web.UI.Page
    {
        Sqlcmd sqlcmd = new Sqlcmd();
        private static string Host = "";

        private  string Port = "";
        private  string UserName = "";
        private  string Userpwd = "";
        private  string UploadData = "";
        private  string RemoteFileName = "";
        private  string RemoteDir = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                StationBind();
            }
        }

        private void StationBind()
        {
            this.Station.DataSource = sqlcmd.getCommonData("uwinStation", "*", null);
            this.Station.DataTextField = "station";
            this.Station.DataValueField = "staid";
            this.Station.DataBind();
        }
       public  void MakeFTPDirectory()
       {
            FtpWebRequest req;
            FtpWebResponse response=null;

            req = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Host + ":" + Port + "/" + RemoteDir));  
             req.Credentials = new NetworkCredential(UserName, Userpwd);
            req.Method = WebRequestMethods.Ftp.ListDirectory;
            bool bDirExists = true ;
            try
            {
                response = req.GetResponse() as FtpWebResponse;
            }
            catch
            {
                bDirExists = false;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
            if (bDirExists )
            {
               return;
            }

            string[] dirList = RemoteDir.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string curDir = "/";
            for (int i = 0; i < dirList.Length; i++)
            {
                string dir = dirList[i];
                   if (dir != null && dir.Length > 0)
                {
                    curDir += dir + "/";
                    req = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Host + ":" + Port + "/" + curDir));   
                     req.Credentials = new NetworkCredential(UserName, Userpwd);
                    req.Method = WebRequestMethods.Ftp.MakeDirectory;

                    try
                    { 
                        response = req.GetResponse() as FtpWebResponse;
                    }
                    catch
                    {
 
                    }
                    finally
                    {
                        if(response !=null )
                            response.Close();
                    }
                }
            }
        }

       public bool FTPUploadFile(string filename)
        {
            MakeFTPDirectory();
            FileInfo fileInf = new FileInfo(filename);

            string uri = "ftp://" + Host + ":" + Port + "/" + RemoteDir + RemoteFileName;
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            reqFTP.Credentials = new NetworkCredential(UserName, Userpwd);

            reqFTP.KeepAlive = false;

            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            reqFTP.UseBinary = true;

            reqFTP.ContentLength = fileInf.Length;

            int buffLength = 2048;

            byte[] buff = new byte[buffLength];
            int contentLen;

            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();

                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);

                    contentLen = fs.Read(buff, 0, buffLength);
                }

                strm.Close();
                fs.Close();
                
                
                return true;
            }
            catch (Exception ex)
            {
                Response.Write("Upload Error：" + ex.Message);
                return false;
            }



        }

       protected void EditBtn_Click(object sender, EventArgs e)
       {
          
           Host = this.FtpAddress.Text.ToString().Trim();
           Port = this.FtpPort.Text.ToString().Trim();
           UserName = this.FtpUserName.Text.ToString().Trim();
           Userpwd = this.FtpPassWord.Text.ToString().Trim();
           UploadData = "D:\\" +this.Ada.FileName;
           RemoteFileName = DateTime.Now.ToString("yyyyMMdd") + this.Ada.FileName;
           RemoteDir = this.FtpDir.Text.ToString().Trim();



           if (FTPUploadFile(UploadData))
           {
               string VedioChannelID = this.VedioChannelID.SelectedValue.ToString();
               string VedioChannelName = this.VedioChannelName.Text;
               string videoIemsArray = this.videoIemsArray.Text;
               string ftpaddress = "'ftp://" + Host + ":" + Port + "/" + RemoteDir + RemoteFileName + "'";
               string colums = " videoDir = " + ftpaddress + ",VedioChannelID=" + VedioChannelID + ",VedioChannelName='" + VedioChannelName + "' ,videoIemsArray='" + videoIemsArray + "'";
               int result = sqlcmd.CommonUpdate("Video", colums, " videoAfiiliStation = " + this.Station.SelectedValue.ToString());
               if (result != 0)
               {
                   Response.Write("<script>alert('更换成功')</script>");
               }
               
           }
       }    
    }
}