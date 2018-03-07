using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcMis.Models
{
    public class RoomState
    {
        /// <summary>
        /// 楼层
        /// </summary>
        public int? s_floor { get; set; }
        /// <summary>
        /// 房号
        /// </summary>
        public string s_room_no { get; set; }
        /// <summary>
        /// 房态
        /// </summary>
        public string s_room_state { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string color { get; set; }
    }
}
