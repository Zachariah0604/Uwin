using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelStation
    {
        public ModelStation()
        { }

        #region Model
        private int _staid;
        private string _station;
        private int? _roleId;


        public int staid
        {
            set { _staid = value; }
            get { return _staid; }
        }

        public string station
        {
            set { _station = value; }
            get { return _station; }
        }
        public int? roleId
        {
            set{ _roleId =value;}
            get{ return _roleId;}
        }
        #endregion Model
    }
}
