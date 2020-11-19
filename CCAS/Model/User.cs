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
        public string UserName { get; set; }
        public string Password { get; set; }
        public string islogon { get; set; }
        public string WeChatID { get; set; }
        public string WeChatName { get; set; }
        public string WorkNo { get; set; }
        public string IsActive { get; set; }
    }
}
