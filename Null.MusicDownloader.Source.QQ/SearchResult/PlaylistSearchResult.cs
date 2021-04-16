using Null.MusicDownloader.Source.Qq.BasicInfo;
using Null.MusicDownloader.Source.Qq.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Qq.SearchResult
{

    public class PlaylistSearchResultPackage : NetPackage
    {
        public PlaylistSearchResult data { get; set; }
    }

    public class PlaylistSearchResult
    {
        public int display_num { get; set; }
        public PlaylistInfo[] list { get; set; }
        public int num_per_page { get; set; }
        public int page_no { get; set; }
        public object[] qc { get; set; }
        public int sum { get; set; }
        public int uin { get; set; }
    }
}
