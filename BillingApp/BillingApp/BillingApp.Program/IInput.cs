using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    interface IInput
    {
        BillRow Interpreter(string row);
    }
}
