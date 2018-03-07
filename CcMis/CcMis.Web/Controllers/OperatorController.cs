using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelEntites;
using API;
using Newtonsoft.Json;

namespace CcMis.Web.Controllers
{
    [Authorization]
    public class OperatorController : Controller
    {
        DB db = null;

        public string Get(string id)
        {
            DB db = null;
            if (Config.IsMulti)
                db = new DbBranch();
            else
                db = new DB();
            @operator o = new DB().@operator.FirstOrDefault(x => x.s_work_no == id);
            return RetMsg.Success(o);
        }

        public string FromMainDb(string id)
        {
            return RetMsg.Success(new DB().@operator.FirstOrDefault(x => x.s_work_no == id));
        }

        public string UpdatePwd(string id)
        {
            DB db = null;
            if (Config.IsMulti)
                db = new DbBranch();
            else
                db = new DB();
            //var desid=CchMis.Common.Encryption.AESDecrypt(id);
            @operator op = new DB().@operator.FirstOrDefault(x => x.s_work_no == id);
            return RetMsg.Success(op);
        }

        public string Put()
        {
            if (Config.IsMulti)
                db = new DbBranch();
            else
                db = new DB();

            //更新数据，方法一
            try
            {
                @operator user = JsonConvert.DeserializeObject<@operator>(Request["data"]);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return RetMsg.Success(user);
                return RetMsg.UpdateFailed;

            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                LogHelper.Error(ex);
                return RetMsg.Error(ex.Message);
            }
            //更新数据，方法二
            //var query1 = (from q in context.Users
            //              where q.UserName == "Jone"
            //              select q).SingleOrDefault();

            ////判断query1是否为空，若不为空，则修改UserEmail。
            //if (query1 != null)
            //{
            //    query1.UserEmail = "Tom@sina.com";
            //    context.SubmitChanges();
            //}
        }
    }
}
