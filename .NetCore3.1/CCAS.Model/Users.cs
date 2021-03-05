using System;

namespace CCAS.Model
{
    /// <summary>
    /// 管理员用户表
    /// </summary>
    [Serializable]
    public class Users
    {
        public int Id { get; set; }
        public string WorkNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public string WeChatID { get; set; }
        public string WeChatName { get; set; }
    }
}
