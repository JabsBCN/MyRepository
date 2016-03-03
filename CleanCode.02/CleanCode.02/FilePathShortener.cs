namespace CleanCode.FileManteneinance
{
    using System;
    using System.IO;
    using System.Threading;

    public class FilePathShortener
    {
        private readonly FoldersRenamer foldersRenamer;
        private readonly FoldersRemover foldersRemover;
        private string[] folderPaths;

        public FilePathShortener()
        {
            this.foldersRenamer = new FoldersRenamer();
            this.foldersRemover = new FoldersRemover();
        }

        public void ShortenFilePaths()
        {
            this.folderPaths = this.GetFolderPaths();

            this.AddFolderPaths(folderPaths);
            try
            {
                var renamedFolders = this.foldersRenamer.RenameFolders(folderPaths);

                this.foldersRemover.TreatFoldersToRemove(renamedFolders);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

        private string[] GetFolderPaths()
        {
            var folderPaths = new string[1];

            Console.WriteLine("What directory do you want to shorten the content of?");

            folderPaths[0] = Console.ReadLine();

            return folderPaths;
        }

        private void AddFolderPaths(string[] folderPaths)
        {
            for (var pathIndex = 0; pathIndex < folderPaths.Length; pathIndex++)
            {
                folderPaths[pathIndex] = folderPaths[pathIndex].Trim('"');

                if (folderPaths[pathIndex].IndexOfAny(Path.GetInvalidPathChars()) < 0)
                {
                    continue;
                }

                this.TreatPathNameError(folderPaths, pathIndex);
            }
        }

        private void TreatPathNameError(string[] folderPaths, int pathIndex)
        {
            Console.WriteLine("Following Path contains invalid characters and will be ignored:");
            Console.WriteLine(folderPaths[pathIndex]);

            folderPaths[pathIndex] = null;
        }
    }
}
