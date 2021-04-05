using System;
using System.IO;

namespace Null.MusicDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Source.Kuwo.MusicSource musicSource = new Source.Kuwo.MusicSource();

            Console.WriteLine("歌曲搜索测试:");
            Public.ISearchResult.IMusicSearchResult result = musicSource.SearchMusic("溯");
            foreach (var i in result.MusicInfos)
                Console.WriteLine($"{i.MusicName} - {i.ArtistName}");

            //Console.WriteLine("歌曲下载测试:");
            //using (FileStream save = File.OpenWrite(@"C:\Users\Null\Desktop\qwq.mp3"))
            //{
            //    musicSource.DownloadMusic(result.MusicInfos[0], save);
            //}

            Console.WriteLine("歌曲信息获取测试");
            Source.Kuwo.BasicInfo.MusicInfo musicInfo = musicSource.RequestKuwoMusicInfo(result.MusicInfos[0].MusicId);
            Console.WriteLine($"{musicInfo.MusicName} of {musicInfo.MusicId} - {musicInfo.ArtistName} of {musicInfo.ArtistId}");

            Console.WriteLine("歌单搜索测试:");
            Public.ISearchResult.IPlaylistSearchResult playlistSearchResult = musicSource.SearchPlaylist("future bass");
            foreach (var i in playlistSearchResult.PlaylistInfos)
                Console.WriteLine($"{i.Name} - ID:{i.PlaylistId}");

            Console.WriteLine("歌单信息获取测试:");
            Source.Kuwo.BasicInfo.PlaylistInfo playlistInfo = musicSource.RequestKuwoPlaylistInfo(playlistSearchResult.PlaylistInfos[0].PlaylistId);
            Console.WriteLine($"{playlistInfo.Name} - UName:{playlistInfo.uname}");

            Console.ReadLine();
        }
    }
}
