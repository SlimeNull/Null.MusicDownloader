using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Source.Kuwo.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kuwo.BasicInfo
{
    public class AlbumInfo : IAlbumInfo
    {
        public int playCnt { get; set; }
        public string artist { get; set; }
        public string releaseDate { get; set; }
        public string album { get; set; }
        public int albumid { get; set; }
        public int pay { get; set; }
        public int artistid { get; set; }
        public string pic { get; set; }
        public int isstar { get; set; }
        public int total { get; set; }
        public string content_type { get; set; }
        public string albuminfo { get; set; }
        public string lang { get; set; }
        public MusicInfo[] musicList { get; set; }

        public string Name { get => album; }
        public string AlbumId { get => albumid.ToString(); }
        public string CoverUrl { get => pic; }
    }

    public class AlbumInfoPackage : NetPackage
    {
        public AlbumInfo data { get; set; }
    }
}
