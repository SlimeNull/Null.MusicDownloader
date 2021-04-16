using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Qq
{
    public class NetPackage
    {
        public int code { get; set; }
        public string message { get; set; }
        public string notice { get; set; }
        public int subcode { get; set; }
        public int time { get; set; }
        public string tips { get; set; }
        public long ts { get; set; }
        public long start_ts { get; set; }

        public int _default { get; set; }
    }
}
