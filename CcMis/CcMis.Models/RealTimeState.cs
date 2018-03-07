using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcMis.Models
{
    public class RealTimeState
    {
        /// <summary>
        /// 房间合计
        /// </summary>
        public List<TotalRoom> TotalRooms { get; set; }
        /// <summary>
        /// 房间状态
        /// </summary>
        public List<RoomState> RoomStates { get; set; }

        /// <summary>
        /// 房间状态
        /// </summary>
        public List<Floors> Floors { get; set; }
    }
}
