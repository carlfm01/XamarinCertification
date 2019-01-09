namespace MyTunes
{
    public static class SongExtensions
    {
        public static string RuinSongName(this string songName)
        {
            return songName.Replace("Crocodile", "Alligator");
        }
    }
}
