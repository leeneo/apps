using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcMis.Models
{
    public class DailyReport
    {
        /// <summary>
        /// 付款C，消费D
        /// </summary>
        public string s_dc { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string s_type { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string vc_describe { get; set; }
        /// <summary>
        /// 当天
        /// </summary>
        public decimal? tday { get; set; }
        /// <summary>
        /// 本月
        /// </summary>
        public decimal? tmon { get; set; }
        /// <summary>
        /// 本年
        /// </summary>
        public decimal? tyear { get; set; }
    }
}
