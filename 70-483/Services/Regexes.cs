using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public static class Regexes
    {
        public static bool CompiledPattern(string inputData)
        {
            string regExPattern = "";
            var evaluator = new Regex(regExPattern, RegexOptions.Compiled);
            return evaluator.IsMatch(inputData);
        }

        public static List<string> CheckIfWebsite(string urls)
        {
            List<string> result = new List<string>();

            const string pattern = @"http://(www\\.)?([^\\.]+)\\.com";

            MatchCollection myMatches = Regex.Matches(urls, pattern);

            result = (from
                Match m in myMatches
                      select m.Value).ToList();
            return result;
        }

        public static bool PositiveWithTwoDecimalPlaces(decimal number)
        {
            bool result = false;
            Regex reg = new Regex(@"^\d+(\.\d\d)?$");
            if (reg.IsMatch(number.ToString()))
            {
                result = true;
            }

            return result;
        }
    }
}
