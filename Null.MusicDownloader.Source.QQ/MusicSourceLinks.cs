using Null.MusicDownloader.Public.Library;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Null.MusicDownloader.Source.Qq
{
    public static class MusicSourceLinks
    {
        public static HttpWebRequest GenSearchQqMusic(string kwd, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(kwd);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"https://c.y.qq.com/soso/fcgi-bin/client_search_cp?remoteplace=txt.yqq.song&new_json=1&t=0&aggr=1&cr=1&lossless=0&p={page}&n={range}&w={encodedKey}&format=json&notice=0");
            ProcessRequest(request);
            request.Headers["Referer"] = "https://y.qq.com/";
            return request;
        }
        public static HttpWebRequest GenSearchAlbum(string kwd, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(kwd);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"https://c.y.qq.com/soso/fcgi-bin/client_search_cp?remoteplace=txt.yqq.album&ct=24&aggr=0&lossless=0&sem=10&t=8&p={page}&n={range}&w={encodedKey}&format=json&notice=0");
            ProcessRequest(request);
            request.Headers["Referer"] = "https://y.qq.com/";
            return request;
        }
        public static HttpWebRequest GenSearchMv(string kwd, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(kwd);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"https://c.y.qq.com/soso/fcgi-bin/client_search_cp?remoteplace=txt.yqq.mv&ct=24&aggr=0&lossless=0&sem=1&t=12&p={page}&n={range}&w={encodedKey}&format=json&notice=0");
            ProcessRequest(request);
            request.Headers["Referer"] = "https://y.qq.com/";
            return request;
        }
        public static void ProcessRequest(HttpWebRequest request)
        {
            WebHeaderCollection headers = request.Headers;
            headers["Origin"] = "https://y.qq.com";
        }
    }
}
