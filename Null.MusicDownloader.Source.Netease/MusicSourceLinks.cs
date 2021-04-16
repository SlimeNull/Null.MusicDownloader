using Newtonsoft.Json;
using Null.MusicDownloader.Public.Library;
using Null.MusicDownloader.Source.Netease.ReqEncode;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Null.MusicDownloader.Source.Netease
{
    public class MusicSourceLinks
    {
        public class NeteaseRequest
        {
            public string hlpretag { get; set; }
            public string hlposttag { get; set; }
            public string s { get; set; }
            public string type { get; set; }
            public string offset { get; set; }
            public string total { get; set; }
            public string limit { get; set; }
            public string csrt_token { get; set; }
        }
        //public static 
        public static HttpWebRequest GenSearchMusicByKey(string key, int offset = 1, int limit = 30)
        {
            string reqContent = JsonConvert.SerializeObject(new NeteaseRequest()
            {
                hlpretag = "<span class=\"s-fc7\">",
                hlposttag = "</span>",
                s = key,
                type = "1",
                total = "true",
                offset = offset.ToString(),
                limit = limit.ToString(),
                csrt_token = ""
            });

            IList<KeyValuePair<string, string>> pairs = EncConvert.GenRequestQuery(reqContent, EncConvert.DefaultAesKey);
            HttpWebRequest request = RequestHelper.CreatePostRequest(
                $"https://music.163.com/weapi/cloudsearch/get/web?csrf_token=", pairs);

            request.Headers["Referer"] = "https://music.163.com/search/";
            ProcessRequest(request);
            return request;
        }

        public static void ProcessRequest(HttpWebRequest request)
        {
            request.KeepAlive = true;
            WebHeaderCollection headers = request.Headers;
            CookieContainer cookies = request.CookieContainer;
            cookies.Add(new Cookie("_iuqxldmzr_", "32", "/", ".music.163.com"));
            cookies.Add(new Cookie("_ntes_nnid", $"{Guid.NewGuid():N}%2c{(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds}", "/", ".163.com"));
            cookies.Add(new Cookie("ntes_kaola_ad", "1", "/", ".music.163.com"));
            cookies.Add(new Cookie("WNMCID", $"tucshd.{(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds}", "/", ".music.163.com"));
            cookies.Add(new Cookie("WEVNSM", "1.0.0", "/", ".music.163.com"));

            headers["Origin"] = "https://music.163.com";
            headers["Content-Type"] = "application/x-www-form-urlencoded";
        }
    }
}
