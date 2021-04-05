using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.IBasicInfo
{
    public interface IAlbumInfo
    {
        string Name { get; }
        string AlbumId { get; }
        string CoverUrl { get; }
    }
}
