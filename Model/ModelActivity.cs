using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Model
{
    public partial class ModelActivity
    {

        public ModelActivity(){}

        private int _ActivityID;
        private string _ActivityName;
        private string _ActivityAffliType;
        private string _ActivityClick;
        private string _ActivityZan;
        private string _ActivityShare;
        private string _ActivityAffiStation;
        private string _ActivityStime;
        private string _AcrtivityEtime;
        private string _ActivityState;
        private string _ActivityCreatime;
        private string _ActivityThumb;
        private string _ActivityContent;

        public int ActivityID
        {
            set { _ActivityID = value; }
            get { return _ActivityID; }
        }
        
        public string ActivityName
        {
            set { _ActivityName = value; }
            get { return _ActivityName; }
        }
        
        public string ActivityAffliType
        {
            set { _ActivityAffliType = value; }
            get { return _ActivityAffliType; }
        }
        
        public string ActivityClick
        {
            set { _ActivityClick = value; }
            get { return _ActivityClick; }
        }
        
        public string ActivityZan
        {
            set { _ActivityZan = value; }
            get { return _ActivityZan; }
        }
       
        public string ActivityShare
        {
            set { _ActivityShare = value; }
            get { return _ActivityShare; }
        }

        
        public string ActivityAffiStation
        {
            set { _ActivityAffiStation = value; }
            get { return _ActivityAffiStation; }
        }
        public string ActivityStime
        {
            set { _ActivityStime = value; }
            get { return _ActivityStime; }
        }
        public string AcrtivityEtime
        {
            set { _AcrtivityEtime = value; }
            get { return _AcrtivityEtime; }
        }
        public string ActivityState
        {
            set { _ActivityState = value; }
            get { return _ActivityState; }
        }
        public string ActivityCreatime
        {
            set { _ActivityCreatime = value; }
            get { return _ActivityCreatime; }
        }
        public string ActivityThumb
        {
            set { _ActivityThumb = value; }
            get { return _ActivityThumb; }
        }

        public string ActivityContent
        {
            set { _ActivityContent = value; }
            get { return _ActivityContent; }
        }
    }
}
