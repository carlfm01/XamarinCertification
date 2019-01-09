using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace MyTunes
{
    public static class SongLoader
	{
		const string Filename = "songs.json";

		public static async Task<IEnumerable<Song>> Load()
		{
			using (var reader = new StreamReader(OpenData())) {
				return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			}
		}

        private static Stream OpenData()
        {
            #if __ANDROID__
                return Android.App.Application.Context.Assets.Open(Filename);
            #elif __IOS__
                return File.OpenRead(Filename);
            #else
            // TODO: add code to open file here.
                return null;
            #endif
        }
    }
}

