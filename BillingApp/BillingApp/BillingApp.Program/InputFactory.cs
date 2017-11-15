using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    class InputFactory
    {
        public static IInput GetInputInterpreter(string inputType)
        {
            switch (inputType)
            {
                case "DealerOnTestFormat":
                    return new CodingTestInput();
                default:
                    return null;
            }

        }
    }
}
