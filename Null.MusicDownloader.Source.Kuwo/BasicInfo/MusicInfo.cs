using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Source.Kuwo.Public;

namespace Null.MusicDownloader.Source.Kuwo.BasicInfo
{
    public class MusicInfoPackage : NetPackage
    {
        public MusicInfo data { get; set; }
    }
    public class MusicInfo : IMusicInfo
    {
        public string musicrid { get; set; }
        public string barrage { get; set; }
        public string artist { get; set; }
        public MvPayinfo mvpayinfo { get; set; }
        public string pic { get; set; }
        public int isstar { get; set; }
        public int rid { get; set; }
        public string upPcStr { get; set; }
        public int duration { get; set; }
        public string score100 { get; set; }
        public string content_type { get; set; }
        public int mvPlayCnt { get; set; }
        public int track { get; set; }
        public string hasLossless { get; set; }
        public int hasmv { get; set; }
        public string releaseDate { get; set; }
        public string album { get; set; }
        public int albumid { get; set; }
        public string pay { get; set; }
        public int artistid { get; set; }
        public string albumpic { get; set; }
        public int originalsongtype { get; set; }
        public string songTimeMinutes { get; set; }
        public string isListenFee { get; set; }
        public string mvUpPcStr { get; set; }
        public string pic120 { get; set; }
        public string albuminfo { get; set; }
        public string name { get; set; }
        public int online { get; set; }
        public PayInfo payInfo { get; set; }
        public string nationid { get; set; }

        public string MusicName => name;
        public string AlbumName => album;
        public string ArtistName => artist;
        public string MusicId => rid.ToString();
        public string AlbumId => albumid.ToString();
        public string ArtistId => artistid.ToString();
        public string MusicCoverUrl => pic;
        public string AlbumCoverUrl => albumpic;
        public string MusicDuration => songTimeMinutes;
    }
}
