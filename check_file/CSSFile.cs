using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace check_file
{
    class CSSFile : AbstractParser
    {
        public string finalName;

        public CSSFile(string finalName)
        {
            this.finalName = finalName;
        }
        public override int getSymbolCount()
        {
            int countSymbol = 0;

            int countOt = 0;
            int countZac = 0;
            StreamReader file = new StreamReader(finalName, System.Text.Encoding.Default);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string pattern1 = @"}";
                Regex regex = new Regex(pattern1);
                MatchCollection mc = regex.Matches(line);

                countOt += mc.Count;

                string pattern2 = @"{";
                regex = new Regex(pattern2);
                mc = regex.Matches(line);

                countZac += mc.Count;
            }

            if (countZac == countOt)
            {
                return 1;
            }
            else
            {
                return 0;
            }     
        }
    }
}
