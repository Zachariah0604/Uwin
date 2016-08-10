using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Resources;
using System.IO;
using BLL;
using Model;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Web.Security;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Text;
namespace Uwin
{
    public partial class Register : System.Web.UI.Page
    {
        Sqlcmd sqlcdm = new Sqlcmd();
        Memeber userbll = new Memeber();
        int usernameresult = 0;
        int userEmailresult = 0;
        public string quserEmail=null;
        int NewUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                step1.Style.Add("display", "block");
                step2.Style.Add("display", "none");
                step3.Style.Add("display", "none");
                
                if (Session["RegisterState"]!= null )
                {
                    string RegisterState = Session["RegisterState"].ToString();
                    if (RegisterState == "success")
                    {
                        step1.Style.Add("display", "none");
                        step2.Style.Add("display", "none");
                        step3.Style.Add("display", "block");
                        processorBox1.Attributes.Remove("class");
                        processorBox2.Attributes.Remove("class");
                        processorBox3.Attributes.Add("class", "current");
                        this.Session.Remove("RegisterState");
                    }
                }
               
            }
        }
        
        protected void FirsetStep_Click(object sender, EventArgs e)
        {

            string vCode = Session["CheckCode"].ToString();
            if (this.ValidCode.Text.Trim().ToUpper() != vCode.ToUpper())
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Startup", "alert('验证码不正确');", true);
            }
            else
            {
                    ModelUser usermodel = new ModelUser();
                    usermodel.userName = userName.Text;
                    string pwdmd51 = FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword.Text, "MD5");
                    string pwdmd52 = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdmd51, "MD5");
                    usermodel.userPassword = pwdmd52;
                    usermodel.userEmail = userEmail.Text;
                    usermodel.userTele = userTele.Text;
                    usermodel.userSex = userSex.SelectedValue.ToString();
                    TextChange(usermodel.userName, "userName");
                    TextChange(usermodel.userEmail, "userEmail");
                    if (1 == usernameresult || 1 == userEmailresult)
                    {
                        Response.Write("<script>alert('用户名或邮箱已被使用，请更换')</script>");

                    }
                    else
                    {
                        if (userPassword.Text != txtConfirmPassword.Text)
                        {
                            Response.Write("<script>alert('两次密码输入不一致')</script>");
                        }

                        else
                        {
                            NewUserID = userbll.RegisterClient(usermodel);
                        }
                        string NewUserIDMd=FormsAuthentication.HashPasswordForStoringInConfigFile(NewUserID.ToString(), "MD5").ToLower().Substring(8, 16);
                        string NewUserIDMd2 = FormsAuthentication.HashPasswordForStoringInConfigFile(NewUserIDMd, "MD5").ToLower().Substring(8, 16);


                        string NewUserNameMd = MakeMD5(userName.Text.ToString(),"gb2312",false);
                        quserEmail = userEmail.Text;
                        string TouserEmail = Server.UrlEncode(userEmail.Text.Trim());
                        string datatime = DateTime.Now.ToString("yyyy-MM-dd");
                        string sData = File.ReadAllText(Server.MapPath("../common/SendEmail.html"));

                      
                        sData = sData.Replace("[$Datatime]", datatime);
                        sData = sData.Replace("[$LINK]", "http://localhost:26380" + "/common/EmailActivate.aspx?code=" + NewUserIDMd2 + "&UN=" + NewUserNameMd + "&RegEmail=" + TouserEmail);
                        sData = sData.Replace("[$UserName]", userName.Text.Trim());
                        SMTPManager.SendEmail("zachariah0604@live.com", "悦赢", userEmail.Text.Trim(), sData, "新用户激活", true);
                        this.userName.Text = "";
                        this.userEmail.Text = "";
                        processorBox1.Attributes.Remove("class");
                        processorBox2.Attributes.Add("class", "current");

                        step1.Style.Add("display", "none");
                        step2.Style.Add("display", "block");
                        
                    }
                
            }
            
        }
       
        public string MakeMD5(string text, string charset, bool isArg)
        {
            try
            {
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

                if (isArg)
                {
                    NameValueCollection Collect = HttpUtility.ParseQueryString(Request.Url.Query, Encoding.GetEncoding(charset));
                    if (Collect[text] != null)
                    {
                        return BitConverter.ToString(MD5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(Collect[text].ToString()))).Replace("-", "").ToLower();
                    }
                }
                else
                {
                    return BitConverter.ToString(MD5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(text))).Replace("-", "").ToLower();
                }
            }
            catch { }

            return string.Empty;
        } 
        private void TextChange(string text,string tablename)
        {
            DataTable judgeDT = sqlcdm.getCommonData("Memeber", " "+tablename, " 1=1");

            if (judgeDT.Rows.Count > 0)
            {
                for (int i = 0; i < judgeDT.Rows.Count; i++)
                {
                    string judgeName = judgeDT.Rows[i][tablename].ToString().Trim();
                    if (judgeName == text && tablename == "userName")
                    {
                        usernameresult = 1;
                        break;
                    }
                    if (judgeName == text && tablename == "userEmail")
                    {
                        userEmailresult = 1;
                        break;
                    }
                }
            }
            if (1 == usernameresult)
            {
                LabelUserName.Text = "该用户名已被使用";
                LabelUserName.Style.Add("color", "red");
            }
            else
            {
                LabelUserName.Text = "";
            }
            if (1 == userEmailresult)
            {
                LabelUserEmail.Text = "该邮箱已被已被使用，请更换";
                LabelUserEmail.Style.Add("color", "red");
            }
            else
            {
                LabelUserEmail.Text = "";
            }
        }
        protected void userName_TextChanged(object sender, EventArgs e)
        {

            TextChange(userName.Text.ToString().Trim(), "userName");
        }

        protected void ReSend_Click(object sender, EventArgs e)
        {
            string NewUserIDMd = FormsAuthentication.HashPasswordForStoringInConfigFile(NewUserID.ToString(), "MD5").ToLower().Substring(8, 16);
            string NewUserIDMd2 = FormsAuthentication.HashPasswordForStoringInConfigFile(NewUserIDMd, "MD5").ToLower().Substring(8, 16);


            string NewUserNameMd = MakeMD5(userName.Text.ToString(), "gb2312", false);
            string TouserEmail = Server.UrlEncode(userEmail.Text.Trim());
            string datatime = DateTime.Now.ToString("yyyy-MM-dd");
            string sData = File.ReadAllText(Server.MapPath("../common/SendEmail.html"));


            sData = sData.Replace("[$Datatime]", datatime);
            sData = sData.Replace("[$LINK]", "http://localhost:26380" + "/common/EmailActivate.aspx?code=" + NewUserIDMd2 + "&UN=" + NewUserNameMd + "&RegEmail=" + TouserEmail);
            sData = sData.Replace("[$UserName]", userName.Text.Trim());
            SMTPManager.SendEmail("zachariah0604@live.com", "悦赢", userEmail.Text.Trim(), sData, "新用户激活", true);
        }

        protected void ReWriter_Click(object sender, EventArgs e)
        {
            processorBox2.Attributes.Remove("class");
            processorBox1.Attributes.Add("class", "current");

            step2.Style.Add("display", "none");
            step1.Style.Add("display", "block");
        }

        protected void userEmail_TextChanged(object sender, EventArgs e)
        {
            TextChange(userEmail.Text.ToString().Trim(), "userEmail");
        }

       
    }
}