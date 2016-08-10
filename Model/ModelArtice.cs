using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelArtice
    {
        public ModelArtice()
        {}
        #region Model
        private int _NewsId;
        private string _Title;
        private int? _TypeId;
        private string _TypeName;
        private string _TypeLink;
        private string _Author;
        private string _Url;
        private string _keyword;
        private string _Click;
        private string _PicUrl;
        private string _Content;
        private DateTime _CreateTime;


        public int NewsId
        {
            set { _NewsId = value; }
            get { return _NewsId; }
        }
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        public int? TypeId
        {
            set { _TypeId = value; }
            get { return _TypeId; }
        }

        public string TypeName
        {
            set { _TypeName = value; }
            get { return _TypeName; }
        }
        public string TypeLink
        {
            set { _TypeLink = value; }
            get { return _TypeLink; }
        }
        public string Author
        {
            set { _Author = value; }
            get { return _Author; }


        }

        public string Url
        {
            set { _Url = value; }
            get { return _Url; }
        }
        public string Keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        public string Click
        {
            set { _Click = value; }
            get { return _Click; }
        }
        public string PicUrl
        {
            set { _PicUrl = value;}
            get { return _PicUrl; }
        }
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }
        public DateTime Creatime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }
        
        #endregion Model
    }
}
