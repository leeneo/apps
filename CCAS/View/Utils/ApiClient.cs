using CCAS.VModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CCAS.Utils
{
    public class ApiClient : BaseCommon
    {
        public ApiClient(IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings)
            : base( appSettings, wxSettings) { }

        static string host = "";

        public static string Token
        {
            get
            {
                //if (DateTime.Now.Hour < 23 && HttpContext.Current != null && HttpContext.Current.Application["token"] != null)
                //    return HttpContext.Current.Application["token"].ToString();
                //string key = DateTime.Now.ToString("yyyy#MM#dd");
                //string vcName = ConfigurationManager.AppSettings["vcName"];
                //string token = Encryption.AESEncrypt(vcName, key);
                ////_Logger.Info("ApiClient", "提交token：" + token);
                //if (HttpContext.Current != null)
                //    HttpContext.Current.Application["token"] = token;
                //return token;
                return "";
            }
        }

        public static string Get(string url)
        {
            using (WebClient client = new WebClient())
            {
                //_Logger.Info("ApiClient");
                //var s = _WxSettings.Value.IsDebug;
                var uri = new Uri(url);
                //client.Encoding = Encoding.GetEncoding("GB2312");
                //var res = client.DownloadString(uri);
                var res = Encoding.GetEncoding("GB2312").GetString(client.DownloadData(uri));     //解决中文乱码
                return res;
            }
        }
        public static byte[] GetBytes(string url)
        {
            using (WebClient client = new WebClient())
            {
                //client.Encoding = Encoding.GetEncoding("GB2312");
                //client.Encoding = Encoding.UTF8;
                var uri = new Uri(url);
                return client.DownloadData(uri);
            }
        }
        public static T Get<T>(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    //client.Headers.Add("Token", Token);
                    string res = client.DownloadString(url);
                    ResponseData<T> d = JsonConvert.DeserializeObject<ResponseData<T>>(res);
                    if (d.success)
                        return d.data;
                    else
                    {
                        //_Logger.Error("ApiClient.Get<T>", "请求Url:" + url + ",res:" + res);
                        //if (_WxSettings.Value.IsDebug.ToLower() == "true")
                        //    throw new Exception(d.msg);
                        return default(T);
                    }
                }
                catch (Exception e)
                {
                    e = e.GetBaseException();
                    //_Logger.Error(e.Message);
                    return default(T);
                }
            }
        }

        public static string Post(string url, object data)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                string postString = JsonConvert.SerializeObject(data);
                //string postString = "{\"button\":" + JsonConvert.SerializeObject(data)+"}";   //WxMenus根节点如果不加Body: 这里需要手动序列化
                string resString = client.UploadString(url, "POST", postString);
                return resString;
            }
        }
        public static string Post(string url, Dictionary<string, object> data)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                //client.Headers.Add("Token", Token);
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                string resString = client.UploadString(url, "POST", GetParameter(data));
                return resString;
            }
        }
        public static ResponseData<T> Post<T>(string url, Dictionary<string, object> dict) where T : class
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                //client.Headers.Add("Token", Token);
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                string para = GetParameter(dict);
                byte[] postBytes = Encoding.UTF8.GetBytes(para);
                byte[] resBytes = client.UploadData(url, postBytes);
                string resString = Encoding.UTF8.GetString(resBytes);
                return JsonConvert.DeserializeObject<ResponseData<T>>(resString);
            }
        }
        public static string GetParameter(Dictionary<string, object> data)
        {
            StringBuilder text = new StringBuilder();
            foreach (var item in data)
            {
                text.Append(item.Key);
                text.Append("=");
                if (item.Value.GetType() != typeof(string))
                    text.Append(JsonConvert.SerializeObject(item.Value, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
                else
                    text.Append(item.Value);
                text.Append("&");
            }
            text = text.Remove(text.Length - 1, 1);
            return text.ToString();
        }
    }

    public class ResponseData<T>
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }
}