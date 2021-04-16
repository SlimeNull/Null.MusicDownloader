using Newtonsoft.Json;
using Null.MusicDownloader.Public.Library;
using Null.MusicDownloader.Source.Netease.SearchResult;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Null.MusicDownloader.Source.Netease
{
    public class MusicSource
    {
        public MusicSearchResult SearchNeteaseMusic(string kwd, int offset = 0, int limit = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchMusicByKey(kwd, offset, limit);

            string json = RequestHelper.GetResponseText(request);
            return JsonConvert.DeserializeObject<MusicSearchResultPackage>(
                json).result;
        }
    }
}
