using Null.MusicDownloader.Public;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Null.MusicDownloader.Module
{
    class SourceInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public Assembly SourceAssembly { get; set; }
        public Type SourceType { get; set; }
    }
}
