namespace CleanCode.FileManteneinance
{
    using System;
    using System.IO;

    public class FoldersRenamer
    {
        private static int foldersRenamed;
        private static int foldersNotRenamed;

        public string[] RenameFolders(string[] paths)
        {
            var newPaths = new string[paths.Length];
            for (var indexInPaths= 0; indexInPaths < paths.Length; indexInPaths++)
            {
                newPaths[indexInPaths] = RenameFolder(paths[indexInPaths]);
            }
            return newPaths;
        }

        private static string RenameFolder(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                throw new Exception("A directory has to be specified.");
            }

            var attr = File.GetAttributes(folderPath);
            if (!attr.HasFlag(FileAttributes.Directory))
            {
                throw new Exception("The specified path is a file.");
            }

            var folderInfo = new DirectoryInfo(folderPath);

            if (!folderInfo.Exists)
            {
                throw new Exception("The directory doesn't exist.");
            }

            if (folderInfo.Parent != null)
            {
                var folderRenamedTo = folderInfo.Parent.FullName.TrimEnd('\\') + "\\" + "_" + foldersRenamed;
                if (!Directory.Exists(folderRenamedTo))
                {
                    folderInfo.MoveTo(folderRenamedTo);
                    foldersRenamed++;
                }
                else
                {
                    if (folderRenamedTo != folderInfo.FullName)
                    {
                        Console.WriteLine(
                            "The following directory was not renamed because a conflict would have been caused:");
                        Console.WriteLine(folderInfo.FullName);
                    }

                    foldersNotRenamed++;
                }
            }

            var subdirectories = Directory.GetDirectories(folderInfo.FullName);
            foreach (var subdirectory in subdirectories)
            {
                RenameFolder(subdirectory);
            }

            Console.WriteLine($"Success! Directories: {foldersRenamed + foldersNotRenamed}");
            Console.WriteLine("Directories Renamed: " + foldersRenamed);
            Console.WriteLine("Directories not renamed: " + foldersNotRenamed);
            
            return folderInfo.FullName;
        }
    }
}
