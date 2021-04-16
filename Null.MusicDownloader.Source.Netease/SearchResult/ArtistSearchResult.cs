using Null.MusicDownloader.Source.Netease.BasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Netease.SearchResult
{
    public class ArtistSearchResultPackage : NetPackage
    {
        public ArtistSearchResult result { get; set; }
    }
    public class ArtistSearchResult
    {
        public int artistCount { get; set; }
        public ArtistInfo[] artists { get; set; }
    }
}
