﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace check_file
{
    class CSSFile : AbstractParser
    {
        private string filePath;

        public CSSFile(string filePath)
        {
            this.filePath = filePath;
        }
        public override int getSymbolCount()
        { 
            int countOpen = 0;
            int countClose = 0;
            StreamReader file = new StreamReader(filePath, System.Text.Encoding.Default);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string pattern1 = @"}";
                Regex regex = new Regex(pattern1);
                MatchCollection mc = regex.Matches(line);
                countOpen += mc.Count;

                string pattern2 = @"{";
                regex = new Regex(pattern2);
                mc = regex.Matches(line);
                countClose += mc.Count;
            }

            if (countClose == countOpen)
                return 1;
            else
                return 0;  
        }
    }
}
