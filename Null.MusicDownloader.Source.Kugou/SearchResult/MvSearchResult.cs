using Null.MusicDownloader.Source.Kugou.BasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kugou.SearchResult
{
    public class MvSearchResultPackage : NetPackage
    {
        public MvSearchResult data { get; set; }
    }

    public class MvSearchResult
    {
        public int timestamp { get; set; }
        public MvInfo[] info { get; set; }
        public int total { get; set; }
        public int istag { get; set; }
        public int istagresult { get; set; }
        public object[] aggregation { get; set; }
    }

}
