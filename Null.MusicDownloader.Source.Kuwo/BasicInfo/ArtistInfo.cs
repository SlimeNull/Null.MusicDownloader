using Null.MusicDownloader.Public.IBasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Source.Kuwo.BasicInfo
{
    public class ArtistInfoPackage : NetPackage
    {
        public ArtistInfo data { get; set; }
    }
    public class ArtistInfo : IArtistInfo
    {
        public string birthday { get; set; }
        public string country { get; set; }
        public int artistFans { get; set; }
        public int albumNum { get; set; }
        public string gener { get; set; }
        public string weight { get; set; }
        public string language { get; set; }
        public int mvNum { get; set; }
        public string pic { get; set; }
        public string upPcUrl { get; set; }
        public int musicNum { get; set; }
        public string pic120 { get; set; }
        public int isStar { get; set; }
        public string birthplace { get; set; }
        public string constellation { get; set; }
        public string content_type { get; set; }
        public string aartist { get; set; }
        public string name { get; set; }
        public string pic70 { get; set; }
        public int id { get; set; }
        public string tall { get; set; }
        public string pic300 { get; set; }
        public string info { get; set; }

        public string Name { get => name; }
        public string ArtistId { get => id.ToString(); }
        public string ImageUrl { get => pic; }
    }
}
