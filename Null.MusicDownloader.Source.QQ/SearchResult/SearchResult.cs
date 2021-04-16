using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Public.ISearchResult;

namespace Null.MusicDownloader.Source.Qq.SearchResult
{
    public abstract class SearchResult : ISearchResult
    {
        public abstract int DataTotal { get; }
        public abstract int ResultTotal { get; }

    }
}
