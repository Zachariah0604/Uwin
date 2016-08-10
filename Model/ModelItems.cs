using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelItems
    {
        public ModelItems()
        { }

        #region Model
        private int _itemsID;
        private string _itemName;
        private string _itemDescri;
        private string _itemMarketPrice;
        private string _itemCost;
        private string _itemSalePrice;
        private string _itemAffiliStation;
        private string _itemAffiliMerchant;
        private string _itemAffiliBrand;
        private string _itemAffiliParType;
        private string _itemAffiliSubType;
        private string _itemStock;
        private string _itemSaleNum;
        private string _itemState;
        private int? _Lastid;
        
        private string _itemThumbnail;
        private string _itemContent;
        private DateTime? _itemTime = DateTime.Now;
        
        public int itemsID
        {
            set { _itemsID = value; }
            get { return _itemsID; }
        }
       
        public string itemName
        {
            set { _itemName = value; }
            get { return _itemName; }
        }

        public string itemDescri
        {
            set { _itemDescri = value; }
            get { return _itemDescri; }
        }
       
        public string itemMarketPrice
        {
            set { _itemMarketPrice = value; }
            get { return _itemMarketPrice; }
        }

        public string itemCost
        {
            set { _itemCost = value; }
            get { return _itemCost; }
        }

        public string itemSalePrice
        {
            set { _itemSalePrice = value; }
            get { return _itemSalePrice; }
        }

        public string itemAffiliStation
        {
            set { _itemAffiliStation = value; }
            get { return _itemAffiliStation; }

        }
        public string itemAffiliMerchant
        {
            set { _itemAffiliMerchant = value; }
            get { return _itemAffiliMerchant; }

        }
        public string itemAffiliBrand
        {
            set { _itemAffiliBrand = value; }
            get { return _itemAffiliBrand; }

        }
        public string itemAffiliParType
        {
            set { _itemAffiliParType = value; }
            get { return _itemAffiliParType; }

        }
        public string itemAffiliSubType
        {
            set { _itemAffiliSubType = value; }
            get { return _itemAffiliSubType; }

        }
        
        public string itemStock
        {
            set { _itemStock = value; }
            get { return _itemStock; }
        }
       
        public string itemSaleNum
        {
            set { _itemSaleNum = value; }
            get { return _itemSaleNum; }
        }


        public string itemState
        {
            set { _itemState = value; }
            get { return _itemState; }
        }
        
        

        public string itemThumbnail
        {
            set { _itemThumbnail = value; }
            get { return _itemThumbnail; }
        }
        public string itemContent
        {
            set { _itemContent = value; }
            get { return _itemContent; }
        }
        public DateTime? itemTime
        {
            set { _itemTime = value; }
            get { return _itemTime; }
        }
        public int? Lastid
        {
            set { _Lastid = value; }
            get { return _Lastid; }
        }
        #endregion Model
    }
}
