using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcMis.Models
{
    public class TotalGuests
    {
        /// <summary>
        /// 总房数
        /// </summary>
        public int? Rooms { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public int? Guests { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal? Amounts { get; set; }
    }
}
