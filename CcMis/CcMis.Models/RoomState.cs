using System;
using System.Collections.Generic;

namespace CcMis.Models
{
    public partial class RoomState
    {
        public string SRoomNo { get; set; }
        public string SRoomType { get; set; }
        public string SRoomState { get; set; }
        public int? NShouldPerson { get; set; }
        public string NFactPerson { get; set; }
        public string SFloor { get; set; }
        public string SBuilding { get; set; }
        public string DSetDate { get; set; }
        public string SSetWorkNo { get; set; }
        public string SNewState { get; set; }
        public string SDayState { get; set; }
        public string MessageBmp { get; set; }
        public string Flag { get; set; }
        public string SecState { get; set; }
        public string OcOd { get; set; }
        public string HouseUse { get; set; }
        public string Lock { get; set; }
        public string LockState { get; set; }
        public string SRoomExp { get; set; }
        public string FinalOverdate { get; set; }
        public string LockBmp { get; set; }
        public string LeaveBmp { get; set; }
        public string ViewSign { get; set; }
        public string VipBmp { get; set; }
        public string BackBmp { get; set; }
        public string OtherBmp { get; set; }
        public string RoomDcr { get; set; }
        public string NoUseSize { get; set; }
        public string IsGroup { get; set; }
        public string Vod { get; set; }
        public int? GuestNum { get; set; }
        public string Lockno { get; set; }
        public string CtDept { get; set; }
        public string SHotelUse { get; set; }
        public string SHotelOpen { get; set; }
        public string SLockid { get; set; }
        public DateTime? DLockdate { get; set; }
        public string IsBuild { get; set; }
        public string SMainroom { get; set; }
        public string IsUsed { get; set; }
    }
}
