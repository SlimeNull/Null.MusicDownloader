using NAudio.Wave;
using Newtonsoft.Json;
using Null.MusicDownloader.Module;
using Null.MusicDownloader.Public;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using NullLib.ArgsParser;
using NullLib.ConsoleTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Null.MusicDownloader
{
    class Program
    {
        static ConfigInfo Config;
        static Dictionary<string, Type> MusicSources = new Dictionary<string, Type>();
        static StartupArgs startupArgs;

        static string DefaultSourceName = null;

        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("=== === === === === 音乐搜索测试 === === === === ===");
            Source.Qq.MusicSource qqSrc = new Source.Qq.MusicSource();
            Source.Qq.SearchResult.MusicSearchResult qqSearchMusicResult = qqSrc.SearchQqMusic("溯");
            foreach(var i in qqSearchMusicResult.song.list.Select(v =>
            {
                return $"{v.name} - {v.singer} - {v.desc}";
            }))
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("=== === === === === 专辑搜索测试 === === === === ===");
            Source.Qq.SearchResult.AlbumSearchResult albumSearchResult = qqSrc.SearchQqAlbum("Impossible");
            foreach (var i in albumSearchResult.album.list.Select(v =>
            {
                return $"{v.albumName} - {v.singerName} - {v.albumPic}";
            }))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=== === === === === MV搜索测试 === === === === ===");
            Source.Qq.SearchResult.MvSearchResult mvSearchResult = qqSrc.SearchQqMv("Faded");
            foreach (var i in mvSearchResult.mv.list.Select(v =>
            {
                return $"{v.mv_name} - {v.mv_id} - {v.publish_date}";
            }))
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
#endif


            InitializeApplication(args);
            IMusicSource musicSrc = null;

            Type musicSrcType = null;
            if (startupArgs.Source == null || !MusicSources.TryGetValue(startupArgs.Source, out musicSrcType))
                if (DefaultSourceName == null || !MusicSources.TryGetValue(DefaultSourceName, out musicSrcType))
                    ErrorExit("参数错误", "没有指定音乐源", -1);
            musicSrc = Activator.CreateInstance(musicSrcType) as IMusicSource;

            //try
            {
                if (startupArgs.GetMusicInfo)
                {
                    IMusicInfo musicInfo = musicSrc.RequestMusicInfo(startupArgs.Id);
                    IEnumerable<PropertyInfo> basicProps = typeof(IMusicInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = from prop in musicInfo.GetType().GetProperties() select prop;
                    GenTableInfo(basicProps, musicInfo, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, musicInfo, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.GetAlbumInfo)
                {
                    IAlbumInfo musicInfo = musicSrc.RequestAlbumInfo(startupArgs.Id);
                    IEnumerable<PropertyInfo> basicProps = typeof(IAlbumInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = from prop in musicInfo.GetType().GetProperties() select prop;
                    GenTableInfo(basicProps, musicInfo, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, musicInfo, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.GetArtistInfo)
                {
                    IArtistInfo artistInfo = musicSrc.RequestArtistInfo(startupArgs.Id);
                    IEnumerable<PropertyInfo> basicProps = typeof(IArtistInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = from prop in artistInfo.GetType().GetProperties() select prop;
                    GenTableInfo(basicProps, artistInfo, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, artistInfo, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.GetMvInfo)
                {
                    IMvInfo mvInfo = musicSrc.RequestMvInfo(startupArgs.Id);
                    IEnumerable<PropertyInfo> basicProps = typeof(IMvInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = from prop in mvInfo.GetType().GetProperties() select prop;
                    GenTableInfo(basicProps, mvInfo, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, mvInfo, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.GetPlaylistInfo)
                {
                    IPlaylistInfo playlistInfo = musicSrc.RequestPlaylistInfo(startupArgs.Id);
                    IEnumerable<PropertyInfo> basicProps = typeof(IPlaylistInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = playlistInfo.GetType().GetProperties();
                    GenTableInfo(basicProps, playlistInfo, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, playlistInfo, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.SearchMusic)
                {
                    IMusicSearchResult musicSearchResult = musicSrc.SearchMusic(startupArgs.Keyword);
                    IEnumerable<PropertyInfo> basicProps = typeof(IMusicInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = musicSearchResult.MusicInfos.FirstOrDefault().GetType().GetProperties();
                    GenTableInfo(basicProps, musicSearchResult.MusicInfos, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, musicSearchResult.MusicInfos, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.SearchAlbum)
                {
                    IAlbumSearchResult musicSearchResult = musicSrc.SearchAlbum(startupArgs.Keyword);
                    IEnumerable<PropertyInfo> basicProps = typeof(IMusicInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = musicSearchResult.AlbumInfos.FirstOrDefault().GetType().GetProperties();
                    GenTableInfo(basicProps, musicSearchResult.AlbumInfos, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, musicSearchResult.AlbumInfos, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.SearchArtist)
                {
                    IArtistSearchResult musicSearchResult = musicSrc.SearchArtist(startupArgs.Keyword);
                    IEnumerable<PropertyInfo> basicProps = typeof(IMusicInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = musicSearchResult.ArtistInfos.FirstOrDefault().GetType().GetProperties();
                    GenTableInfo(basicProps, musicSearchResult.ArtistInfos, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, musicSearchResult.ArtistInfos, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.SearchMv)
                {
                    IMvSearchResult musicSearchResult = musicSrc.SearchMv(startupArgs.Keyword);
                    IEnumerable<PropertyInfo> basicProps = typeof(IMusicInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = musicSearchResult.MvInfos.FirstOrDefault().GetType().GetProperties();
                    GenTableInfo(basicProps, musicSearchResult.MvInfos, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, musicSearchResult.MvInfos, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.SearchPlaylist)
                {
                    IPlaylistSearchResult musicSearchResult = musicSrc.SearchPlaylist(startupArgs.Keyword);
                    IEnumerable<PropertyInfo> basicProps = typeof(IMusicInfo).GetProperties();
                    IEnumerable<PropertyInfo> extraProps = musicSearchResult.PlaylistInfos.FirstOrDefault().GetType().GetProperties();
                    GenTableInfo(basicProps, musicSearchResult.PlaylistInfos, out ConsoleTable basicInfo);
                    GenTableInfo(extraProps, musicSearchResult.PlaylistInfos, out ConsoleTable extraInfo);
                    PrintTableInfo(basicInfo, extraInfo);
                }
                else if (startupArgs.DownloadMusic)
                {
                    IMusicInfo musicInfo = musicSrc.RequestMusicInfo(startupArgs.Id);
                    using (Stream stream = musicSrc.DownloadMusic(musicInfo))
                    {
                        using (FileStream fs = File.OpenWrite(startupArgs.Path))
                        {
                            stream.CopyTo(fs);
                        }
                    }
                    Console.WriteLine("> Download successful");
                }
                else if (startupArgs.PlayMusic)
                {
                    IMusicInfo musicInfo = musicSrc.RequestMusicInfo(startupArgs.Id);
                    using (Stream stream = musicSrc.DownloadMusic(musicInfo))
                    {
                        //using (FileStream fs = File.OpenWrite(Path.GetTempFileName()))
                        //{
                        //}
                        Mp3FileReader qwq = new Mp3FileReader(stream);
                        WaveOut wout = new WaveOut();
                        wout.Play();
                        while (wout.PlaybackState == PlaybackState.Playing)
                            Thread.Sleep(10);
                    }
                }
            }
            //catch (Exception ex)
            //{
            //    ErrorExit(ex.GetType().Name, ex.Message, -2);
            //}
        }
        static void InitializeApplication(string[] args)
        {
            LoadConfig();
            LoadSources();
            LoadArgs(args);
        }
        static void GenTableInfo(IEnumerable<PropertyInfo> props, IEnumerable<object> objs, out ConsoleTable table)
        {
            ConsoleTable result = new ConsoleTable(props.Select(v => v.Name).ToArray()) { TableMaximiumWidth = Console.WindowWidth - 1 };
            foreach (var i in objs)
                result.AddRow(props.Select(p => p.GetValue(i)).ToArray());
            table = result;
        }
        static void GenTableInfo(IEnumerable<PropertyInfo> props, object obj, out ConsoleTable table)
        {
            table = new ConsoleTable(props.Select(v => v.Name).ToArray()) { TableMaximiumWidth = Console.WindowWidth - 1 };
            table.AddRow(props.Select(v => v.GetValue(obj)).ToArray());
        }
        static void PrintTableInfo(ConsoleTable basicInfo, ConsoleTable extraInfo)
        {
            Console.WriteLine("BasicInfo:");
            try
            {
                Console.WriteLine(basicInfo.ToMarkdownString());
            }
            catch
            {
                Console.WriteLine("> Cannot print table");
            }
            Console.WriteLine("ExtraInfo:");
            try
            {
                Console.WriteLine(extraInfo.ToMarkdownString());
            }
            catch
            {
                Console.WriteLine("> Cannot print table");
            }
        }
        static void LoadArgs(string[] args)
        {
            Arguments arguments = new Arguments(
                new CommandLine("GetMusicInfo",
                    new FieldArgument("Id") { Alias = "MusicId" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("GetAlbumInfo",
                    new FieldArgument("Id") { Alias = "AlbumId" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("GetArtistInfo",
                    new FieldArgument("Id") { Alias = "ArtistId" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("GetMvInfo",
                    new FieldArgument("Id") { Alias = "MvId" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("GetPlaylistInfo",
                    new FieldArgument("Id") { Alias = "PlaylistId" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("SearchMusic",
                    new FieldArgument("Keyword") { Alias = "MusicKeyword" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("SearchAlbum",
                    new FieldArgument("Keyword") { Alias = "AlbumKeyword" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("SearchArtist",
                    new FieldArgument("Keyword") { Alias = "ArtistKeyword" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("SearchMv",
                    new FieldArgument("Keyword") { Alias = "MvKeyword" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("SearchPlaylist",
                    new FieldArgument("Keyword") { Alias = "PlaylistKeyword" },
                    new FieldArgument("Source") { Alias = "SourceName" }),
                new CommandLine("DownloadMusic",
                    new FieldArgument("Id") { Alias = "MusicId" },
                    new FieldArgument("Source") { Alias = "SourceName" },
                    new FieldArgument("Path") { Alias = "SavePath" }),
                new CommandLine("PlayMusic",
                    new FieldArgument("Id") { Alias = "MusicId" },
                    new FieldArgument("Source") { Alias = "SourceName" }))
            { IgnoreCase = true };
            arguments.Parse(args);
            startupArgs = arguments.ToObject<StartupArgs>();
        }
        static void LoadConfig()
        {
            Config = JsonConvert.DeserializeObject<ConfigInfo>(
                File.ReadAllText("./config.json"));
        }
        static void LoadSources()
        {
            for (int i = 0, len = Config.Sources.Length; i < len; i++)
                Config.Sources[i].SourceAssembly = Assembly.LoadFrom(Config.Sources[i].Path);
            for (int i = 0, len = Config.Sources.Length; i < len; i++)
            {
                SourceInfo info = Config.Sources[i];
                Type srcType = info.SourceAssembly.GetTypes().Where(v => typeof(IMusicSource).IsAssignableFrom(v)).First();
                MusicSources[info.Name] = srcType;
                if (info.IsDefault)
                    DefaultSourceName = info.Name;
            }
        }
        static void ErrorExit(string title, string description, int exitcode)
        {
            TextWriter error = Console.Error;
            error.WriteLine($"Exception:{title}");
            error.WriteLine($"    {description}");
            Environment.Exit(exitcode);
        }
    }
}
