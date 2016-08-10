using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelItemsSeckill
    {
        public ModelItemsSeckill() { }


        #region Model
        private int _itemsID;
        private bool? _IsSeckill;
        private string _itemSecPrice;
        private string _itemSecStock;
        private string _itemSecSaleNum;
        private string _itemSecState;
        private string _itemSecTime;

        public int itemsID
        {
            set { _itemsID = value; }
            get { return _itemsID; }
        }

        public bool? IsSeckill
        {
            set { _IsSeckill = value; }
            get { return _IsSeckill; }
        }

        public string itemSecPrice
        {
            set { _itemSecPrice = value; }
            get { return _itemSecPrice; }
        }

        public string itemSecStock
        {
            set { _itemSecStock = value; }
            get { return _itemSecStock; }
        }

        public string itemSecSaleNum
        {
            set { _itemSecSaleNum = value; }
            get { return _itemSecSaleNum; }

        }
        public string itemSecState
        {
            set { _itemSecState = value; }
            get { return _itemSecState; }
        }

       

        public string itemSecTime
        {
            set { _itemSecTime = value; }
            get { return _itemSecTime; }
        }
       

        #endregion Model
    }
}
