using API;
using CchMis.Common;
using DAL;
using Newtonsoft.Json;
using QueryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CcMis.Web.Controllers
{
    /// <summary>
    /// 房间
    /// </summary>
    [Authorization]
    public class RoomController : Controller
    {
        /// <summary>
        /// 根据楼层取实时房态
        /// </summary>
        /// <param name="floor">楼层</param>
        /// <returns></returns>
        public string RealTimeRoom(string floor)
        {
            var data = string.Empty;
            if (string.IsNullOrEmpty(floor))
                data = new DRoom().RealTimeState();
            else
                data = new DRoom().RealTimeState(floor);
            //new Log().Info(data);
            return data;
        }


        /// <summary>
        /// 远期房态
        /// </summary>
        /// <returns></returns>
        public string HistoryState(string roomtype)
        {
            var data = string.Empty;
            if (string.IsNullOrEmpty(roomtype))
                data = new DRoom().HistoryState();
            else
                data = new DRoom().HistoryState(roomtype);
            //new Log().Info(data);
            return data;
        }

        /// <summary>
        /// 房间类别
        /// </summary>
        /// <returns></returns>
        public string RoomType()
        {
            var data = new DRoom().RoomType();
            //new Log().Info(data);
            return data;
        }
    }
}
