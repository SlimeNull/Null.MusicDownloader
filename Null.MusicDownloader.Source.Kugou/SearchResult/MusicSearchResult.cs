using Null.MusicDownloader.Source.Kugou.BasicInfo;
using Null.MusicDownloader.Source.Kugou.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kugou.SearchResult
{
    public class MusicSearchResultPackage : NetPackage
    {
        public MusicSearchResult data { get; set; }
    }

    public class MusicSearchResult
    {
        public Aggregation[] aggregation { get; set; }
        public string tab { get; set; }
        public MusicInfo[] info { get; set; }
        public int correctiontype { get; set; }
        public int timestamp { get; set; }
        public int allowerr { get; set; }
        public int total { get; set; }
        public int istag { get; set; }
        public int istagresult { get; set; }
        public int forcecorrection { get; set; }
        public string correctiontip { get; set; }
    }
}
