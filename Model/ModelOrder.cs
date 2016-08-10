using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Model
{
    public partial class ModelOrder
    {
        public ModelOrder()
        { }

        private int _orderID;
        private string _orderNum;
        private string _orderCost;
        private string _orderCount;
        private string _orderItemID;
        private string _orderExpress;
        private string _orderItemName;
        private string _orderAffiliCart;
        private string _orderAffilStation;
        private string _orderAffilMerchant;
        private string _orderAffiUser;
        private string _orderReceiver;
        private string _orderReceiverTele;
        private string _orderState;
        private string _orderCreatTime;
        

        public int orderID
        {
            set { _orderID = value; }
            get { return _orderID; }
        }

        public string orderNum
        {
            set { _orderNum = value; }
            get { return _orderNum; }
        }
        public string orderCost
        {
            set { _orderCost = value; }
            get { return _orderCost; }
        }

        public string orderCount
        {
            set { _orderCount = value; }
            get { return _orderCount; }
        }
        public string orderItemID
        {
            set { _orderItemID = value; }
            get { return _orderItemID; }
        }
        public string orderExpress
        {
            set { _orderExpress = value; }
            get { return _orderExpress; }
        }
        public string orderItemName
        {
            set { _orderItemName = value; }
            get { return _orderItemName; }
        }

        public string orderAffiliCart
        {
            set { _orderAffiliCart = value; }
            get { return _orderAffiliCart; }
        }
        public string orderAffilStation
        {
            set { _orderAffilStation = value;}
            get { return _orderAffilStation; }
        }
        public string orderAffilMerchant
        
        {
            set { _orderAffilMerchant = value; }
            get { return _orderAffilMerchant; }
        }
        public string orderAffiUser
        {
            set { _orderAffiUser = value; }
            get { return _orderAffiUser; }
        }
        public string orderReceiver
        {
            set { _orderReceiver = value; }
            get { return _orderReceiver; }
        }
        public string orderReceiverTele
        {
            set { _orderReceiverTele = value; }
            get { return _orderReceiverTele; }
        }
        public string orderState
        {
            set { _orderState = value; }
            get { return _orderState; }
        }
        public string orderCreatTime
        {
            set { _orderCreatTime = value; }
            get { return _orderCreatTime; }
        }
    }
}
