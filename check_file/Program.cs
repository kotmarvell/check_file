using System;
using System.IO;

namespace check_file
{
    class Program
    {
        public static string nameDirectory = "C:/Users/kotmavell/Desktop/test";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            //string nameDirectory = Console.ReadLine();

            FileSystemWatcher watcher = new FileSystemWatcher(nameDirectory);

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
            Console.WriteLine($"File: {e.Name} {e.ChangeType} ");  
            string finalName = nameDirectory + "/" + Convert.ToString(e.Name);
            countSymbols(finalName);
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

        private static AbstractParser getParserByType(string type, string name)
        {
            switch (type)
            {
                case ".css":
                    return new CSSFile(name);
                case ".html":
                    return new HTMLFile(name);
                default:
                    return new OtherFile(name);
            }
        }

        private static void countSymbols(string finalName)
        {
            string type = typeFile(finalName);
            AbstractParser parser = getParserByType(type, finalName);
            Console.WriteLine(parser.getSymbolCount());
        }
    }
}
