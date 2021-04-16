using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Source.Qq.Public;
using Null.MusicDownloader.Source.QQ.Public;

namespace Null.MusicDownloader.Source.Qq.BasicInfo
{

    public class MusicInfoPackage : NetPackage
    {
        public MusicInfoRePackage songinfo { get; set; }
    }

    public class MusicInfoRePackage
    {
        public int code { get; set; }
        public MusicInfo data { get; set; }
    }

    public class MusicInfo
    {
        public MusicInfoDetails info { get; set; }
        public MusicExtrasInfo extras { get; set; }
        public TrackInfo track_info { get; set; }
    }

    public class MusicInfoDetails
    {
        public CompanyInfo company { get; set; }
        public GenreInfo genre { get; set; }
        public LanguageInfo lan { get; set; }
        public PubTimeInfo pub_time { get; set; }
    }

    public class MusicExtrasInfo
    {
        public string name { get; set; }
        public string transname { get; set; }
        public string subtitle { get; set; }
        public string from { get; set; }
    }
}