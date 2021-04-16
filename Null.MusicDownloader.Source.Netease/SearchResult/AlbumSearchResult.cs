using Null.MusicDownloader.Source.Netease.BasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Netease.SearchResult
{
    public class AlbumSearchResultPackage : NetPackage
    {
        public AlbumSearchResult result { get; set; }
    }
    public class AlbumSearchResult
    {
        public AlbumInfo[] albums { get; set; }
        public int albumCount { get; set; }
    }
}
