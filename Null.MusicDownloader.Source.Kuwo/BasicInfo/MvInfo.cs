using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Public.IBasicInfo;

namespace Null.MusicDownloader.Source.Kuwo.BasicInfo
{
    public class MvInfo : IMvInfo
    {
        public int duration { get; set; }
        public string artist { get; set; }
        public int mvPlayCnt { get; set; }
        public string name { get; set; }
        public int online { get; set; }
        public int artistid { get; set; }
        public string songTimeMinutes { get; set; }
        public int id { get; set; }
        public string pic { get; set; }

        public string Name { get => name; }
        public string ImageUrl { get => pic; }
    }
}
