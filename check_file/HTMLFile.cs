using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace check_file
{
    class HTMLFile : AbstractParser
    {
        public string finalName;

        public HTMLFile(string finalName)
        {
            this.finalName = finalName;
        }
        public override int getSymbolCount()
        {
            int countSymbol = 0;

            StreamReader file = new StreamReader(finalName, System.Text.Encoding.Default);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string pattern1 = @"}";
                Regex regex = new Regex(pattern1);
                MatchCollection mc = regex.Matches(line);

                countSymbol += mc.Count;

                string pattern2 = @"{";
                regex = new Regex(pattern2);
                mc = regex.Matches(line);

                countSymbol += mc.Count;
            }

            return countSymbol;
        }
    }
}
