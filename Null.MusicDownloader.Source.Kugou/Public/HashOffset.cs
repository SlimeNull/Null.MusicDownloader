namespace Null.MusicDownloader.Source.Kugou.Public
{
    public class HashOffset
    {
        public int file_type { get; set; }
        public int start_byte { get; set; }
        public int start_ms { get; set; }
        public string offset_hash { get; set; }
        public int end_ms { get; set; }
        public int end_byte { get; set; }
    }

}
