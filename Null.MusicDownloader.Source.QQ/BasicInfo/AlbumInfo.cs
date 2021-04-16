namespace Null.MusicDownloader.Source.Qq.BasicInfo
{
    public class AlbumInfo
    {
        public int id { get; set; }
        public string mid { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string time_public { get; set; }
        public string pmid { get; set; }

        public string albumName_hilight { get; set; }
        public string albumPic { get; set; }
        public string catch_song { get; set; }
        public string docid { get; set; }
        public string publicTime { get; set; }
        public int singerID { get; set; }
        public string singerMID { get; set; }
        public string singerName { get; set; }
        public string singerName_hilight { get; set; }
        public ArtistInfo[] singer_list { get; set; }
        public int song_count { get; set; }
        public int type { get; set; }

        public int albumID { get => id; set => id = value; }
        public string albumMID { get => mid; set => mid = value; }
        public string albumName { get => name; set => name = value; }
    }

}
