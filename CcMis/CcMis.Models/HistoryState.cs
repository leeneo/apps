using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcMis.Models
{
    public class HistoryState
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? d_date { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string s_room_type { get; set; }
        /// <summary>
        /// 已售数
        /// </summary>
        public int? saled { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int? total { get; set; }

        /// <summary>
        /// 编号对应房间类型
        /// </summary>
        public string vs_describe { get; set; }
    }
}
