using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace check_file
{
    class OtherFile : AbstractParser
    {
        private string filePath;

        public OtherFile(string filePath)
        {
            this.filePath = filePath;
        }
        public override int getSymbolCount()
        {
            int countSymbol = 0;

            StreamReader file = new StreamReader(filePath, System.Text.Encoding.Default);
            string line;
            while((line = file.ReadLine()) != null)
            {
                string pattern = @"[-.?!)(,:]";
                Regex regex = new Regex(pattern);
                MatchCollection mc = regex.Matches(line);

                countSymbol += mc.Count;
            }

            return countSymbol;
        }
    }
}
