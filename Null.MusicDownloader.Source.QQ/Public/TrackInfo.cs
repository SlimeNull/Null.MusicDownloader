using Null.MusicDownloader.Source.Qq.BasicInfo;
using Null.MusicDownloader.Source.Qq.Public;
using Null.MusicDownloader.Source.Qq.SearchResult;

namespace Null.MusicDownloader.Source.QQ.Public
{
    public class TrackInfo
    {
        public int id { get; set; }
        public int type { get; set; }
        public string mid { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public ArtistInfo[] singer { get; set; }
        public AlbumInfo album { get; set; }
        public MvInfo mv { get; set; }
        public int interval { get; set; }
        public int isonly { get; set; }
        public int language { get; set; }
        public int genre { get; set; }
        public int index_cd { get; set; }
        public int index_album { get; set; }
        public string time_public { get; set; }
        public int status { get; set; }
        public int fnote { get; set; }
        public FileFormatInfo file { get; set; }
        public PayInfo pay { get; set; }
        public ActionInfo action { get; set; }
        public Song ksong { get; set; }
        public VolumeInfo volume { get; set; }
        public string label { get; set; }
        public string url { get; set; }
        public int bpm { get; set; }
        public int version { get; set; }
        public string trace { get; set; }
        public int data_type { get; set; }
        public int modify_stamp { get; set; }
        public string pingpong { get; set; }
        public string ppurl { get; set; }
        public int tid { get; set; }
        public int ov { get; set; }
        public int sa { get; set; }
        public string es { get; set; }
    }

}
