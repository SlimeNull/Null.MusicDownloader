using System;
using System.Collections;
using System.Collections.Generic;

namespace Null.MusicDownloader.Public.IBasicInfo
{
    public interface IMusicInfo
    {
        string MusicName { get; }
        string AlbumName { get; }
        string ArtistName { get; }
        string MusicId { get; }
        string AlbumId { get; }
        string ArtistId { get; }

        string MusicCoverUrl { get; }
        string AlbumCoverUrl { get; }

        string MusicDuration { get; }
    }
}
