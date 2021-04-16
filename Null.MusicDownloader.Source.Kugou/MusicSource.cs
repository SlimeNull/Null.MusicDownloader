using Newtonsoft.Json;
using Null.MusicDownloader.Public.Library;
using Null.MusicDownloader.Source.Kugou.SearchResult;
using System;
using System.Net;

namespace Null.MusicDownloader.Source.Kugou
{
    public class MusicSource
    {
        public MusicSearchResult SearchKugouMusic(string kwd, int page, int range)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchMusic(kwd, page, range);

            return JsonConvert.DeserializeObject<MusicSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public AlbumSearchResult SearchKugouAlbum(string kwd, int page, int range)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchMusic(kwd, page, range);

            return JsonConvert.DeserializeObject<AlbumSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MvSearchResult SearchKugouMv(string kwd, int page, int range)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchMusic(kwd, page, range);

            return JsonConvert.DeserializeObject<MvSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
    }
}
