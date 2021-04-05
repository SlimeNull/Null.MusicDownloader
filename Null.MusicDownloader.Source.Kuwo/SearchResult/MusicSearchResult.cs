using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using Null.MusicDownloader.Source.Kuwo.BasicInfo;

namespace Null.MusicDownloader.Source.Kuwo.SearchResult
{
    public class MusicSearchResult : IMusicSearchResult
    {
        public string total { get; set; }
        public MusicInfo[] list { get; set; }

        public int DataTotal => int.TryParse(total, out int result) ? result : -1;
        public int ResultTotal => list.Length;
        public IList<IMusicInfo> MusicInfos => list;
    }



    public class MusicSearchResultPackage : NetPackage
    {
        public MusicSearchResult data { get; set; }
    }
}