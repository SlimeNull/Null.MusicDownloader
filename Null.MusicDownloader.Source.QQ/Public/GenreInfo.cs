using Null.MusicDownloader.Source.Qq.Public;

namespace Null.MusicDownloader.Source.QQ.Public
{
    public class GenreInfo
    {
        public string title { get; set; }
        public string type { get; set; }
        public ContentInfo[] content { get; set; }
        public int pos { get; set; }
        public int more { get; set; }
        public string selected { get; set; }
        public int use_platform { get; set; }
    }

}
