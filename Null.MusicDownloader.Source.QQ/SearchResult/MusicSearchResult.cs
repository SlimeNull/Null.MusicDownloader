using Null.MusicDownloader.Source.Qq.BasicInfo;
using Null.MusicDownloader.Source.Qq.Public;
using Null.MusicDownloader.Source.Qq.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Qq.SearchResult
{
    public class MusicSearchResultPackage : NetPackage
    {
        public MusicSearchResult data { get; set; }
    }
    public class MusicSearchResult
    {
        public string keyword { get; set; }
        public int priority { get; set; }
        public object[] qc { get; set; }
        public SemanticInfo semantic { get; set; }
        public Song song { get; set; }
        public int tab { get; set; }
        public object[] taglist { get; set; }
        public int totaltime { get; set; }
        public Zhida zhida { get; set; }
    }

    public class Song
    {
        public int curnum { get; set; }
        public int curpage { get; set; }
        public MusicInfo[] list { get; set; }
        public int totalnum { get; set; }
    }
}
