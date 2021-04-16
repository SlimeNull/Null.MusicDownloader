using Null.MusicDownloader.Source.Kugou.BasicInfo;
using Null.MusicDownloader.Source.Kugou.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kugou.SearchResult
{
    public class AlbumSearchResultPackage : NetPackage
    {
        public AlbumSearchResult data { get; set; }
    }

    public class AlbumSearchResult
    {
        public int timestamp { get; set; }
        public int correctionforce { get; set; }
        public int total { get; set; }
        public string correctiontip { get; set; }
        public AlbumInfo[] info { get; set; }
        public int correctiontype { get; set; }
    }
}
