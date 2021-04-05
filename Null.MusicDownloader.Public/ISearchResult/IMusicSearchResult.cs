using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Public.IBasicInfo;

namespace Null.MusicDownloader.Public.ISearchResult
{
    public interface IMusicSearchResult : ISearchResult
    {
        IList<IMusicInfo> MusicInfos { get; }
    }
}
