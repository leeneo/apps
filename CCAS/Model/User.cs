using System;

namespace CCAS.Models
{
    /// <summary>
    /// 管理员用户表
    /// </summary>
    [Serializable]
    public class User
    {
        public decimal Userid { get; set; }
        public string workNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public string DeptCode { get; set; }
        public string telno { get; set; }
        public string email { get; set; }
        public string grouplevel { get; set; }
        public string Created_user { get; set; }
        public DateTime Created_date { get; set; }
        public string Audit_User { get; set; }
        public DateTime Audit_date { get; set; }
        public string islogon { get; set; }
        public string WeChatID { get; set; }
        public string WeChatName { get; set; }
    }
}
