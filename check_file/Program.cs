using System;
using System.IO;

namespace check_file
{
    class Program
    {
        public static string nameDirectory = "C:/Users/kotmavell/Desktop/test";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Please write the directory path.");
            //string nameDirectory = Console.ReadLine();

            FileSystemWatcher watcher = new FileSystemWatcher(nameDirectory);

            watcher.Filter = "*.*";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);            

            watcher.EnableRaisingEvents = true;
            Console.ReadKey();
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.Name} {e.ChangeType} ");  
            string filePath = nameDirectory + "/" + Convert.ToString(e.Name);
            countSymbols(filePath, Convert.ToString(e.ChangeType), Convert.ToString(e.Name));
        }

        private static string typeFile(string name)
        {
            int point = name.IndexOf(".");
            string type = name.Remove(0, point);
            return type;
        }

        private static AbstractParser getParserByType(string type, string filePath)
        {
            switch (type)
            {
                case ".css":
                    return new CSSFile(filePath);
                case ".html":
                    return new HTMLFile(filePath);
                default:
                    return new OtherFile(filePath);
            }
        }

        private static void countSymbols(string filePath, string changeType, string nameFile)
        {
            string type = typeFile(filePath);
            AbstractParser parser = getParserByType(type, filePath);
            string result = nameFile + " " + changeType + " " + parser.getSymbolCount();
            writeToFile(result);
        }

        private static void writeToFile(string myString)
        {
            StreamWriter writer = new StreamWriter("output.txt", false, System.Text.Encoding.Default);
            writer.WriteLine(myString);
        }
    }
}
