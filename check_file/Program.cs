using System;
using System.IO;

namespace check_file
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("");
            //string nameDirectory = Console.ReadLine();

            //// If a directory is not specified, exit program.
            //if (nameDirectory.Length < 3)
            //{
            //    // Display the proper way to call the program.
            //    Console.WriteLine("Usage: Watcher.exe (directory)");
            //    return;
            //}

            FileSystemWatcher watcher = new FileSystemWatcher("C:/Users/kotmavell/Desktop/test");
            //FileSystemWatcher watcher = new FileSystemWatcher(nameDirectory);

            watcher.Filter = "*.*";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);            

            watcher.EnableRaisingEvents = true;
            Console.ReadKey();
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.Name} {e.ChangeType}");

            //if (typeFile(Convert.ToString(e.Name)) == ".txt")
            //{
                
            //}

        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldName, e.Name);
        }

        private static string typeFile(string name)
        {
            int point = name.IndexOf(".");
            string type = name.Remove(0, point);
            return type;
        }
    }
}
