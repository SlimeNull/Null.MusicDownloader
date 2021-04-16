using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Netease.BasicInfo
{
    public class AlbumInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public ArtistInfo artist { get; set; }
        public long publishTime { get; set; }
        public int size { get; set; }
        public int copyrightId { get; set; }
        public int status { get; set; }
        public long picId { get; set; }
        public int mark { get; set; }
        public string[] alia { get; set; }

        public string type { get; set; }
        public string blurPicUrl { get; set; }
        public int companyId { get; set; }
        public long pic { get; set; }
        public string picUrl { get; set; }
        public string description { get; set; }
        public string tags { get; set; }
        public string company { get; set; }
        public string briefDesc { get; set; }
        public object[] songs { get; set; }
        public object[] alias { get; set; }
        public string commentThreadId { get; set; }
        public ArtistInfo[] artists { get; set; }
        public string picId_str { get; set; }
        public bool isSub { get; set; }
    }
}
