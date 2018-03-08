using System;
using System.Collections.Generic;

namespace CcMis.Models
{
    public partial class RoomType
    {
        public string SRoomType { get; set; }
        public string VsDescribe { get; set; }
        public string NRoomRate { get; set; }
        public string NInRate { get; set; }
        public string NAmount { get; set; }
        public string DSetDate { get; set; }
        public string SSetWorkNo { get; set; }
        public decimal NHourPrice { get; set; }
        public decimal? ExtraRoom { get; set; }
        public string SBreakfast { get; set; }
        public string SShow { get; set; }
        public string SRent { get; set; }
    }
}
