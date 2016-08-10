using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ModelAdmin
    {
        public ModelAdmin()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _pwd;
        private string _tele;
        private string _email;
        private int? _roleId;
        //private string _creatime= "'" + Convert.ToString(DateTime.Now) + "'";
        private DateTime? _creatime = DateTime.Now;
        private int? _stationId;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }

        public string tele
        {
            set { _tele = value; }
            get { return _tele; }

        }
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? roleId
        {
            set { _roleId = value; }
            get { return _roleId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? creatime
        {
            set { _creatime = value; }
            get { return _creatime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? stationId
        {
            set { _stationId = value; }
            get { return _stationId; }
        }
        #endregion Model
    }
}
