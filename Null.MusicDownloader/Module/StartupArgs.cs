using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Module
{
    class StartupArgs
    {
        public bool
            GetMusicInfo,
            GetAlbumInfo,
            GetArtistInfo,
            GetMvInfo,
            GetPlaylistInfo,
            SearchMusic,
            SearchAlbum,
            SearchArtist,
            SearchMv,
            SearchPlaylist,
            DownloadMusic,
            PlayMusic;
        public string
            Id,
            Keyword,
            Source,
            Path;
    }
}
