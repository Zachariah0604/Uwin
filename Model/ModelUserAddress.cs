using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelUserAddress
    {
        public ModelUserAddress() { }


        private int _id;
        private int? _AffliUserID;
        private int? _AffliExpress;
        private string _ReceUser;
        private string _ReceTele;
        private string _ReceArea;
        private string _ReceAddress;

        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int? AffliUserID
        {
            set { _AffliUserID = value; }
            get { return _AffliUserID; }
        }
        public int? AffliExpress
        {
            set { _AffliExpress = value; }
            get { return _AffliExpress; }
        }
        public string ReceUser
        {
            set { _ReceUser = value; }
            get { return _ReceUser; }
        }
        public string ReceTele
        {
            set { _ReceTele = value; }
            get { return _ReceTele; }
        }
        public string ReceArea
        {
            set { _ReceArea = value; }
            get { return _ReceArea; }
        }
        public string ReceAddress
        {
            set { _ReceAddress = value; }
            get { return _ReceAddress; }
        }
    }
}
