using Newtonsoft.Json;
using Null.MusicDownloader.Public.Library;
using Null.MusicDownloader.Source.Qq.BasicInfo;
using Null.MusicDownloader.Source.Qq.SearchResult;
using System;
using System.Net;

namespace Null.MusicDownloader.Source.Qq
{
    public class MusicSource
    {
        public MusicSearchResult SearchQqMusic(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchQqMusic(kwd, page, range);

            return JsonConvert.DeserializeObject<MusicSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public AlbumSearchResult SearchQqAlbum(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchAlbum(kwd, page, range);

            return JsonConvert.DeserializeObject<AlbumSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MvSearchResult SearchQqMv(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchMv(kwd, page, range);

            return JsonConvert.DeserializeObject<MvSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
    }
}
