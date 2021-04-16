using Null.MusicDownloader.Source.Netease.BasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Netease.SearchResult
{
    public class MusicSearchResultPackage : NetPackage
    {
        public MusicSearchResult result { get; set; }
    }
    public class MusicSearchResult
    {
        public MusicInfo[] songs { get; set; }
        public int songCount { get; set; }
    }
}
