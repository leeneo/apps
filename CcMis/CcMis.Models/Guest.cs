using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CcMis.Models
{
    public class Guest
    {
        /// <summary>
        /// 客户列表
        /// </summary>
        public List<GuestList> GuestLists { get; set; }

        public List<TotalGuests> TotalGuests { get; set; }
    }
}
