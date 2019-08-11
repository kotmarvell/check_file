using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace check_file
{
    class HTMLFile : AbstractParser
    {
        public string nameFile;
        public string nameDirectory;

        //public HTMLFile(string name, string nameDirectory)
        //{
        //    nameFile = name;
        //    this.nameDirectory = nameDirectory;
        //}
        public override int getSymbolCount()
        {
            int countSimbol = 0;

            //nameDirectory += "/" + nameFile;
            //StreamReader file = new StreamReader(nameDirectory, System.Text.Encoding.Default);
            //string line;
            //while ((line = file.ReadLine()) != null)
            //{
            //    //поиск знаков препинания
            //}

            return countSimbol;
        }
    }
}
