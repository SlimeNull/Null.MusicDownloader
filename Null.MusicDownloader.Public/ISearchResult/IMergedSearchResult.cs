using Null.MusicDownloader.Public.IBasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.ISearchResult
{
    public interface IMergedSearchResult : ISearchResult
    {
        IList<IAlbumSearchResult> AlbumSearchResults { get; }
        IList<IArtistSearchResult> ArtistSearchResults { get; }
        IList<IMusicSearchResult> MusicSearchResults { get; }
        IList<IMvSearchResult> MvSearchResults { get; }
        IList<IPlaylistSearchResult> PlaylistSearchResults { get; }

        IMergedInfos ToInfos();
    }
}
