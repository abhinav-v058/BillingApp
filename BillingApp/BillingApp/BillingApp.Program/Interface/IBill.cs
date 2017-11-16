using System;
using System.Collections.Generic;
using System.Text;

namespace BillingApp.BillingApp.Program
{
    interface IBill
    {
        IList<BillRow> BillData { get; set; }
        IOutput Generate(IList<string> cashierInput);
    }
}
