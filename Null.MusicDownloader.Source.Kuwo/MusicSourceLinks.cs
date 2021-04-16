using System;
using System.Net;
using Null.MusicDownloader.Public.Library;

namespace Null.MusicDownloader.Source.Kuwo
{
    public static class MusicSourceLinks
    {
        public static HttpWebRequest GenSearchMusicByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/search/searchMusicBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/list?key={encodedKey}";
            ProcessRequest(request);
            return request;
        }
        public static HttpWebRequest GenSearchAlbumByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/search/searchAlbumBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/album?key={encodedKey}";
            ProcessRequest(request);
            return request;
        }
        public static HttpWebRequest GenSearchMvByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/search/searchMvBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/mv?key={encodedKey}";
            ProcessRequest(request);
            return request;
        }
        public static HttpWebRequest GenSearchPlaylistByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/search/searchPlayListBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/playlist?key={encodedKey}";
            ProcessRequest(request);
            return request;
        }
        public static HttpWebRequest GenGetSearchArtist(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/search/searchArtistBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/singers?key={encodedKey}";
            ProcessRequest(request);
            return request;
        }

        public static HttpWebRequest GenGetMusicInfo(string id)
        {
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/music/musicInfo?mid={id}&httpsStatus=1");  // 同等于: http://wapi.kuwo.cn/api/www/music/musicInfo?mid={id}&httpsStatus=1
            request.Headers["Referer"] = $"http://kuwo.cn/play_detail/{id}";
            ProcessRequest(request);
            return request;
        }
        public static HttpWebRequest GenGetAlbumInfo(string id, int page = 1, int range = 30)
        {
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/album/albumInfo?albumId={id}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/album_detail/{id}";
            ProcessRequest(request);
            return request;
        }
        //public static HttpWebRequest GenRequestOfMvInfo(string id)
        //{
        //    HttpWebRequest request = RequestHelper.CreateRequest(
        //        $"http://kuwo.cn/api/www/mv/mv?id={id}");
        //    request.Headers["Referer"] = $"http://kuwo.cn/play_detail/{id}";
        //    PutHeaders(request);
        //    return request;
        //}
        public static HttpWebRequest GenGetPlaylistInfo(string id, int page = 1, int range = 30)
        {
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/playlist/playListInfo?pid={id}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/playlist_detail/{id}";
            ProcessRequest(request);
            return request;
        }
        public static HttpWebRequest GenGetArtistInfo(string id)
        {
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/api/www/artist/artist?artistid={id}");
            request.Headers["Referer"] = $"http://kuwo.cn/singer_detail/{id}";
            ProcessRequest(request);
            return request;
        }

        /// <summary>
        /// 获取歌曲的播放链接或MV链接
        /// </summary>
        /// <param name="id">歌曲id</param>
        /// <param name="format">mp3/mp4</param>
        /// <param name="br">bit rate</param>
        /// <returns></returns>
        public static HttpWebRequest GenUrl(string id, string format = "mp3", string br = "128kmp3")
        {
            HttpWebRequest request = RequestHelper.CreateGetRequest(
                $"http://kuwo.cn/url?format={format}&rid={id}&type=convert_url3&br={br}");
            ProcessRequest(request);
            return request;
        }

        public static void ProcessRequest(HttpWebRequest request)
        {
            request.KeepAlive = true;
            WebHeaderCollection headers = request.Headers;
            CookieContainer cookies = request.CookieContainer;

            string csrf = Guid.NewGuid().ToString("N").Substring(0, 11);
            headers["csrf"] = csrf;
            cookies.Add(new Cookie("kw_token", csrf, "/", "kuwo.cn"));
        }
    }
}
