using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Source.Netease.BasicInfo;
using Null.MusicDownloader.Source.Netease.Public;

namespace Null.MusicDownloader.Source.Netease.SearchResult
{
    public class MvSearchResultPackage : NetPackage
    {
        public MvSearchResult result { get; set; }
    }
    public class MvSearchResult
    {
        public int videoCount { get; set; }
        public MvInfo[] videos { get; set; }
    }
}
