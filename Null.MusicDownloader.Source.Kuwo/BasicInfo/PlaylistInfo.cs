using Null.MusicDownloader.Public.IBasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kuwo.BasicInfo
{
    public class PlaylistInfoPackage : NetPackage
    {
        public PlaylistInfo data { get; set; }
    }
    public class PlaylistInfo : IPlaylistInfo
    {
        public string img { get; set; }
        public string uPic { get; set; }
        public string uname { get; set; }
        public string img700 { get; set; }
        public string img300 { get; set; }
        public string userName { get; set; }
        public string img500 { get; set; }
        public int isOfficial { get; set; }
        public int total { get; set; }
        public string name { get; set; }
        public int listencnt { get; set; }
        public string id { get; set; }
        public string tag { get; set; }
        public MusicInfo[] musicList { get; set; }
        public string desc { get; set; }
        public string info { get; set; }

        public string Name { get => name; }
        public string PlaylistId { get => id.ToString(); }
        public string CoverUrl { get => img; }
    }
}
