using System;
using System.Collections.Generic;
using System.IO;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;

namespace Null.MusicDownloader.Public
{
    public interface IMusicSource
    {
        IAlbumSearchResult SearchAlbum(string kwd);
        IArtistSearchResult SearchArtist(string kwd);
        IMusicSearchResult SearchMusic(string kwd);
        IMvSearchResult SearchMv(string kwd);
        IPlaylistSearchResult SearchPlaylist(string kwd);
        IMergedSearchResult SearchAll(string kwd);

        IMusicInfo RequestMusicInfo(string id);
        IArtistInfo RequestArtistInfo(string id);
        IAlbumInfo RequestAlbumInfo(string id);
        IMvInfo RequestMvInfo(string id);
        IPlaylistInfo RequestPlaylistInfo(string id);

        Stream DownloadMusic(IMusicInfo music);
    }
}
