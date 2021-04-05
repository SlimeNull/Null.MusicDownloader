using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.IBasicInfo
{
    public interface IPlaylistInfo
    {
        string Name { get; }
        string PlaylistId { get; }
        string CoverUrl { get; }
    }
}
