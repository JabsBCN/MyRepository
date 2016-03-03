namespace CleanCode.FileManteneinance
{
    internal static class Program
    {

        static void Main(string[] args)
        {
            var filePathShortered = new FilePathShortener();
            filePathShortered.ShortenFilePaths();
        }
    }
}
