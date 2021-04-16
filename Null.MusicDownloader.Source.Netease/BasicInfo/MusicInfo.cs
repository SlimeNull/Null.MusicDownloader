using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Public.IBasicInfo;

namespace Null.MusicDownloader.Source.Netease.BasicInfo
{
    public class MusicInfo : IMusicInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public ArtistInfo[] artists { get; set; }
        public AlbumInfo album { get; set; }
        public int duration { get; set; }
        public int copyrightId { get; set; }
        public int status { get; set; }
        public object[] alias { get; set; }
        public int rtype { get; set; }
        public int ftype { get; set; }
        public int mvid { get; set; }
        public int fee { get; set; }
        public object rUrl { get; set; }
        public int mark { get; set; }

        public string MusicName => name;

        public string AlbumName => album.name;

        public string ArtistName => string.Join("/", from artist in artists select artist.name);

        public string MusicId => id.ToString();

        public string AlbumId => album.id.ToString();

        public string ArtistId => string.Join("/", from artist in artists select artist.id);

        public string MusicCoverUrl => throw new NotImplementedException();

        public string AlbumCoverUrl => throw new NotImplementedException();

        public string MusicDuration => throw new NotImplementedException();
    }
}
