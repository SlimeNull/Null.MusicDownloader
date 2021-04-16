using Null.MusicDownloader.Source.QQ.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Qq.BasicInfo
{
    public class PlaylistInfo
    {
        public int copyrightnum { get; set; }
        public string createtime { get; set; }
        public CreatorInfo creator { get; set; }
        public int diss_status { get; set; }
        public string dissid { get; set; }
        public string dissname { get; set; }
        public long docid { get; set; }
        public string imgurl { get; set; }
        public string introduction { get; set; }
        public int listennum { get; set; }
        public float score { get; set; }
        public int song_count { get; set; }
    }
}
