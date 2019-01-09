namespace MyTunes.Shared.Portable
{
    public interface IStreamLoader
    {
        System.IO.Stream GetStreamForFilename(string filename);
    }
}
