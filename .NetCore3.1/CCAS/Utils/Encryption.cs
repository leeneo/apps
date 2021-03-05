using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CCAfterSales.Utils
{
    /// <summary>
    /// 加密解密。
    /// </summary>
    public class Encryption
    {
        const string _key = "#^CchMis+_0!";
        /// <summary>
        /// 密钥
        /// </summary>
        public static string Key = _key;
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">需要加密的字符串。</param>
        /// <param name="key">密钥。</param>
        /// <returns></returns>
        public static string AESEncrypt(string value, params string[] key)
        {
            if (key.Length > 0)
                Key = key[0];
            else
                Key = _key;
            byte[] bKey = Encoding.UTF8.GetBytes(MD5Encrypt(Key));
            byte[] bytes = Encoding.UTF8.GetBytes(value);

            string output = null;
            Rijndael aes = Rijndael.Create();
            aes.Key = bKey;
            aes.Mode = CipherMode.ECB;
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cStream.Write(bytes, 0, bytes.Length);
                    cStream.FlushFinalBlock();
                    output = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return output;
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">需要解密的字符串。</param>
        /// <param name="key">密钥。</param>
        /// <returns></returns>
        public static string AESDecrypt(string value, params string[] key)
        {
            try
            {
                if (key.Length > 0)
                    Key = key[0];
                else
                    Key = _key;
                byte[] bkey = Encoding.UTF8.GetBytes(MD5Encrypt(Key));
                byte[] bytes = Convert.FromBase64String(value);

                string output = null;
                Rijndael aes = Rijndael.Create();
                aes.Key = bkey;
                aes.Mode = CipherMode.ECB;
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytes, 0, bytes.Length);
                        cStream.FlushFinalBlock();
                        output = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
                return output;
            }
            catch { return null; }
        }
        /// <summary>
        /// MD5加密字符串。
        /// </summary>
        /// <param name="value">需要加密的字符串。</param>
        /// <returns></returns>
        public static string MD5Encrypt(string value)
        {
            byte[] result = System.Text.Encoding.UTF8.GetBytes(value);
            var md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        /// <summary>
        /// DES加密。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Encrypt(string value, params string[] key)
        {
            if (key.Length > 0)
                Key = key[0];
            else
                Key = _key;
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(value);
                des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(Key);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }
        /// <summary>
        /// DES解密。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Decrypt(string value, params string[] key)
        {
            if (key.Length > 0)
                Key = key[0];
            else
                Key = _key;
            byte[] inputByteArray = Convert.FromBase64String(value);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(Key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(Key);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
    }
}
