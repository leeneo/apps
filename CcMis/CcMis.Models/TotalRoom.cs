using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CcMis.Models
{
    public class TotalRoom
    {
        /// <summary>
        /// 总房数
        /// </summary>
        public int? TotalRooms { get; set; }
        /// <summary>
        /// 总价格
        /// </summary>
        public decimal? TotalAmt { get; set; }
        /// <summary>
        /// 空净房
        /// </summary>
        public int? EmptyClean { get; set; }
        /// <summary>
        /// 住客净房
        /// </summary>
        public int? LivingClean { get; set; }
        /// <summary>
        /// 预约空净房
        /// </summary>
        public int? ReserveClean { get; set; }
        /// <summary>
        /// 空脏房
        /// </summary>
        public int? EmptyDirty { get; set; }
        /// <summary>
        /// 住客脏房
        /// </summary>
        public int? LivingDirty { get; set; }
        /// <summary>
        /// 预定脏房
        /// </summary>
        public int? ReserveDirty { get; set; }
        /// <summary>
        /// 自用房
        /// </summary>
        public int? SelfRooms { get; set; }
        /// <summary>
        /// 维修房
        /// </summary>
        public int? RepairRooms { get; set; }
        /// <summary>
        /// 锁房
        /// </summary>
        public int? LockRooms { get; set; }

        /// <summary>
        /// 空净房颜色
        /// </summary>
        public string R { get; set; }
        /// <summary>
        /// 住客房颜色
        /// </summary>
        public string O { get; set; }
        /// <summary>
        /// 预约房颜色
        /// </summary>
        public string B { get; set; }
        /// <summary>
        /// 空脏房颜色
        /// </summary>O
        public string D { get; set; }
        /// <summary>
        /// 维修房颜色
        /// </summary>
        public string M { get; set; }
    }
}
