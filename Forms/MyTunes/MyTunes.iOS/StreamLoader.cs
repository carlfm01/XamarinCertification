using System.IO;
using MyTunes.Shared.Portable;

namespace MyTunes
{
    class StreamLoader : IStreamLoader
    {
        public Stream GetStreamForFilename(string filename) => File.OpenRead(filename);
    }
}