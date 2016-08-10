using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelUser
    {
        public ModelUser() { }

        private int _userID;
        private string _userName;
        private string _userPassword;
        private string _nickName;
        private string _userSex;
        private string _userEmail;
        private string _userTele;
        private string _userLevel;
        private string _userVipLevel;
        private string _userState;
        private DateTime _userCreatime =DateTime.Now;
       


        public int userID
        {
            set { _userID = value; }
            get { return _userID; }
        }

        public string userName
        {
            set { _userName = value; }
            get { return _userName; }
        }
        public string userPassword
        {
            set { _userPassword = value; }
            get { return _userPassword; }
        }
        public string nickName
        {
            set { _nickName = value; }
            get { return _nickName; }
        }
        public string userSex
        {
            set { _userSex = value; }
            get { return _userSex; }
        }
        public string userEmail
        {
            set { _userEmail = value; }
            get { return _userEmail; }
        }
        public string userTele
        {
            set { _userTele = value; }
            get { return _userTele; }
        }
        public string userLevel
        {
            set { _userLevel = value; }
            get { return _userLevel; }
        }
        public string userVipLevel
        {
            set { _userVipLevel = value; }
            get { return _userVipLevel; }
        }
        public string userState
        {
            set { _userState = value; }
            get { return _userState; }
        }
        public DateTime userCreatime
        {
            set { _userCreatime = value; }
            get { return _userCreatime; }
        }
        
    }
}
