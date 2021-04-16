using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Netease.BasicInfo
{
    public class MvInfo
    {
        public string coverUrl { get; set; }
        public string title { get; set; }
        public int durationms { get; set; }
        public int playTime { get; set; }
        public int type { get; set; }
        public ArtistInfo[] creator { get; set; }
        public object aliaName { get; set; }
        public object transName { get; set; }
        public string vid { get; set; }
        public int?[] markTypes { get; set; }
        public string alg { get; set; }
    }
}
