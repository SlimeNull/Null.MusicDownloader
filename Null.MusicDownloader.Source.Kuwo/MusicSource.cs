using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Null.MusicDownloader.Public;
using Null.MusicDownloader.Public.Library;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using Null.MusicDownloader.Source.Kuwo.SearchResult;
using Null.MusicDownloader.Source.Kuwo.BasicInfo;

namespace Null.MusicDownloader.Source.Kuwo
{
    public static class MusicSourceLinks
    {
        public static HttpWebRequest GenRequestOfSearchMusicByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/search/searchMusicBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/list?key={encodedKey}";
            PutHeaders(request);
            return request;
        }
        public static HttpWebRequest GenRequestOfSearchAlbumByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/search/searchAlbumBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/album?key={encodedKey}";
            PutHeaders(request);
            return request;
        }
        public static HttpWebRequest GenRequestOfSearchMvByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/search/searchMvBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/mv?key={encodedKey}";
            PutHeaders(request);
            return request;
        }
        public static HttpWebRequest GenRequestOfSearchPlaylistByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/search/searchPlayListBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/playlist?key={encodedKey}";
            PutHeaders(request);
            return request;
        }
        public static HttpWebRequest GenRequestOfSearchArtistByKey(string key, int page = 1, int range = 30)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/search/searchArtistBykeyWord?key={encodedKey}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/search/singers?key={encodedKey}";
            PutHeaders(request);
            return request;
        }

        public static HttpWebRequest GenRequestOfMusicInfo(string id)
        {
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/music/musicInfo?mid={id}&httpsStatus=1");//$"http://wapi.kuwo.cn/api/www/music/musicInfo?mid={id}&httpsStatus=1");
            request.Headers["Referer"] = $"http://kuwo.cn/play_detail/{id}";
            PutHeaders(request);
            return request;
        }
        public static HttpWebRequest GenRequestOfAlbumInfo(string id, int page = 1, int range = 30)
        {
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/album/albumInfo?albumId={id}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/album_detail/{id}";
            PutHeaders(request);
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
        public static HttpWebRequest GenRequestOfPlaylistInfo(string id, int page = 1, int range = 30)
        {
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/playlist/playListInfo?pid={id}&pn={page}&rn={range}");
            request.Headers["Referer"] = $"http://kuwo.cn/playlist_detail/{id}";
            PutHeaders(request);
            return request;
        }
        public static HttpWebRequest GenRequestOfArtistInfo(string id)
        {
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/api/www/artist/artist?artistid={id}");
            request.Headers["Referer"] = $"http://kuwo.cn/singer_detail/{id}";
            PutHeaders(request);
            return request;
        }

        /// <summary>
        /// 获取歌曲的播放链接或MV链接
        /// </summary>
        /// <param name="id">歌曲id</param>
        /// <param name="format">mp3/mp4</param>
        /// <param name="br">bit rate</param>
        /// <returns></returns>
        public static HttpWebRequest GenRequestOfUrl(string id, string format = "mp3", string br = "128kmp3")
        {
            HttpWebRequest request = RequestHelper.CreateRequest(
                $"http://kuwo.cn/url?format={format}&rid={id}&type=convert_url3&br={br}");
            PutHeaders(request);
            return request;
        }

        public static void PutHeaders(HttpWebRequest request)
        {
            request.KeepAlive = true;
            WebHeaderCollection headers = request.Headers;
            CookieContainer cookies = request.CookieContainer;

            string csrf = Guid.NewGuid().ToString("N").Substring(0, 11);
            headers["csrf"] = csrf;
            cookies.Add(new Cookie("kw_token", csrf, "/", "kuwo.cn"));
        }
    }

    public class MusicSource : IMusicSource
    {
        public void DownloadKuwoMusic(MusicInfo music, FileStream fs)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfUrl(music.MusicId);

            NetPackage package = JsonConvert.DeserializeObject<NetPackage>(
                RequestHelper.GetResponseText(request));

            HttpWebRequest download = RequestHelper.CreateRequest(package.url);
            RequestHelper.GetResponseStream(download).CopyTo(fs);
        }
        public AlbumInfo RequestKuwoAlbumInfo(string id)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfAlbumInfo(id, 1, int.MaxValue);

            return JsonConvert.DeserializeObject<AlbumInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public ArtistInfo RequestKuwoArtistInfo(string id)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfArtistInfo(id);

            return JsonConvert.DeserializeObject<ArtistInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MusicInfo RequestKuwoMusicInfo(string id)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfMusicInfo(id);

            return JsonConvert.DeserializeObject<MusicInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MvInfo RequestKuwoMvInfo(string id)
        {
            throw new NotSupportedException();
        }
        public PlaylistInfo RequestKuwoPlaylistInfo(string id)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfPlaylistInfo(id, 1, int.MaxValue);

            return JsonConvert.DeserializeObject<PlaylistInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public AlbumSearchResult SearchKuwoAlbum(string kwd)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfSearchAlbumByKey(kwd);

            return JsonConvert.DeserializeObject<AlbumSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MergedSearchResult SearchKuwoAll(string kwd)
        {
            throw new NotImplementedException();
        }
        public ArtistSearchResult SearchKuwoArtist(string kwd)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfSearchArtistByKey(kwd);

            return JsonConvert.DeserializeObject<ArtistSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MusicSearchResult SearchKuwoMusic(string kwd)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfSearchMusicByKey(kwd);

            return JsonConvert.DeserializeObject<MusicSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MvSearchResult SearchKuwoMv(string kwd)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfSearchMvByKey(kwd);

            return JsonConvert.DeserializeObject<MvSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public PlaylistSearchResult SearchKuwoPlaylist(string kwd)
        {
            HttpWebRequest request = MusicSourceLinks.GenRequestOfSearchPlaylistByKey(kwd);

            return JsonConvert.DeserializeObject<PlaylistSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }

        public IAlbumInfo RequestAlbumInfo(string id)
        {
            return RequestKuwoAlbumInfo(id);
        }
        public IArtistInfo RequestArtistInfo(string id)
        {
            return RequestKuwoArtistInfo(id);
        }
        public IMusicInfo RequestMusicInfo(string id)
        {
            return RequestKuwoMusicInfo(id);
        }
        public IMvInfo RequestMvInfo(string id)
        {
            return RequestKuwoMvInfo(id);
        }
        public IPlaylistInfo RequestPlaylistInfo(string id)
        {
            return RequestKuwoPlaylistInfo(id);
        }
        public IAlbumSearchResult SearchAlbum(string kwd)
        {
            return SearchKuwoAlbum(kwd);
        }
        public IMergedSearchResult SearchAll(string kwd)
        {
            return SearchKuwoAll(kwd);
        }
        public IArtistSearchResult SearchArtist(string kwd)
        {
            return SearchKuwoArtist(kwd);
        }
        public IMusicSearchResult SearchMusic(string kwd)
        {
            return SearchKuwoMusic(kwd);
        }
        public IMvSearchResult SearchMv(string kwd)
        {
            return SearchKuwoMv(kwd);
        }
        public IPlaylistSearchResult SearchPlaylist(string kwd)
        {
            return SearchKuwoPlaylist(kwd);
        }
    }
}
