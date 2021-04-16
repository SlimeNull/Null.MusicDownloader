using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Null.MusicDownloader.Public;
using Null.MusicDownloader.Public.Library;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using Null.MusicDownloader.Source.Kuwo.SearchResult;
using Null.MusicDownloader.Source.Kuwo.BasicInfo;

namespace Null.MusicDownloader.Source.Kuwo
{
    public class MusicSource : IMusicSource
    {
        public string GetKuwoMusicUrl(string id, string format = "mp3", string br = "128kmp3")
        {
            HttpWebRequest request = MusicSourceLinks.GenUrl(id, format, br);

            return JsonConvert.DeserializeObject<NetPackage>(
                RequestHelper.GetResponseText(request)).url;
        }
        public Stream DownloadKuwoMusic(MusicInfo music)
        {
            HttpWebRequest download = RequestHelper.CreateGetRequest(GetKuwoMusicUrl(music.rid.ToString()));
            return RequestHelper.GetResponseStream(download);
        }
        public AlbumInfo GetKuwoAlbumInfo(string id)
        {
            HttpWebRequest request = MusicSourceLinks.GenGetAlbumInfo(id, 1, int.MaxValue);

            return JsonConvert.DeserializeObject<AlbumInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public ArtistInfo GetKuwoArtistInfo(string id)
        {
            HttpWebRequest request = MusicSourceLinks.GenGetArtistInfo(id);

            return JsonConvert.DeserializeObject<ArtistInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MusicInfo GetKuwoMusicInfo(string id)
        {
            HttpWebRequest request = MusicSourceLinks.GenGetMusicInfo(id);

            return JsonConvert.DeserializeObject<MusicInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MvInfo GetKuwoMvInfo(string id)
        {
            throw new NotSupportedException();
        }
        public PlaylistInfo GetKuwoPlaylistInfo(string id, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenGetPlaylistInfo(id, page, range);

            return JsonConvert.DeserializeObject<PlaylistInfoPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public AlbumSearchResult SearchKuwoAlbum(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchAlbumByKey(kwd, page, range);

            return JsonConvert.DeserializeObject<AlbumSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MergedSearchResult SearchKuwoAll(string kwd, int page = 1, int range = 30)
        {
            throw new NotImplementedException();
        }
        public ArtistSearchResult SearchKuwoArtist(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenGetSearchArtist(kwd, page, range);

            return JsonConvert.DeserializeObject<ArtistSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MusicSearchResult SearchKuwoMusic(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchMusicByKey(kwd, page, range);

            return JsonConvert.DeserializeObject<MusicSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public MvSearchResult SearchKuwoMv(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchMvByKey(kwd, page, range);

            return JsonConvert.DeserializeObject<MvSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }
        public PlaylistSearchResult SearchKuwoPlaylist(string kwd, int page = 1, int range = 30)
        {
            HttpWebRequest request = MusicSourceLinks.GenSearchPlaylistByKey(kwd, page, range);

            return JsonConvert.DeserializeObject<PlaylistSearchResultPackage>(
                RequestHelper.GetResponseText(request)).data;
        }

        public IAlbumInfo RequestAlbumInfo(string id)
        {
            return GetKuwoAlbumInfo(id);
        }
        public IArtistInfo RequestArtistInfo(string id)
        {
            return GetKuwoArtistInfo(id);
        }
        public IMusicInfo RequestMusicInfo(string id)
        {
            return GetKuwoMusicInfo(id);
        }
        public IMvInfo RequestMvInfo(string id)
        {
            return GetKuwoMvInfo(id);
        }
        public IPlaylistInfo RequestPlaylistInfo(string id)
        {
            return GetKuwoPlaylistInfo(id);
        }
        public IAlbumSearchResult SearchAlbum(string kwd)
        {
            return SearchKuwoAlbum(kwd);
        }
        public IMergedSearchResult SearchAll(string kwd)
        {
            return SearchKuwoAll(kwd);
        }
        public IArtistSearchResult SearchArtist(string kwd)
        {
            return SearchKuwoArtist(kwd);
        }
        public IMusicSearchResult SearchMusic(string kwd)
        {
            return SearchKuwoMusic(kwd);
        }
        public IMvSearchResult SearchMv(string kwd)
        {
            return SearchKuwoMv(kwd);
        }
        public IPlaylistSearchResult SearchPlaylist(string kwd)
        {
            return SearchKuwoPlaylist(kwd);
        }

        public Stream DownloadMusic(IMusicInfo music)
        {
            return DownloadKuwoMusic(music as MusicInfo);
        }
    }
}
