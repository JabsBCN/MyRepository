namespace CleanCode.FileManteneinance
{
    using System;
    using System.IO;
    using System.Threading;
    
    public class FoldersRemover
    {
        public void TreatFoldersToRemove(string[] folderPaths)
        {
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
                    var thread = new Thread(() => RemoveFolders(folderPaths));
                    thread.Start();
                    ConsoleSpinner.TurnWhile(thread);
                    Console.WriteLine("All directories where deleted.");
                    break;
            }
        }

        private static void RemoveFolders(string[] folderPaths)
        {
            foreach (var path in folderPaths)
            {
                Directory.Delete(path, true);
            }
        }
    }
}
