using System.IO;
using Android.Content;
using MyTunes.Shared.Portable;

namespace MyTunes
{
    class StreamLoader : IStreamLoader
    {
        private readonly Context _context;
        public StreamLoader(Context context) => _context = context;
        public Stream GetStreamForFilename(string filename) => _context.Assets.Open(filename);
    }
}