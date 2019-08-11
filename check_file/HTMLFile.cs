using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace check_file
{
    class HTMLFile : AbstractParser
    {
        private string filePath;

        public HTMLFile(string filePath)
        {
            this.filePath = filePath;
        }
        public override int getSymbolCount()
        {
            int countSymbol = 0;

            StreamReader file = new StreamReader(filePath, System.Text.Encoding.Default);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string pattern1 = @"<div\w*";
                Regex regex = new Regex(pattern1);
                MatchCollection mc = regex.Matches(line);

                countSymbol += mc.Count;
            }

            return countSymbol;
        }
    }
}
