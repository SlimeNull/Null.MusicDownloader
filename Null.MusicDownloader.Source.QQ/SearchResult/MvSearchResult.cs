using Null.MusicDownloader.Source.Qq.BasicInfo;
using Null.MusicDownloader.Source.Qq.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Qq.SearchResult
{

    public class MvSearchResultPackage : NetPackage
    {
        public MvSearchResult data { get; set; }
    }

    public class MvSearchResult
    {
        public string keyword { get; set; }
        public Mv mv { get; set; }
        public int priority { get; set; }
        public object[] qc { get; set; }
        public int tab { get; set; }
        public object[] taglist { get; set; }
        public int totaltime { get; set; }
        public Zhida zhida { get; set; }
    }

    public class Mv
    {
        public int curnum { get; set; }
        public int curpage { get; set; }
        public MvInfo[] list { get; set; }
        public int totalnum { get; set; }
    }
}
