using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using Null.MusicDownloader.Source.Kuwo.BasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kuwo.SearchResult
{
    public class ArtistSearchResultPackage : NetPackage
    {
        public ArtistSearchResult data { get; set; }
    }
    public class ArtistSearchResult : IArtistSearchResult
    {
        public string total { get; set; }
        public int rn { get; set; }
        public ArtistInfo[] list { get; set; }
        public ArtistInfo[] artistList { get; set; }
        public int pn { get; set; }

        public int DataTotal { get => int.TryParse(total, out int result) ? result : 0; }
        public int ResultTotal { get => list.Length; }
        public IList<IArtistInfo> ArtistInfos { get => list; }
    }
}
