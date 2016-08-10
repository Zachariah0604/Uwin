using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelItemsTrial
    {
        public ModelItemsTrial() { }


        #region Model
        private int _itemsID;
        private bool? _IsTrial;
        private string _itemTriPrice;
        private string _itemTriOnlStock;
        private string _itemTriVideoStock;
        private string _itemTriApply;
        private string _itemTriAgree;
        private string _itemTriState;
        private string _itemTriStime;
        private string _itemTriEtime;

        public int itemsID
        {
            set { _itemsID = value; }
            get { return _itemsID; }
        }

        public bool? IsTrial
        {
            set { _IsTrial = value; }
            get { return _IsTrial; }
        }

        public string itemTriPrice
        {
            set { _itemTriPrice = value; }
            get { return _itemTriPrice; }
        }

        public string itemTriOnlStock
        {
            set { _itemTriOnlStock = value; }
            get { return _itemTriOnlStock; }
        }

        public string itemTriVideoStock
        {
            set { _itemTriVideoStock = value; }
            get { return _itemTriVideoStock; }

        }
        public string itemTriApply
        {
            set { _itemTriApply = value; }
            get { return _itemTriApply; }
        }

        public string itemTriAgree
        {
            set { _itemTriAgree = value; }
            get { return _itemTriAgree; }
        }


        public string itemTriState
        {
            set { _itemTriState = value; }
            get { return _itemTriState; }
        }

        public string itemTriStime
        {
            set { _itemTriStime = value; }
            get { return _itemTriStime; }
        }
        public string itemTriEtime
        {
            set { _itemTriEtime = value; }
            get { return _itemTriEtime; }
        }

        #endregion Model
    }
}
