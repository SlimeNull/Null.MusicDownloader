using System;
using System.Collections.Generic;
using System.Text;

namespace Null.MusicDownloader.Public.IBasicInfo
{
    public interface IArtistInfo
    {
        string Name { get; }
        string ArtistId { get; }
        string ImageUrl { get; }
    }
}
