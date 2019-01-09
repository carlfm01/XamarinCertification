using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using MyTunes.Shared.Portable;

namespace MyTunes
{
    public static class SongLoader
    {
        const string Filename = "songs.json";
        public static IStreamLoader Loader { get; set; }
        public static async Task<IEnumerable<Song>> Load()
        {
            using (var reader = new StreamReader(OpenData()))
            {
                var songs = JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
                foreach (var song in songs) { song.Name = song.Name.RuinSongName(); }
                return songs;
            }
        }

        private static Stream OpenData()
        {
            if (Loader == null)
            {
                throw new Exception("Must set platform Loader before calling Load.");
            }
            return Loader.GetStreamForFilename(Filename);
        }
    }
}

