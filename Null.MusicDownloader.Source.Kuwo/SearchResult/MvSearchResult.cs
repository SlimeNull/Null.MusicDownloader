using System;
using System.Collections.Generic;
using System.Text;
using Null.MusicDownloader.Public.IBasicInfo;
using Null.MusicDownloader.Public.ISearchResult;
using Null.MusicDownloader.Source.Kuwo.BasicInfo;

namespace Null.MusicDownloader.Source.Kuwo.SearchResult
{
    public class MvSearchResultPackage : NetPackage
    {
        public MvSearchResult data { get; set; }
    }
    public class MvSearchResult : IMvSearchResult
    {
        public string total { get; set; }
        public MvInfo[] mvlist { get; set; }

        public int DataTotal { get => int.TryParse(total, out int result) ? result : 0; }
        public int ResultTotal { get => mvlist.Length; }
        public IList<IMvInfo> MvInfos { get => mvlist; }
    }
}
