using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kugou
{
    public class NetPackage
    {
        public int status { get; set; }
        public string error { get; set; }

        public int errcode { get; set; }
    }
}
