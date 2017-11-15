using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    interface IBill
    {
        Output Generate(IList<string> cashierInput);
    }
}
