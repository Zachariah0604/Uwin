using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelExp
    {
        public ModelExp() { }

        private int _expressID;
        private int? _AffliOrderID;
        private string _expressNum;
        private DateTime _expDeliveryTime;
        private DateTime _expReceTime;
        private string _expCompany;
        private string _expAdress;

        public int expressID
        {
            set { _expressID = value; }
            get { return _expressID; }
        }
        public int? AffliOrderID
        {
            set { _AffliOrderID = value; }
            get { return _AffliOrderID; }
        }
        public string expressNum
        {
            set { _expressNum = value; }
            get { return _expressNum; }
        }
        public DateTime expDeliveryTime
        {
            set { _expDeliveryTime = value; }
            get { return _expDeliveryTime; }
        }
        public DateTime expReceTime
        {
            set { _expReceTime = value; }
            get { return _expReceTime; }
        }
        public string expCompany
        {
            set { _expCompany = value; }
            get { return _expCompany; }
        }
        public string expAdress
        {
            set { _expAdress = value; }
            get { return _expAdress; }
        }
    }
}
