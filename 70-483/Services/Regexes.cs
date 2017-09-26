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
        public static bool ContainsHyperlink(string inputData)
        {
            string regExPattern = "";
            var evaluator = new Regex(regExPattern, RegexOptions.Compiled);
            return evaluator.IsMatch(inputData);
        }
    }
}
