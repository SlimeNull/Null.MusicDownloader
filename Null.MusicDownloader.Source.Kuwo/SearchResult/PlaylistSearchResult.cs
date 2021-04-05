using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using Null.MusicDownloader.Source.Kuwo.BasicInfo;

namespace Null.MusicDownloader.Source.Kuwo.SearchResult
{
    public class PlaylistSearchResultPackage : NetPackage
    {
        public PlaylistSearchResult data { get; set; }
    }
    public class PlaylistSearchResult : IPlaylistSearchResult
    {
        public string total { get; set; }
        public PlaylistInfo[] list { get; set; }

        public int DataTotal { get => int.TryParse(total, out int result) ? result : 0; }
        public int ResultTotal { get => list.Length; }
        public IList<IPlaylistInfo> PlaylistInfos => list;
    }
}
