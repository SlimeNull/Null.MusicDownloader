using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Netease.BasicInfo
{
    public class ArtistInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picUrl { get; set; }
        public string[] alias { get; set; }
        public int albumSize { get; set; }
        public long picId { get; set; }
        public string img1v1Url { get; set; }
        public int img1v1 { get; set; }
        public string[] alia { get; set; }
        public object trans { get; set; }
        public int accountId { get; set; }

        public int mvSize { get; set; }
        public bool followed { get; set; }

        public int img1v1Id { get; set; }
        public string briefDesc { get; set; }
        public int musicSize { get; set; }
        public string picId_str { get; set; }
    }
}
