namespace CleanCode._02.FilePath
{
    using System;
    using System.IO;
    using System.Threading;

    public class ChkFolderLng
    {
        private static int counter1;
        private static int counter2;

        public static void Execute()
        {
            var strArrayList = new string[1];

            Console.WriteLine("What directory do you want to shorten the content of?");
            strArrayList[0] = Console.ReadLine();


            for (var i = 0; i < strArrayList.Length; i++)
            {
                strArrayList[i] = strArrayList[i].Trim('"');
                if (strArrayList[i].IndexOfAny(Path.GetInvalidPathChars()) < 0) { continue; }

                Console.WriteLine("Following Path contains invalid characters and will be ignored:");
                Console.WriteLine(strArrayList[i]);
                strArrayList[i] = null;
            }

            try
            {
                var pathArrayLst = RenameFolders(strArrayList);
                Console.WriteLine($"Success! Directories: {counter1 + counter2}");
                Console.WriteLine("Directories Renamed: " + counter1);
                Console.WriteLine("Directories not renamed: " + counter2);
                Console.WriteLine("Do you want to delete the renamed directories? (Y [Default] / N)");
                var deleteResponse = Console.ReadLine();
                Console.WriteLine();

                switch (deleteResponse)
                {
                    case "n":
                    case "N":
                        Console.WriteLine("No directories where deleted.");
                        break;
                    default:
                        var thread = new Thread(() => RemoveDirectories(pathArrayLst));
                        thread.Start();
                        ConsoleSpinner.TurnWhile(thread);
                        Console.WriteLine("All directories where deleted.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

        private static string[] RenameFolders(string[] pathsList)
        {
            var newPaths = new string[pathsList.Length];
            for (var i = 0; i < pathsList.Length; i++)
            {
                newPaths[i] = RenameFolder(pathsList[i]);
            }
            return newPaths;
        }

        private static string RenameFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("A directory has to be specified.");
            }

            var attr = File.GetAttributes(path);
            if (!attr.HasFlag(FileAttributes.Directory))
            {
                throw new Exception("The specified path is a file.");
            }

            var folder = new DirectoryInfo(path);

            if (!folder.Exists)
            {
                throw new Exception("The directory doesn't exist.");
            }

            if (folder.Parent != null)
            {
                var moveTo = folder.Parent.FullName.TrimEnd('\\') + "\\" + "_" + counter1;
                if (!Directory.Exists(moveTo))
                {
                    folder.MoveTo(moveTo);
                    counter1++;
                }
                else
                {
                    if (moveTo != folder.FullName)
                    {
                        Console.WriteLine(
                            "The following directory was not renamed because a conflict would have been caused:");
                        Console.WriteLine(folder.FullName);
                    }

                    counter2++;
                }
            }

            var subdirectoriesList = Directory.GetDirectories(folder.FullName);
            foreach (var subdirectory in subdirectoriesList)
            {
                RenameFolder(subdirectory);
            }

            return folder.FullName;
        }

        private static void RemoveDirectories(string[] pathsList)
        {
            for (var i = 0; i < Int32.MaxValue; i++)
            {
                i = i;
            }
            foreach (var path in pathsList)
            {
                Directory.Delete(path, true);
            }
        }
    }
}
