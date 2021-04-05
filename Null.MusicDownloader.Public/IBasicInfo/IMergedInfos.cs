using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.IBasicInfo
{
    public interface IMergedInfos
    {
        ICollection<IAlbumInfo> AlbumInfos { get; }
        ICollection<IArtistInfo> ArtistInfos { get; }
        ICollection<IMusicInfo> MusicInfos { get; }
        ICollection<IMvInfo> MvInfos { get; }
        ICollection<IPlaylistInfo> PlaylistInfos { get; }
    }
}
