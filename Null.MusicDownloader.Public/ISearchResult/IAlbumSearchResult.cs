using Null.MusicDownloader.Public.IBasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.ISearchResult
{
    public interface IAlbumSearchResult : ISearchResult
    {
        IList<IAlbumInfo> AlbumInfos { get; }
    }
}
