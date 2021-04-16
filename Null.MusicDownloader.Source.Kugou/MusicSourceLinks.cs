using Null.MusicDownloader.Public.Library;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Null.MusicDownloader.Source.Kugou
{
    public static class MusicSourceLinks
    {
        public static HttpWebRequest GenSearchMusic(string kwd, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(kwd);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"https://mobiles.kugou.com/api/v3/search/song?format=json&keyword={encodedKey}&page={page}&pagesize={range}&showtype=1");
            ProcessRequest(request);
            request.Headers["Referer"] = "https://m3ws.kugou.com/";
            return request;
        }
        public static HttpWebRequest GenSearchAlbum(string kwd, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(kwd);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"https://mobiles.kugou.com/api/v3/search/album?format=json&keyword={encodedKey}&page={page}&pagesize={range}&showtype=1");
            ProcessRequest(request);
            request.Headers["Referer"] = "https://m3ws.kugou.com/";
            return request;
        }
        public static HttpWebRequest GenSearchMv(string kwd, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(kwd);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"https://mobiles.kugou.com/api/v3/search/mv?format=json&keyword={encodedKey}&page={page}&pagesize={range}&showtype=1");
            ProcessRequest(request);
            request.Headers["Referer"] = "https://m3ws.kugou.com/";
            return request;
        }
        public static HttpWebRequest GenGetMusicInfo(string id)
        {

        }
        public static void ProcessRequest(HttpWebRequest request)
        {

        }
    }
}
