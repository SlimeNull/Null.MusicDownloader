using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using Null.MusicDownloader.Source.Kuwo.BasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kuwo.SearchResult
{
    public class AlbumSearchResult : IAlbumSearchResult
    {
        public string total { get; set; }
        public AlbumInfo[] albumList { get; set; }

        public int DataTotal { get => int.TryParse(total, out int result) ? result : 0; }
        public int ResultTotal { get => albumList.Length; }
        public IList<IAlbumInfo> AlbumInfos => albumList;
    }

    public class AlbumSearchResultPackage : NetPackage
    {
        public AlbumSearchResult data { get; set; }
    }
}
