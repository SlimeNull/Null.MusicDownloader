using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.ISearchResult
{
    public interface ISearchResult
    {
        int DataTotal { get; }
        int ResultTotal { get; }
    }
}
