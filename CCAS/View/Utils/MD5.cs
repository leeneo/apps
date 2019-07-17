using System;
using System.Security.Cryptography;
using System.Text;
using CMD5 = System.Security.Cryptography.MD5;

namespace CCAS.Utils
{
    /// <summary>
    ///md5 的摘要说明
    /// </summary>
    public static class MD5
    {
        //public md5()
        //{
        //    //
        //    //TODO: 在此处添加构造函数逻辑
        //    //
        //}
        /// <summary>
        /// md5  16位加密
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5Str16(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// MD5　32位加密
        /// md5加密 大写
        /// </summary>
        public static string GetMd5Str32(string str)
        {
            string cl = str;
            string pwd = "";
            CMD5 md5 = CMD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd = pwd + s[i].ToString("X").PadLeft(2, '0');

            }
            return pwd;
        }

        /// <summary>
        /// md5加密 小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5str32(string str)
        {
            string cl = str;
            string pwd = "";
            CMD5 md5 = CMD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd = pwd + s[i].ToString("x").PadLeft(2, '0');

            }
            return pwd;
        }
    }
}