using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kuwo
{
    public class NetPackage
    {
        public int code { get; set; }
        public bool success { get; set; }
        public long curTime { get; set; }
        public string msg { get; set; }
        public string url { get; set; }
        public string profileId { get; set; }
        public string reqId { get; set; }
        public string tId { get; set; }
    }
}
