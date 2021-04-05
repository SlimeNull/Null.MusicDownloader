using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kuwo.SearchResult
{
    public class MergedSearchResultPackage : NetPackage
    {
        public MergedSearchResult data { get; set; }
    }
    public class MergedSearchResult : IMergedSearchResult
    {
        public IList<IAlbumSearchResult> AlbumSearchResults => throw new NotImplementedException();

        public IList<IArtistSearchResult> ArtistSearchResults => throw new NotImplementedException();

        public IList<IMusicSearchResult> MusicSearchResults => throw new NotImplementedException();

        public IList<IMvSearchResult> MvSearchResults => throw new NotImplementedException();

        public IList<IPlaylistSearchResult> PlaylistSearchResults => throw new NotImplementedException();

        public int DataTotal => throw new NotImplementedException();

        public int ResultTotal => throw new NotImplementedException();

        public IMergedInfos ToInfos()
        {
            throw new NotImplementedException();
        }
    }
}
