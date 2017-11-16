using BillingApp.BillingApp.Program;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BillingApp
{
    public class CodingTestInput : IInput
    {
        public BillRow Interpreter(string row)
        {
            string pattern = @"(\b\d+\b)(.+)?at\s(\d+.\d+)";
            var match = Regex.Match(row, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return new CodingTestBillRow(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
            }
            else
            {
                return null;
            }
        }
    }
}
