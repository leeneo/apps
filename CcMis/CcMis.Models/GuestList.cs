using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcMis.Models
{
    public class GuestList
    {
        /// <summary>
        /// 房号
        /// </summary>
        public string s_room_no { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string vc_name { get; set; }

        /// <summary>
        /// 房价
        /// </summary>
        public decimal? n_fact_rate { get; set; }

        /// <summary>
        /// 到店日期 
        /// </summary>
        public DateTime? d_arrive_date { get; set; }

        /// <summary>
        /// 离店日期 
        /// </summary>
        public DateTime? d_depart_date { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string gtype { get; set; }
    }
}
