using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelOrderTri
    {
        public ModelOrderTri()
        { }
        private int _orderID;
        private bool? _IsTrial;
        private string _orderTriType;
        private string _orderTriDeliMethod;
        private string _orderTriApplyMethod;
        private string _orderTriApplyer;
        private string _orderTriApplyerTele;
        private string _orderTriState;
        private string _orderTriTime;

        public int orderID
        {
            set { _orderID = value; }
            get { return _orderID; }
        }
        public bool? IsTrial
        {
            set { _IsTrial = value; }
            get { return _IsTrial; }
        }
        public string orderTriType
        {
            set { _orderTriType = value; }
            get { return _orderTriType; }
        }
        public string orderTriDeliMethod
        {
            set { _orderTriDeliMethod = value; }
            get { return _orderTriDeliMethod; }
        }
        public string orderTriApplyMethod
        {
            set { _orderTriApplyMethod = value; }
            get { return _orderTriApplyMethod; }
        }
        public string orderTriApplyer
        {
            set { _orderTriApplyer = value; }
            get { return _orderTriApplyer; }
        }
        public string orderTriApplyerTele
        {
            set { _orderTriApplyerTele = value; }
            get { return _orderTriApplyerTele; }
        }
        public string orderTriState
        {
            set { _orderTriState = value; }
            get { return _orderTriState; }
        }
        public string orderTriTime
        {
            set { _orderTriTime = value; }
            get { return _orderTriTime; }
        }
    }
}
