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
            CodingTestBillRow temp = null;
            if (match.Success)
            {
                temp = new CodingTestBillRow(match.Groups[1].Value, match.Groups[2].Value.Trim(), match.Groups[3].Value);
                temp.IsImported = temp.Name.ToLower().Contains("import") ? true : false;
                temp.Type = DetechType(temp.Name.ToLower());
                return temp;
            }
            else
            {
                return null;
            }
        }

        private ItemTypeEnum DetechType(string name)
        {
            if (name.Contains("book"))
                return ItemTypeEnum.Book;
            else if (name.Contains("food") || name.Contains("chocolate") || name.Contains("chips"))
                return ItemTypeEnum.Food;
            else if (name.Contains("pill"))
                return ItemTypeEnum.Medical;
            else
                return ItemTypeEnum.Others;
        }
    }
}
