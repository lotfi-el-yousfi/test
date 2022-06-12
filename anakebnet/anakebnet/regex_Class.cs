using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace anakebnet
{
    class regex_Class
    {
        public static List<string> serch (string text, string pat)
        {
            List<string> founds = new List<string>();
            Regex rgx = new Regex(pat, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(text);
            if (matches.Count > 0)
            {
                Console.WriteLine("{0} ({1} matches):", text, matches.Count);
                foreach (Match match in matches)
                    founds.Add(match.Value);
            }
            return founds;

        }
         
    }
}
