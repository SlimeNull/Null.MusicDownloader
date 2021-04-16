namespace Null.MusicDownloader.Source.Qq.BasicInfo
{
    public class MvInfo
    {
        public int id { get; set; }
        public string vid { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int vt { get; set; }

        public string docid { get; set; }
        public int duration { get; set; }
        public string msg { get; set; }
        public string mvName_hilight { get; set; }
        public string mv_pic_url { get; set; }
        public int pay { get; set; }
        public int play_count { get; set; }
        public string publish_date { get; set; }
        public string singerMID { get; set; }
        public string singerName_hilight { get; set; }
        public ArtistInfo[] singer_list { get; set; }
        public string singer_name { get; set; }
        public int singerid { get; set; }
        public int type { get; set; }
        public string uploader_nick { get; set; }
        public string uploader_uin { get; set; }
        public string v_id { get; set; }
        public int version { get; set; }
        public int video_switch { get; set; }

        public int mv_id { get => id; set => id = value; }
        public string mv_name { get => name; set => name = value; }
    }
}
