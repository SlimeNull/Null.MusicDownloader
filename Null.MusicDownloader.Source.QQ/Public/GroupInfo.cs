using Null.MusicDownloader.Source.Qq.BasicInfo;
using Null.MusicDownloader.Source.Qq.SearchResult;

namespace Null.MusicDownloader.Source.Qq.Public
{
    public class GroupInfo
    {
        public ActionInfo action { get; set; }
        public AlbumInfo album { get; set; }
        public int chinesesinger { get; set; }
        public string desc { get; set; }
        public string desc_hilight { get; set; }
        public string docid { get; set; }
        public string es { get; set; }
        public FormatInfo file { get; set; }
        public int fnote { get; set; }
        public int genre { get; set; }
        public int id { get; set; }
        public int index_album { get; set; }
        public int index_cd { get; set; }
        public int interval { get; set; }
        public int isonly { get; set; }
        public Song ksong { get; set; }
        public int language { get; set; }
        public string lyric { get; set; }
        public string lyric_hilight { get; set; }
        public string mid { get; set; }
        public MvInfo mv { get; set; }
        public string name { get; set; }
        public int newStatus { get; set; }
        public long nt { get; set; }
        public int ov { get; set; }
        public PayInfo pay { get; set; }
        public int pure { get; set; }
        public int sa { get; set; }
        public BasicInfo.ArtistInfo[] singer { get; set; }
        public int status { get; set; }
        public string subtitle { get; set; }
        public int t { get; set; }
        public int tag { get; set; }
        public int tid { get; set; }
        public string time_public { get; set; }
        public string title { get; set; }
        public string title_hilight { get; set; }
        public int type { get; set; }
        public string url { get; set; }
        public int ver { get; set; }
        public VolumeInfo volume { get; set; }
    }
}
